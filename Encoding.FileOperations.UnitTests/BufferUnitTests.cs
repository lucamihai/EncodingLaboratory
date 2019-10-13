using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BufferUnitTests
    {
        [TestMethod]
        public void BufferIsInitializedWithValueSetToZero()
        {
            var buffer = new Buffer();

            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void BufferIsInitializedWithCurrentBitSetToZero()
        {
            var buffer = new Buffer();

            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitCallsOnCurrentBitResetDelegateForOverflow()
        {
            var currentBitResetDelegateHasBeenCalled = false;
            var buffer = new Buffer();
            buffer.OnCurrentBitReset += delegate (byte fromBuffer) { currentBitResetDelegateHasBeenCalled = true; };

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, 2);
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, 6);

            Assert.IsTrue(currentBitResetDelegateHasBeenCalled);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitDoesNotCallOnCurrentBitResetDelegateForIfThereIsNoOverflow()
        {
            var currentBitResetDelegateHasBeenCalled = false;
            var buffer = new Buffer();
            buffer.OnCurrentBitReset += delegate (byte fromBuffer) { currentBitResetDelegateHasBeenCalled = true; };

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, 2);

            Assert.IsFalse(currentBitResetDelegateHasBeenCalled);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsValueAsExpected1()
        {
            var buffer = new Buffer();
            var bufferInitialValue = buffer.Value;

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, 2);

            var expectedValue = bufferInitialValue + Constants.Value1;
            Assert.AreEqual(expectedValue, buffer.Value);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsValueAsExpected2()
        {
            var buffer = new Buffer();
            var bufferInitialValue = buffer.Value;

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, 2);
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, 4);

            var expectedValue = bufferInitialValue + Constants.Value1FollowedByValue2;
            Assert.AreEqual(expectedValue, buffer.Value);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsCurrentBitAsExpected1()
        {
            var buffer = new Buffer();
            var bufferInitialCurrentBit = buffer.CurrentBit;

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, Constants.Value1BitsRequired);

            var expectedCurrentBit = bufferInitialCurrentBit + Constants.Value1BitsRequired;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsCurrentBitAsExpected2()
        {
            var buffer = new Buffer();
            var bufferInitialCurrentBit = buffer.CurrentBit;

            buffer.AddValueStartingFromCurrentBit(Constants.Value1, Constants.Value1BitsRequired);
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, Constants.Value2BitsRequired);

            var expectedCurrentBit = bufferInitialCurrentBit + Constants.Value1BitsRequired + Constants.Value2BitsRequired;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsValueAsExpectedForOverflow()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(byte.MaxValue, 8);

            Assert.AreEqual(byte.MaxValue, buffer.Value);

            buffer.AddValueStartingFromCurrentBit(2, 2);

            Assert.AreEqual(byte.MaxValue - 1, buffer.Value);
        }

        [TestMethod]
        public void AddValueStartingFromCurrentBitSetsCurrentBitAsExpectedForOverflow()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(127, 7);

            Assert.AreEqual(7, buffer.CurrentBit);

            buffer.AddValueStartingFromCurrentBit(2, 2);

            Assert.AreEqual(1, buffer.CurrentBit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValueStartingFromCurrentBitThrowsArgumentExceptionForNumberOfBitsEqualToZero()
        {
            var buffer = new Buffer();
            buffer.GetValueStartingFromCurrentBit(0);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitCallsOnCurrentBitResetDelegateForCurrentBitExceedingLimit()
        {
            var currentBitResetDelegateHasBeenCalled = false;
            var buffer = new Buffer();
            buffer.OnCurrentBitReset += delegate (byte fromBuffer) { currentBitResetDelegateHasBeenCalled = true; };

            byte numberOfBitsToRead = 5;
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);

            Assert.IsTrue(currentBitResetDelegateHasBeenCalled);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitDoesNotCallOnCurrentBitResetDelegateIfCurrentBitDoesNotExceedLimit()
        {
            var currentBitResetDelegateHasBeenCalled = false;
            var buffer = new Buffer();
            buffer.OnCurrentBitReset += delegate (byte fromBuffer) { currentBitResetDelegateHasBeenCalled = true; };

            byte numberOfBitsToRead = 5;
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);

            Assert.IsFalse(currentBitResetDelegateHasBeenCalled);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitReturnsExpectedValue1()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(Constants.Value1, 2);
            buffer.CurrentBit = 0;

            var value = buffer.GetValueStartingFromCurrentBit(1);

            Assert.AreEqual(value, Constants.Value1OneBitFromBitZero);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitReturnsExpectedValue2()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, 4);
            buffer.CurrentBit = 1;

            var value = buffer.GetValueStartingFromCurrentBit(3);

            Assert.AreEqual(value, Constants.Value2ThreeBitsFromBitOne);
        }

        // TODO: Add Test for reading more than 8 bits (if it should be allowed)

        [TestMethod]
        public void GetValueStartingFromCurrentBitSetsCurrentBitAsExpected1()
        {
            var buffer = new Buffer();
            byte numberOfBitsToRead = 3;
            var initialCurrentBit = buffer.CurrentBit;
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);

            var expectedCurrentBit = initialCurrentBit + numberOfBitsToRead;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitSetsCurrentBitAsExpected2()
        {
            var buffer = new Buffer();
            byte numberOfBitsToRead = 3;
            var initialCurrentBit = buffer.CurrentBit;
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);

            var expectedCurrentBit = initialCurrentBit + numberOfBitsToRead + numberOfBitsToRead;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void GetValueStartingFromCurrentBitSetsCurrentBitAsExpectedForOverflow()
        {
            var buffer = new Buffer();
            byte numberOfBitsToRead = 3;
            var initialCurrentBit = buffer.CurrentBit;
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);
            buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead);

            var expectedCurrentBit = initialCurrentBit + numberOfBitsToRead + numberOfBitsToRead;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void FlushCallsOnCurrentBitResetDelegate()
        {
            var currentBitResetDelegateHasBeenCalled = false;
            var buffer = new Buffer();
            buffer.OnCurrentBitReset += delegate(byte fromBuffer) { currentBitResetDelegateHasBeenCalled = true; };

            buffer.Flush();

            Assert.IsTrue(currentBitResetDelegateHasBeenCalled);
        }

        [TestMethod]
        public void FlushSetsValueToZero()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, 4);

            Assert.AreNotEqual(0, buffer.Value);

            buffer.Flush();

            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void FlushSetsCurrentBitToZero()
        {
            var buffer = new Buffer();
            buffer.AddValueStartingFromCurrentBit(Constants.Value2, 4);

            Assert.AreNotEqual(0, buffer.CurrentBit);

            buffer.Flush();

            Assert.AreEqual(0, buffer.CurrentBit);
        }
    }
}
