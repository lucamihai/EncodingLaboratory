using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManager;
        private Mock<IFileReader> fileReaderMock;

        private List<CharacterStatistics> characterStatisticsFromMock;
        private List<EncodedByte> encodedBytesFromMock;

        [TestInitialize]
        public void Setup()
        {
            characterStatisticsFromMock = ConstantsEncodingSystems.TextCharacterStatistics1;
            encodedBytesFromMock = ConstantsEncodingSystems.EncodedBytes1();

            huffmanReaderMock = new Mock<IHuffmanHeaderReader>();
            huffmanEncodedBytesManager = new Mock<IHuffmanEncodedBytesManager>();
            fileReaderMock = new Mock<IFileReader>();

            huffmanDecoder = new HuffmanDecoder(huffmanReaderMock.Object, huffmanEncodedBytesManager.Object);

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
            huffmanEncodedBytesManager
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
    }
}
