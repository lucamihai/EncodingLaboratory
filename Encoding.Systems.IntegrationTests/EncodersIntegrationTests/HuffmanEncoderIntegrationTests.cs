using System.Diagnostics.CodeAnalysis;
using Encoding.Systems.Encoders;
using Encoding.Systems.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Systems.IntegrationTests.EncodersIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderIntegrationTests
    {
        [TestMethod]
        public void GetEncodedBytesForTextReturnsExpectedEncodedBytes()
        {
            var huffmanEncoder = new HuffmanEncoder(new TextAnalyzer(), new HuffmanNodesManager());

            var returnedEncodedBytes = huffmanEncoder.GetEncodedBytesForText(ConstantsEncodingSystems.Text1);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(ConstantsEncodingSystems.EncodedBytes1(), returnedEncodedBytes).AreEqual);
        }
    }
}
