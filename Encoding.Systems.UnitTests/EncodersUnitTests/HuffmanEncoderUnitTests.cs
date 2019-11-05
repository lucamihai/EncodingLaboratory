using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.Systems.Encoders;
using Encoding.Systems.Interfaces.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Systems.UnitTests.EncodersUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderUnitTests
    {
        private Mock<ITextAnalyzer> textAnalyzerMock;
        private Mock<IHuffmanNodesManager> huffmanNodesManagerMock;
        private HuffmanEncoder huffmanEncoder;

        [TestInitialize]
        public void Setup()
        {
            textAnalyzerMock = new Mock<ITextAnalyzer>();
            huffmanNodesManagerMock = new Mock<IHuffmanNodesManager>();
            huffmanEncoder = new HuffmanEncoder(textAnalyzerMock.Object, huffmanNodesManagerMock.Object);

            SetupTextAnalyzerMock();
            SetupHuffmanNodesGeneratorMock();
        }

        private void SetupTextAnalyzerMock()
        {
            textAnalyzerMock
                .Setup(x => x.GetCharacterStatisticsFromText(ConstantsEncodingSystems.Text1))
                .Returns(ConstantsEncodingSystems.TextCharacterStatistics1);
        }

        private void SetupHuffmanNodesGeneratorMock()
        {
            huffmanNodesManagerMock
                .Setup(x => x.GetNodeFromCharacterStatistics(It.IsAny<List<CharacterStatistics>>()))
                .Returns(ConstantsEncodingSystems.ExpectedNodeForText1());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNodesForTextThrowsArgumentNullExceptionForNullText()
        {
            huffmanEncoder.GetEncodedBytesForText(null);
        }

        [TestMethod]
        public void GetNodesForTextCallsTextAnalyzerGetCharacterStatisticsFromTextWithTextFromParameterOnce()
        {
            huffmanEncoder.GetEncodedBytesForText(ConstantsEncodingSystems.Text1);

            textAnalyzerMock.Verify(x => x.GetCharacterStatisticsFromText(ConstantsEncodingSystems.Text1), Times.Once);
        }

        [TestMethod]
        public void GetNodesForTextCallsHuffmanNodesManagerGetNodeFromCharacterStatisticsOnce()
        {
            huffmanEncoder.GetEncodedBytesForText(ConstantsEncodingSystems.Text1);

            huffmanNodesManagerMock.Verify(x => x.GetNodeFromCharacterStatistics(It.IsAny<List<CharacterStatistics>>()), Times.Once);
        }

        [TestMethod]
        public void GetNodesForTextCallsHuffmanNodesManagerSetPathFromNodeToParentOnceForEachLeaf()
        {
            huffmanEncoder.GetEncodedBytesForText(ConstantsEncodingSystems.Text1);

            huffmanNodesManagerMock.Verify(x => 
                x.SetPathFromNodeToParent(It.IsAny<List<bool>>(), It.IsAny<Node>(), It.IsAny<Node>(), It.IsAny<int>()), 
                Times.Exactly(ConstantsEncodingSystems.NumberOfLeafs1));
        }

        [TestMethod]
        public void GetEncodedBytesForTextReturnsExpectedNumberOfEncodedBytes()
        {
            var returnedEncodedBytes = huffmanEncoder.GetEncodedBytesForText(ConstantsEncodingSystems.Text1);

            var comparer = new CompareLogic();
            comparer.Config.IgnoreProperty<EncodedByte>(x => x.EncodingBits);
            Assert.IsTrue(comparer.Compare(ConstantsEncodingSystems.EncodedBytes1(), returnedEncodedBytes).AreEqual);
        }
    }
}
