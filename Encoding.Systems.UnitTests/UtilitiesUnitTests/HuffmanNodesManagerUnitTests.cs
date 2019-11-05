using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.Systems.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Systems.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanNodesManagerUnitTests
    {
        private HuffmanNodesManager huffmanNodesManager;

        [TestInitialize]
        public void Setup()
        {
            huffmanNodesManager = new HuffmanNodesManager();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNodeFromCharacterStatisticsThrowsArgumentNullExceptionForNullCharacterStatistics()
        {
            huffmanNodesManager.GetNodeFromCharacterStatistics(null);
        }

        [TestMethod]
        public void GetNodeFromCharacterStatisticsReturnsExpectedNode()
        {
            var node = huffmanNodesManager.GetNodeFromCharacterStatistics(ConstantsEncodingSystems.TextCharacterStatistics1);

            var comparer = new CompareLogic();
            comparer.Config.IgnoreProperty<Node>(x => x.NodesInPreOrder);
            Assert.IsTrue(comparer.Compare(ConstantsEncodingSystems.ExpectedNodeForText1(), node).AreEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPathFromNodeToParentThrowsArgumentNullExceptionForNullPath()
        {
            huffmanNodesManager.SetPathFromNodeToParent(null, new Node(), new Node(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetPathFromNodeToParentThrowsArgumentExceptionForNotEmptyPath()
        {
            huffmanNodesManager.SetPathFromNodeToParent(new List<bool> {true}, new Node(), new Node(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPathFromNodeToParentThrowsArgumentNullExceptionForNullNode()
        {
            huffmanNodesManager.SetPathFromNodeToParent(new List<bool>(), null, new Node(), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPathFromNodeToParentThrowsArgumentNullExceptionForNullParent()
        {
            huffmanNodesManager.SetPathFromNodeToParent(new List<bool>(), new Node(), null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetPathFromNodeToParentThrowsArgumentExceptionIfNodeAndParentAreTheSameEntity()
        {
            var node = new Node();

            huffmanNodesManager.SetPathFromNodeToParent(new List<bool>(), node, node, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetPathFromNodeToParentThrowsArgumentExceptionForMaxNodesToClimbSmallerThanOne()
        {
            huffmanNodesManager.SetPathFromNodeToParent(new List<bool>(), new Node(), new Node(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetPathFromNodeToParentThrowsInvalidOperationExceptionIfPathIsNotFoundInMaxNodesToClimbSteps()
        {
            var huffmanTreeRoot = ConstantsEncodingSystems.ExpectedNodeForText1();

            huffmanNodesManager.SetPathFromNodeToParent(new List<bool>(),  huffmanTreeRoot.RightChild.RightChild.RightChild, huffmanTreeRoot, 2);
        }

        [TestMethod]
        public void SetPathFromNodeToParentSetsPathContentsAsExpected1()
        {
            var huffmanTreeRoot = ConstantsEncodingSystems.ExpectedNodeForText1();
            var generatedPath = new List<bool>();

            huffmanNodesManager.SetPathFromNodeToParent(generatedPath, huffmanTreeRoot.RightChild.RightChild.RightChild, huffmanTreeRoot, 10);

            var expectedPath = new List<bool> {true, true, true};
            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(expectedPath, generatedPath).AreEqual);
        }

        [TestMethod]
        public void SetPathFromNodeToParentSetsPathContentsAsExpected2()
        {
            var huffmanTreeRoot = ConstantsEncodingSystems.ExpectedNodeForText1();
            var generatedPath = new List<bool>();

            huffmanNodesManager.SetPathFromNodeToParent(generatedPath, huffmanTreeRoot.RightChild.RightChild.LeftChild.RightChild, huffmanTreeRoot, 10);

            var expectedPath = new List<bool> { true, true, false, true };
            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(expectedPath, generatedPath).AreEqual);
        }
    }
}
