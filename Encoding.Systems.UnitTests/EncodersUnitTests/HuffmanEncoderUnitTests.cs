using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.Systems.Encoders;
using Encoding.Systems.Interfaces.Utilities;
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
        private HuffmanEncoder huffmanEncoder;

        [TestInitialize]
        public void Setup()
        {
            textAnalyzerMock = new Mock<ITextAnalyzer>();
            huffmanEncoder = new HuffmanEncoder(textAnalyzerMock.Object);

            SetupTextAnalyzerMock();
        }

        private void SetupTextAnalyzerMock()
        {
            textAnalyzerMock
                .Setup(x => x.GetCharacterStatisticsFromText(Constants.Text1))
                .Returns(Constants.TextCharacterStatistics1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNodesForTextThrowsArgumentNullExceptionForNullText()
        {
            huffmanEncoder.GetNodesForText(null);
        }

        [TestMethod]
        public void GetNodesForTextCallsTextAnalyzerGetCharacterStatisticsFromTextWithTextFromParameterOnce()
        {
            huffmanEncoder.GetNodesForText(Constants.Text1);

            textAnalyzerMock.Verify(x => x.GetCharacterStatisticsFromText(Constants.Text1), Times.Once);
        }

        [TestMethod]
        public void GetNodesForTextReturnsExpectedNode()
        {
            var node = huffmanEncoder.GetNodesForText(Constants.Text1);

            var comparer = new CompareLogic();
            comparer.Config.IgnoreProperty<Node>(x => x.Parent);
            comparer.Config.IgnoreProperty<Node>(x => x.NodesInPreOrder);
            Assert.IsTrue(comparer.Compare(Constants.ExpectedNodeForText1, node).AreEqual);
        }
    }
}
