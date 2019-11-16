using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;
using Encoding.Systems.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Systems.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncodedBytesManagerUnitTests
    {
        private Mock<IHuffmanNodesManager> huffmanNodesManagerMock;
        private HuffmanEncodedBytesManager huffmanEncodedBytesManager;

        [TestInitialize]
        public void Setup()
        {
            huffmanNodesManagerMock = new Mock<IHuffmanNodesManager>();
            huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(huffmanNodesManagerMock.Object);

            SetupHuffmanNodesManagerMock();
        }

        private void SetupHuffmanNodesManagerMock()
        {
            huffmanNodesManagerMock
                .Setup(x => x.GetNodeFromByteStatistics(It.IsAny<List<ByteStatistics>>()))
                .Returns(ConstantsEncodingSystems.ExpectedNodeForText1());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEncodedBytesFromByteStatisticsThrowsArgumentNullExceptionForNullList()
        {
            huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(null);
        }

        [TestMethod]
        public void GetEncodedBytesFromByteStatisticsCallsHuffmanNodesManagerGetNodeFromByteStatisticsOnce()
        {
            var characterStatistics = ConstantsEncodingSystems.TextCharacterStatistics1;

            huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(characterStatistics);

            huffmanNodesManagerMock.Verify(x=>x.GetNodeFromByteStatistics(characterStatistics), Times.Once);
        }

        [TestMethod]
        public void GetEncodedBytesFromByteStatisticsCallsHuffmanNodesManagerSetPathFromNodeToParentOnceForEachLeaf()
        {
            huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(ConstantsEncodingSystems.TextCharacterStatistics1);

            huffmanNodesManagerMock.Verify(x =>
                    x.SetPathFromNodeToParent(It.IsAny<List<bool>>(), It.IsAny<Node>(), It.IsAny<Node>(), It.IsAny<int>()),
                Times.Exactly(ConstantsEncodingSystems.NumberOfLeafs1));
        }

        [TestMethod]
        public void GetEncodedBytesFromByteStatisticsReturnsExpectedNumberOfEncodedBytes()
        {
            var returnedEncodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(ConstantsEncodingSystems.TextCharacterStatistics1);

            var comparer = new CompareLogic();
            comparer.Config.IgnoreProperty<EncodedByte>(x => x.EncodingBits);
            comparer.Config.IgnoreProperty<EncodedByte>(x => x.EncodedValue);
            Assert.IsTrue(comparer.Compare(ConstantsEncodingSystems.EncodedBytes1(), returnedEncodedBytes).AreEqual);
        }
    }
}