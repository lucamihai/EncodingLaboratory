using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Entities.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NodeInfoUnitTests
    {
        private NodeInfo nodeInfo;

        [TestInitialize]
        public void Setup()
        {
            nodeInfo = new NodeInfo
            {
                NumericValue = 3,
                Code = 97
            };
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueSmallerThanOtherNodeInfoNumericValue()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue + 4,
                Code = nodeInfo.Code
            };

            Assert.AreEqual(-1, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueBiggerThanOtherNodeInfoNumericValue()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue - 4,
                Code = nodeInfo.Code
            };

            Assert.AreEqual(1, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueEqualToOtherNodeInfoNumericValueIfOwnCodeDoesNotHaveValue()
        {
            nodeInfo.Code = null;
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue,
                Code = nodeInfo.Code
            };

            Assert.AreEqual(0, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueEqualToOtherNodeInfoNumericValueIfOtherNodeCodeDoesNotHaveValue()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue,
                Code = null
            };

            Assert.AreEqual(0, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueEqualToOtherNodeInfoNumericValueIfOwnCodeIsSmallerThanOtherNodeCode()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue,
                Code = (byte)(nodeInfo.Code.Value + 1)
            };

            Assert.AreEqual(-1, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueEqualToOtherNodeInfoNumericValueIfOwnCodeIsBiggerThanOtherNodeCode()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue,
                Code = (byte)(nodeInfo.Code.Value - 1)
            };

            Assert.AreEqual(1, nodeInfo.CompareTo(otherNodeInfo));
        }

        [TestMethod]
        public void CompareToReturnsExpectedValueForNumericValueEqualToOtherNodeInfoNumericValueIfOwnCodeIsEqualToOtherNodeCode()
        {
            var otherNodeInfo = new NodeInfo
            {
                NumericValue = nodeInfo.NumericValue,
                Code = nodeInfo.Code
            };

            Assert.AreEqual(0, nodeInfo.CompareTo(otherNodeInfo));
        }
    }
}
