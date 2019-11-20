using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.Huffman.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Huffman.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BytesAnalyzerUnitTests
    {
        private BytesAnalyzer bytesAnalyzer;

        [TestInitialize]
        public void Setup()
        {
            bytesAnalyzer = new BytesAnalyzer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByteStatisticsFromBytesThrowsArgumentNullExceptionForNullBytes()
        {
            bytesAnalyzer.GetByteStatisticsFromBytes(null);
        }

        [TestMethod]
        public void GetByteStatisticsFromBytesReturnsExpectedList()
        {
            var characterStatistics = bytesAnalyzer.GetByteStatisticsFromBytes(ConstantsEncodingSystems.Bytes1());

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(ConstantsEncodingSystems.TextCharacterStatistics1, characterStatistics).AreEqual);
        }
    }
}
