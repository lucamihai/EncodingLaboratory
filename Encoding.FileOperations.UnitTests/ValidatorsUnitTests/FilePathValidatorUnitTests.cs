using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.UnitTests.ValidatorsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FilePathValidatorUnitTests
    {
        private FilePathValidator filePathValidator;
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePathValidator = new FilePathValidator();
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateAndThrowThrowsArgumentNullExceptionForNullFilePath()
        {
            filePathValidator.ValidateAndThrow(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateAndThrowThrowsArgumentNullExceptionForEmptyFilePath()
        {
            filePathValidator.ValidateAndThrow(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateAndThrowThrowsArgumentNullExceptionForNotExistingFile()
        {
            filePathValidator.ValidateAndThrow(filePath);
        }

        [TestMethod]
        public void ValidateAndThrowDoesNotThrowAnyExceptionForNotExistingFileIfOptionalParameterIsSetToFalse()
        {
            filePathValidator.ValidateAndThrow(filePath, false);
        }

        [TestMethod]
        public void ValidateAndThrowDoesNotThrowAnyExceptionForExistingFile()
        {
            File.WriteAllText(filePath, "contents");

            filePathValidator.ValidateAndThrow(filePath);

            File.Delete(filePath);
        }
    }
}
