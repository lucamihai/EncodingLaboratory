using System.Diagnostics.CodeAnalysis;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Entities.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NodeUnitTests
    {
        [TestMethod]
        public void NodeIsInitializedWithParentSetToNull()
        {
            var node = new Node();

            Assert.IsNull(node.Parent);
        }

        [TestMethod]
        public void NodeIsInitializedWithChildrenSetToNull()
        {
            var node = new Node();

            Assert.IsNull(node.LeftChild);
            Assert.IsNull(node.RightChild);
        }

        [TestMethod]
        public void IsParentReturnsFalseIfLeftChildAndRightChildAreBothNull()
        {
            var node = new Node
            {
                LeftChild = null,
                RightChild = null
            };

            Assert.IsFalse(node.IsParent);
        }

        [TestMethod]
        public void IsParentReturnsTrueIfLeftChildIsNotNullAndRightChildIsNull()
        {
            var node = new Node
            {
                LeftChild = new Node(), 
                RightChild = null
            };

            Assert.IsTrue(node.IsParent);
        }

        [TestMethod]
        public void IsParentReturnsTrueIfLeftChildIsNullAndRightChildIsNotNull()
        {
            var node = new Node
            {
                LeftChild = null,
                RightChild = new Node()
            };

            Assert.IsTrue(node.IsParent);
        }

        [TestMethod]
        public void IsParentReturnsTrueIfLeftChildAndRightChildAreBothNotNull()
        {
            var node = new Node
            {
                LeftChild = new Node(),
                RightChild = new Node()
            };

            Assert.IsTrue(node.IsParent);
        }

        [TestMethod]
        public void NodesInPreOrderReturnsExpectedList()
        {
            var returnedNodesInPreOrder = Constants.Node1.NodesInPreOrder;

            var comparer = new CompareLogic();
            comparer.Config.IgnoreProperty<Node>(x => x.Parent);
            comparer.Config.IgnoreProperty<Node>(x => x.NodesInPreOrder);
            Assert.IsTrue(comparer.Compare(Constants.NodesInPreOrder1, returnedNodesInPreOrder).AreEqual);
        }
    }
}
