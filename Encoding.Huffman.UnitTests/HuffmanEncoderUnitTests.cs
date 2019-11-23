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
    public class HuffmanEncoderUnitTests
    {
        private Mock<IStatisticsGenerator> statisticsGeneratorMock;
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManagerMock;
        private Mock<IHuffmanHeaderWriter> huffmanHeaderWriterMock;
        private Mock<IFileReader> fileReaderMock;
        private Mock<IFileWriter> fileWriterMock;
        private HuffmanEncoder huffmanEncoder;

        private List<EncodedByte> encodedBytesReturnedByHuffmanEncodedBytesManager;

        [TestInitialize]
        public void Setup()
        {
            statisticsGeneratorMock = new Mock<IStatisticsGenerator>();
            huffmanEncodedBytesManagerMock = new Mock<IHuffmanEncodedBytesManager>();
            huffmanHeaderWriterMock = new Mock<IHuffmanHeaderWriter>();
            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();

            huffmanEncoder = new HuffmanEncoder(statisticsGeneratorMock.Object, huffmanEncodedBytesManagerMock.Object, huffmanHeaderWriterMock.Object);

            SetupStatisticsGeneratorMock();
            SetupHuffmanEncodedBytesManagerMock();
        }

        private void SetupStatisticsGeneratorMock()
        {
            statisticsGeneratorMock
                .Setup(x => x.GetByteStatisticsFromFile(fileReaderMock.Object))
                .Returns(ConstantsEncodingSystems.TextCharacterStatistics1);
        }

        private void SetupHuffmanEncodedBytesManagerMock()
        {
            encodedBytesReturnedByHuffmanEncodedBytesManager = ConstantsEncodingSystems.EncodedBytes1();

            huffmanEncodedBytesManagerMock
                .Setup(x => x.GetEncodedBytesFromByteStatistics(It.IsAny<List<ByteStatistics>>()))
                .Returns(encodedBytesReturnedByHuffmanEncodedBytesManager);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeBytesToFileThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanEncoder.EncodeFile(null, fileWriterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeBytesToFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            huffmanEncoder.EncodeFile(fileReaderMock.Object, null);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsTextAnalyzerGetCharacterStatisticsFromTextWithTextFromParameterOnce()
        {
            huffmanEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object);

            statisticsGeneratorMock.Verify(x => x.GetByteStatisticsFromFile(fileReaderMock.Object), Times.Once);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsHuffmanEncodedBytesManagerMockGetEncodedBytesFromByteStatisticsOnce()
        {
            huffmanEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object);

            huffmanEncodedBytesManagerMock.Verify(x => x.GetEncodedBytesFromByteStatistics(It.IsAny<List<ByteStatistics>>()), Times.Once);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsHuffmanHeaderWriterSetPathFromNodeToParentOnceForEachLeaf()
        {
            huffmanEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object);

            huffmanHeaderWriterMock.Verify(x=>x.WriteHeaderToFile(It.IsAny<List<ByteStatistics>>(), fileWriterMock.Object), Times.Once);
        }

        //[TestMethod]
        //public void EncodeBytesToFileCallsFileWriterWriteValueOnBitsForEachCharacterInText()
        //{
        //    huffmanEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object);

        //    fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), It.IsAny<byte>()), Times.Exactly(bytes.Length));
        //}

        [TestMethod]
        public void EncodeBytesToFileSetsEncodedBytesFromPreviousRunWithEncodedBytesReturnedByHuffmanEncodedBytesManager()
        {
            huffmanEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(encodedBytesReturnedByHuffmanEncodedBytesManager, huffmanEncoder.EncodedBytesFromPreviousRun).AreEqual);
        }
    }
}
