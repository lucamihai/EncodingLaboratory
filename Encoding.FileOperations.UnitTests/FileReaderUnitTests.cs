using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderUnitTests
    {
        private string filePath;
        private Mock<IBuffer> bufferMock;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            bufferMock = new Mock<IBuffer>();

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
            var fileReader = new FileReader(null, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            var fileReader = new FileReader(string.Empty, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForFileNotExisting()
        {
            var fileReader = new FileReader("abc", bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullBuffer()
        {
            var fileReader = new FileReader(filePath, null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathPropertyForExistingFile()
        {
            var fileReader = new FileReader(filePath, bufferMock.Object);

            Assert.AreEqual(filePath, fileReader.FilePath);
        }

        [TestMethod]
        public void ConstructorSetsBufferPropertyForValidBuffer()
        {
            var fileReader = new FileReader(filePath, bufferMock.Object);

            Assert.AreSame(bufferMock.Object, fileReader.Buffer);
        }
    }
}
