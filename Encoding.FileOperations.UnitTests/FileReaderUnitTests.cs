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
        private FileReader fileReader;
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
            fileReader?.Dispose();
            File.Delete(filePath);
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
            fileReader = new FileReader("abc", bufferMock.Object);
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
            bufferMock
                .Setup(x => x.GetValueStartingFromCurrentBit(It.IsAny<byte>()))
                .Returns(1);

            fileReader.ReadBit();

            bufferMock.Verify(x => x.GetValueStartingFromCurrentBit(It.IsAny<byte>()), Times.Once);
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
            const byte numberOfBits = 5;
            fileReader = new FileReader(filePath, bufferMock.Object);
            bufferMock
                .Setup(x => x.GetValueStartingFromCurrentBit(numberOfBits))
                .Returns(1);

            fileReader.ReadBits(numberOfBits);

            bufferMock.Verify(x => x.GetValueStartingFromCurrentBit(numberOfBits), Times.Once);
        }
    }
}
