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
        private StatisticsGenerator statisticsGenerator;

        [TestInitialize]
        public void Setup()
        {
            statisticsGenerator = new StatisticsGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByteStatisticsFromBytesThrowsArgumentNullExceptionForNullBytes()
        {
            statisticsGenerator.GetByteStatisticsFromFile(null);
        }
    }
}
