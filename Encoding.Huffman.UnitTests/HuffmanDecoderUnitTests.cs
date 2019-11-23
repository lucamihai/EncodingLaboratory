using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Huffman.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanDecoderUnitTests
    {
        private HuffmanDecoder huffmanDecoder;
        private Mock<IHuffmanHeaderReader> huffmanReaderMock;
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManagerMock;
        private Mock<IFileReader> fileReaderMock;
        private Mock<IFileWriter> fileWriterMock;

        private List<ByteStatistics> characterStatisticsFromMock;
        private List<EncodedByte> encodedBytesFromMock;

        [TestInitialize]
        public void Setup()
        {
            characterStatisticsFromMock = ConstantsEncodingSystems.TextCharacterStatistics1;
            encodedBytesFromMock = ConstantsEncodingSystems.EncodedBytes1();

            huffmanReaderMock = new Mock<IHuffmanHeaderReader>();
            huffmanEncodedBytesManagerMock = new Mock<IHuffmanEncodedBytesManager>();
            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();

            huffmanDecoder = new HuffmanDecoder(huffmanReaderMock.Object, huffmanEncodedBytesManagerMock.Object);

            SetupHuffmanReaderMock();
            SetupHuffmanEncodedBytesManagerMock();
            SetupFileReaderMock();
        }

        private void SetupHuffmanReaderMock()
        {
            huffmanReaderMock
                .Setup(x => x.ReadByteStatistics(It.IsAny<IFileReader>()))
                .Returns(characterStatisticsFromMock);
        }

        private void SetupHuffmanEncodedBytesManagerMock()
        {
            huffmanEncodedBytesManagerMock
                .Setup(x => x.GetEncodedBytesFromByteStatistics(It.IsAny<List<ByteStatistics>>()))
                .Returns(encodedBytesFromMock);
        }

        private void SetupFileReaderMock()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeFileThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanDecoder.DecodeFile(null, fileWriterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            huffmanDecoder.DecodeFile(fileReaderMock.Object, null);
        }

        [TestMethod]
        public void DecodeFileCallsHuffmanHeaderReaderReadByteStatisticsOnce()
        {
            huffmanDecoder.DecodeFile(fileReaderMock.Object, fileWriterMock.Object);

            huffmanReaderMock.Verify(x => x.ReadByteStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void DecodeFileCallsHuffmanEncodedBytesManagerGetEncodedBytesFromByteStatisticsOnce()
        {
            huffmanDecoder.DecodeFile(fileReaderMock.Object, fileWriterMock.Object);

            huffmanReaderMock.Verify(x => x.ReadByteStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void DecodeFileCallsFileReaderReadBitExpectedNumberOfTimes()
        {
            huffmanDecoder.DecodeFile(fileReaderMock.Object, fileWriterMock.Object);

            fileReaderMock.Verify(x => x.ReadBit(), Times.Exactly(ConstantsEncodingSystems.NumberOfBitsForHuffmanEncoding1));
        }

        [TestMethod]
        public void GetDecodedBytesSetsEncodedBytesFromPreviousRunWithEncodedBytesReturnedByHuffmanEncodedBytesManager()
        {
            huffmanDecoder.DecodeFile(fileReaderMock.Object, fileWriterMock.Object);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(encodedBytesFromMock, huffmanDecoder.EncodedBytesFromPreviousRun).AreEqual);
        }
    }
}
