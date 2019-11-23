using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderUnitTests
    {
        private FileReader fileReader;
        private string filePath;
        private Mock<IBuffer> bufferMock;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            bufferMock = new Mock<IBuffer>();

            SetupBufferMock();

            File.WriteAllBytes(filePath, Constants.TestFileBytes);
        }

        private void SetupBufferMock()
        {
            bufferMock
                .Setup(x => x.GetValueStartingFromCurrentBit(It.IsAny<byte>()))
                .Returns(1);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileReader?.Dispose();

            TestMethods.DeleteFileIfExists(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullFilePath()
        {
            fileReader = new FileReader(null, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            fileReader = new FileReader(string.Empty, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForFileNotExisting()
        {
            TestMethods.DeleteFileIfExists(filePath);

            fileReader = new FileReader(filePath, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullBuffer()
        {
            fileReader = new FileReader(filePath, null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathPropertyForExistingFile()
        {
            fileReader = new FileReader(filePath, bufferMock.Object);

            Assert.AreEqual(filePath, fileReader.FilePath);
        }

        [TestMethod]
        public void ConstructorSetsBufferPropertyForValidBuffer()
        {
            fileReader = new FileReader(filePath, bufferMock.Object);

            Assert.AreSame(bufferMock.Object, fileReader.Buffer);
        }

        [TestMethod]
        public void ReadBitCallsBufferGetValueStartingFromCurrentBitWith1BitToReadOnce()
        {
            fileReader = new FileReader(filePath, bufferMock.Object);

            fileReader.ReadBit();

            bufferMock.Verify(x => x.GetValueStartingFromCurrentBit(1), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadBitsThrowsArgumentExceptionForNumberOfBitsEqualToZero()
        {
            fileReader = new FileReader(filePath, bufferMock.Object);

            fileReader.ReadBits(0);
        }

        [TestMethod]
        public void ReadBitsCallsBufferGetValueStartingFromCurrentBitWithProvidedNumberOfBitsOnce()
        {
            fileReader = new FileReader(filePath, bufferMock.Object);
            const byte numberOfBits = 5;

            fileReader.ReadBits(numberOfBits);

            bufferMock.Verify(x => x.GetValueStartingFromCurrentBit(numberOfBits), Times.Once);
        }
    }
}
