using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Utilities;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Lz77.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77TokenExtractorUnitTests
    {
        private Lz77TokenExtractor lz77TokenExtractor;

        [TestInitialize]
        public void Setup()
        {
            lz77TokenExtractor = new Lz77TokenExtractor();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetLz77TokenFromLz77BufferThrowsArgumentNullExceptionForNullLz77Buffer()
        {
            lz77TokenExtractor.GetLz77TokenFromLz77Buffer(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLz77TokenFromLz77BufferThrowsArgumentExceptionForLz77BufferWithEmptyLookAheadBuffer()
        {
            lz77TokenExtractor.GetLz77TokenFromLz77Buffer(new Lz77Buffer(2, 2));
        }

        [TestMethod]
        public void GetLz77TokenFromLz77BufferReturnsExpectedLz77Token1()
        {
            var returnedLz77Token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(Constants.GetLz77Buffer1());

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.ExpectedTokenForLz77Buffer1(), returnedLz77Token).AreEqual);
        }

        [TestMethod]
        public void GetLz77TokenFromLz77BufferReturnsExpectedLz77Token2()
        {
            var returnedLz77Token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(Constants.GetLz77Buffer2());

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.ExpectedTokenForLz77Buffer2(), returnedLz77Token).AreEqual);
        }

        [TestMethod]
        public void GetLz77TokenFromLz77BufferReturnsExpectedLz77Token3()
        {
            var returnedLz77Token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(Constants.GetLz77Buffer3());

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.ExpectedTokenForLz77Buffer3(), returnedLz77Token).AreEqual);
        }
    }
}