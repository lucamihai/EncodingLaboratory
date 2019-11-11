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
        private Mock<ITextAnalyzer> textAnalyzerMock;
        private Mock<IHuffmanEncodedBytesManager> huffmanEncodedBytesManagerMock;
        private Mock<IHuffmanHeaderWriter> huffmanHeaderWriterMock;
        private Mock<IFileWriter> fileWriterMock;
        private HuffmanEncoder huffmanEncoder;

        [TestInitialize]
        public void Setup()
        {
            textAnalyzerMock = new Mock<ITextAnalyzer>();
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
                .Setup(x => x.GetCharacterStatisticsFromText(ConstantsEncodingSystems.Text1))
                .Returns(ConstantsEncodingSystems.TextCharacterStatistics1);
        }

        private void SetupHuffmanEncodedBytesManagerMock()
        {
            huffmanEncodedBytesManagerMock
                .Setup(x => x.GetEncodedBytesFromCharacterStatistics(It.IsAny<List<CharacterStatistics>>()))
                .Returns(ConstantsEncodingSystems.EncodedBytes1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeTextToFileThrowsArgumentNullExceptionForNullText()
        {
            huffmanEncoder.EncodeTextToFile(null, fileWriterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeTextToFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            huffmanEncoder.EncodeTextToFile(ConstantsEncodingSystems.Text1, null);
        }

        [TestMethod]
        public void EncodeTextToFileCallsTextAnalyzerGetCharacterStatisticsFromTextWithTextFromParameterOnce()
        {
            huffmanEncoder.EncodeTextToFile(ConstantsEncodingSystems.Text1, fileWriterMock.Object);

            textAnalyzerMock.Verify(x => x.GetCharacterStatisticsFromText(ConstantsEncodingSystems.Text1), Times.Once);
        }

        [TestMethod]
        public void EncodeTextToFileCallsHuffmanEncodedBytesManagerMockGetEncodedBytesFromCharacterStatisticsOnce()
        {
            huffmanEncoder.EncodeTextToFile(ConstantsEncodingSystems.Text1, fileWriterMock.Object);

            huffmanEncodedBytesManagerMock.Verify(x => x.GetEncodedBytesFromCharacterStatistics(It.IsAny<List<CharacterStatistics>>()), Times.Once);
        }

        [TestMethod]
        public void EncodeTextToFileCallsHuffmanHeaderWriterSetPathFromNodeToParentOnceForEachLeaf()
        {
            huffmanEncoder.EncodeTextToFile(ConstantsEncodingSystems.Text1, fileWriterMock.Object);

            huffmanHeaderWriterMock.Verify(x=>x.WriteHeaderToFile(It.IsAny<List<CharacterStatistics>>(), fileWriterMock.Object), Times.Once);
        }

        [TestMethod]
        public void EncodeTextToFileCallsFileWriterWriteValueOnBitsForEachCharacterInText()
        {
            const string text = ConstantsEncodingSystems.Text1;

            huffmanEncoder.EncodeTextToFile(text, fileWriterMock.Object);

            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), It.IsAny<byte>()), Times.Exactly(text.Length));
        }
    }
}
