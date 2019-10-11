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

        [TestInitialize]
        public void Setup()
        {
            filePathValidator = new FilePathValidator();
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
            filePathValidator.ValidateAndThrow("abc");
        }

        [TestMethod]
        public void ValidateAndThrowDoesNotThrowAnyExceptionForExistingFile()
        {
            var filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            File.WriteAllText(filePath, "contents");

            filePathValidator.ValidateAndThrow(filePath);

            File.Delete(filePath);
        }
    }
}
