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
        private FileWriter fileWriter;
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
            fileWriter?.Dispose();
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullFilePath()
        {
            fileWriter = new FileWriter(null, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForEmptyFilePath()
        {
            fileWriter = new FileWriter(string.Empty, bufferMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullBuffer()
        {
            fileWriter = new FileWriter(filePath, null);
        }

        [TestMethod]
        public void ConstructorSetsFilePathForExistingFile()
        {
            File.WriteAllBytes(filePath, Constants.TestFileBytes);

            fileWriter = new FileWriter(filePath, bufferMock.Object);

            Assert.AreEqual(filePath, fileWriter.FilePath);
        }

        [TestMethod]
        public void ConstructorSetsBufferPropertyForValidBuffer()
        {
            fileWriter = new FileWriter(filePath, bufferMock.Object);

            Assert.AreSame(bufferMock.Object, fileWriter.Buffer);
        }

        [TestMethod]
        public void WriteBitCallsBufferAddValueStartingFromCurrentBitWithValue1And1BitIfBitValueIsTrue()
        {
            fileWriter = new FileWriter(filePath, bufferMock.Object);
            bufferMock
                .Setup(x => x.AddValueStartingFromCurrentBit(It.IsAny<byte>(), 1));

            fileWriter.WriteBit(true);

            bufferMock.Verify(x => x.AddValueStartingFromCurrentBit(1, 1), Times.Once);
        }

        [TestMethod]
        public void WriteBitCallsBufferAddValueStartingFromCurrentBitWithValue0And1BitIfBitValueIsFalse()
        {
            fileWriter = new FileWriter(filePath, bufferMock.Object);
            bufferMock
                .Setup(x => x.AddValueStartingFromCurrentBit(It.IsAny<byte>(), 1));

            fileWriter.WriteBit(false);

            bufferMock.Verify(x => x.AddValueStartingFromCurrentBit(0, 1), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WriteValueOnBitsThrowsArgumentExceptionForNumberOfBitsEqualToZero()
        {
            fileWriter = new FileWriter(filePath, bufferMock.Object);

            fileWriter.WriteValueOnBits(Constants.Value1, 0);
        }

        [TestMethod]
        public void WriteValueOnBitsCallsBufferAddValueStartingFromCurrentBitWithValueAndBitNumberFromParameters()
        {
            fileWriter = new FileWriter(filePath, bufferMock.Object);
            bufferMock
                .Setup(x => x.AddValueStartingFromCurrentBit(Constants.Value1, Constants.Value1BitsRequired));

            fileWriter.WriteValueOnBits(Constants.Value1, Constants.Value1BitsRequired);

            bufferMock.Verify(x => x.AddValueStartingFromCurrentBit(Constants.Value1, Constants.Value1BitsRequired), Times.Once);
        }
    }
}
