using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.Lz77.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Lz77.UnitTests.EntitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77BufferUnitTests
    {
        private const int offset = 2;
        private const int length = 3;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForOffsetSmallerThanOne()
        {
            var lz77Buffer = new Lz77Buffer(0, length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForLengthSmallerThanOne()
        {
            var lz77Buffer = new Lz77Buffer(offset, -2);
        }

        [TestMethod]
        public void ConstructorSetsOffsetPropertyAsExpected()
        {
            var lz77Buffer = new Lz77Buffer(offset, length);

            Assert.AreEqual(offset, lz77Buffer.Offset);
        }

        [TestMethod]
        public void ConstructorSetsLengthPropertyAsExpected()
        {
            var lz77Buffer = new Lz77Buffer(offset, length);

            Assert.AreEqual(length, lz77Buffer.Length);
        }

        [TestMethod]
        public void ConstructorSetsSearchBufferAsExpected()
        {
            var lz77Buffer = new Lz77Buffer(offset, length);

            var searchBuffer = lz77Buffer.SearchBuffer;
            Assert.IsNotNull(searchBuffer);
            Assert.AreEqual(0, searchBuffer.Count);
            Assert.AreEqual(Math.Pow(2, offset) - 1, searchBuffer.Capacity);
        }

        [TestMethod]
        public void ConstructorSetsLookAheadBufferAsExpected()
        {
            var lz77Buffer = new Lz77Buffer(offset, length);

            var lookAheadBuffer = lz77Buffer.LookAheadBuffer;
            Assert.IsNotNull(lookAheadBuffer);
            Assert.AreEqual(0, lookAheadBuffer.Count);
            Assert.AreEqual(Math.Pow(2, length) - 1, lookAheadBuffer.Capacity);
        }
    }
}