using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Encoders;
using Encoding.Systems.Interfaces.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Systems.UnitTests.EncodersUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderUnitTests
    {
        private Mock<IBytesAnalyzer> textAnalyzerMock;
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManagerMock;
        private Mock<IHuffmanHeaderWriter> huffmanHeaderWriterMock;
        private Mock<IFileWriter> fileWriterMock;
        private HuffmanEncoder huffmanEncoder;

        [TestInitialize]
        public void Setup()
        {
            textAnalyzerMock = new Mock<IBytesAnalyzer>();
            huffmanEncodedBytesManagerMock = new Mock<IHuffmanEncodedBytesManager>();
            huffmanHeaderWriterMock = new Mock<IHuffmanHeaderWriter>();
            fileWriterMock = new Mock<IFileWriter>();

            huffmanEncoder = new HuffmanEncoder(textAnalyzerMock.Object, huffmanEncodedBytesManagerMock.Object, huffmanHeaderWriterMock.Object);

            SetupTextAnalyzerMock();
            SetupHuffmanEncodedBytesManagerMock();
        }

        private void SetupTextAnalyzerMock()
        {
            textAnalyzerMock
                .Setup(x => x.GetByteStatisticsFromBytes(ConstantsEncodingSystems.Bytes1()))
                .Returns(ConstantsEncodingSystems.TextCharacterStatistics1);
        }

        private void SetupHuffmanEncodedBytesManagerMock()
        {
            huffmanEncodedBytesManagerMock
                .Setup(x => x.GetEncodedBytesFromByteStatistics(It.IsAny<List<ByteStatistics>>()))
                .Returns(ConstantsEncodingSystems.EncodedBytes1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeBytesToFileThrowsArgumentNullExceptionForNullBytes()
        {
            huffmanEncoder.EncodeBytesToFile(null, fileWriterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeBytesToFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            huffmanEncoder.EncodeBytesToFile(ConstantsEncodingSystems.Bytes1(), null);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsTextAnalyzerGetCharacterStatisticsFromTextWithTextFromParameterOnce()
        {
            var bytes = ConstantsEncodingSystems.Bytes1();

            huffmanEncoder.EncodeBytesToFile(bytes, fileWriterMock.Object);

            textAnalyzerMock.Verify(x => x.GetByteStatisticsFromBytes(bytes), Times.Once);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsHuffmanEncodedBytesManagerMockGetEncodedBytesFromByteStatisticsOnce()
        {
            huffmanEncoder.EncodeBytesToFile(ConstantsEncodingSystems.Bytes1(), fileWriterMock.Object);

            huffmanEncodedBytesManagerMock.Verify(x => x.GetEncodedBytesFromByteStatistics(It.IsAny<List<ByteStatistics>>()), Times.Once);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsHuffmanHeaderWriterSetPathFromNodeToParentOnceForEachLeaf()
        {
            huffmanEncoder.EncodeBytesToFile(ConstantsEncodingSystems.Bytes1(), fileWriterMock.Object);

            huffmanHeaderWriterMock.Verify(x=>x.WriteHeaderToFile(It.IsAny<List<ByteStatistics>>(), fileWriterMock.Object), Times.Once);
        }

        [TestMethod]
        public void EncodeBytesToFileCallsFileWriterWriteValueOnBitsForEachCharacterInText()
        {
            var bytes = ConstantsEncodingSystems.Bytes1();

            huffmanEncoder.EncodeBytesToFile(bytes, fileWriterMock.Object);

            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), It.IsAny<byte>()), Times.Exactly(bytes.Length));
        }
    }
}
