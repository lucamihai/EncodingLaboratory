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
        public void GetDecodedTextThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanDecoder.GetDecodedBytes(null);
        }

        [TestMethod]
        public void GetDecodedTextCallsHuffmanHeaderReaderReadByteStatisticsOnce()
        {
            huffmanDecoder.GetDecodedBytes(fileReaderMock.Object);

            huffmanReaderMock.Verify(x => x.ReadByteStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetDecodedTextCallsHuffmanEncodedBytesManagerGetEncodedBytesFromByteStatisticsOnce()
        {
            huffmanDecoder.GetDecodedBytes(fileReaderMock.Object);

            huffmanReaderMock.Verify(x => x.ReadByteStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetDecodedTextCallsFileReaderReadBitExpectedNumberOfTimes()
        {
            huffmanDecoder.GetDecodedBytes(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBit(), Times.Exactly(ConstantsEncodingSystems.NumberOfBitsForHuffmanEncoding1));
        }

        [TestMethod]
        public void GetDecodedBytesSetsEncodedBytesFromPreviousRunWithEncodedBytesReturnedByHuffmanEncodedBytesManager()
        {
            huffmanDecoder.GetDecodedBytes(fileReaderMock.Object);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(encodedBytesFromMock, huffmanDecoder.EncodedBytesFromPreviousRun).AreEqual);
        }
    }
}
