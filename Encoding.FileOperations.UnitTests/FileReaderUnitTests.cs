using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderUnitTests
    {
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            File.WriteAllBytes(filePath, Constants.TestFileBytes);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullFilePath()
        {
            var fileReader = new FileReader(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            var fileReader = new FileReader(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForFileNotExisting()
        {
            var fileReader = new FileReader(null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathForExistingFile()
        {
            var fileReader = new FileReader(filePath);

            Assert.AreEqual(filePath, fileReader.FilePath);
        }
    }
}
