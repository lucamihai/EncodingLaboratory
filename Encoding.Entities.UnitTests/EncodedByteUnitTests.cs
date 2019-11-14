﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Entities.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EncodedByteUnitTests
    {
        private EncodedByte encodedByte;

        [TestInitialize]
        public void Setup()
        {
            encodedByte = new EncodedByte();
        }

        [TestMethod]
        public void EncodedValueReturnsExpectedValue1()
        {
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(false);
            encodedByte.EncodingBits.Add(false);

            Assert.AreEqual((uint)1, encodedByte.EncodedValue);
        }

        [TestMethod]
        public void EncodedValueReturnsExpectedValue2()
        {
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(false);
            encodedByte.EncodingBits.Add(false);

            Assert.AreEqual((uint)3, encodedByte.EncodedValue);
        }

        [TestMethod]
        public void EncodedValueReturnsExpectedValue3()
        {
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(false);
            encodedByte.EncodingBits.Add(false);
            encodedByte.EncodingBits.Add(true);

            Assert.AreEqual((uint)9, encodedByte.EncodedValue);
        }

        [TestMethod]
        public void EncodedValueReturnsExpectedValue4()
        {
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(true);
            encodedByte.EncodingBits.Add(true);

            Assert.AreEqual((uint)15, encodedByte.EncodedValue);
        }
    }
}