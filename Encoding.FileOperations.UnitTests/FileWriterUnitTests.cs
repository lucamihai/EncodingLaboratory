using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileWriterUnitTests
    {
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullFilePath()
        {
            var fileWriter = new FileWriter(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            var fileWriter = new FileWriter(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForFileNotExisting()
        {
            var fileWriter = new FileWriter(null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathForExistingFile()
        {
            File.WriteAllBytes(filePath, Constants.TestFileBytes);

            var fileWriter = new FileWriter(filePath);

            Assert.AreEqual(filePath, fileWriter.FilePath);
        }
    }
}
