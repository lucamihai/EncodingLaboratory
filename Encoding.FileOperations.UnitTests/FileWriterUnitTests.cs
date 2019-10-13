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
    public class FileWriterUnitTests
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullFilePath()
        {
            var fileWriter = new FileWriter(null, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            var fileWriter = new FileWriter(string.Empty, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForFileNotExisting()
        {
            var fileWriter = new FileWriter("abc", bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullBuffer()
        {
            var fileWriter = new FileWriter(filePath, null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathForExistingFile()
        {
            File.WriteAllBytes(filePath, Constants.TestFileBytes);

            var fileWriter = new FileWriter(filePath, bufferMock.Object);

            Assert.AreEqual(filePath, fileWriter.FilePath);
        }

        [TestMethod]
        public void ConstructorSetsBufferPropertyForValidBuffer()
        {
            var fileWriter = new FileWriter(filePath, bufferMock.Object);

            Assert.AreSame(bufferMock.Object, fileWriter.Buffer);
        }
    }
}
