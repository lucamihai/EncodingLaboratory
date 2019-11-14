using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Decoders;
using Encoding.Systems.Interfaces.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Systems.UnitTests.DecodersUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanDecoderUnitTests
    {
        private HuffmanDecoder huffmanDecoder;
        private Mock<IHuffmanHeaderReader> huffmanReaderMock;
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManagerMock;
        private Mock<IFileReader> fileReaderMock;

        private List<CharacterStatistics> characterStatisticsFromMock;
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
                .Setup(x => x.ReadCharacterStatistics(It.IsAny<IFileReader>()))
                .Returns(characterStatisticsFromMock);
        }

        private void SetupHuffmanEncodedBytesManagerMock()
        {
            huffmanEncodedBytesManagerMock
                .Setup(x => x.GetEncodedBytesFromCharacterStatistics(It.IsAny<List<CharacterStatistics>>()))
                .Returns(encodedBytesFromMock);
        }

        private void SetupFileReaderMock()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDecodedTextThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanDecoder.GetDecodedText(null);
        }

        [TestMethod]
        public void GetDecodedTextCallsHuffmanHeaderReaderReadCharacterStatisticsOnce()
        {
            huffmanDecoder.GetDecodedText(fileReaderMock.Object);

            huffmanReaderMock.Verify(x => x.ReadCharacterStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetDecodedTextCallsHuffmanEncodedBytesManagerGetEncodedBytesFromCharacterStatisticsOnce()
        {
            huffmanDecoder.GetDecodedText(fileReaderMock.Object);

            huffmanReaderMock.Verify(x => x.ReadCharacterStatistics(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetDecodedTextCallsFileReaderReadBitExpectedNumberOfTimes()
        {
            huffmanDecoder.GetDecodedText(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBit(), Times.Exactly(ConstantsEncodingSystems.NumberOfBitsForHuffmanEncoding1));
        }
    }
}
