using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderIntegrationTests
    {
        private FileReader fileReader;
        private string filePath;
        private IBuffer buffer;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            buffer = new Buffer();

            TestMethods.CreateFileWithGivenBytes(filePath, Constants.TestBytes);

            fileReader = new FileReader(filePath, buffer);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileReader?.Dispose();

            TestMethods.DeleteFileIfExists(filePath);
        }

        [TestMethod]
        public void BufferIsInitializedWithFirstByteFromFile()
        {
            Assert.AreEqual(Constants.TestBytes[0], buffer.Value);
        }

        [TestMethod]
        public void BufferIsInitializedWithCurrentBitSetToZero()
        {
            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void ReadBitReturnsExpectedValue1()
        {
            var bitValue = fileReader.ReadBit();

            Assert.IsTrue(bitValue);
        }

        [TestMethod]
        public void ReadBitReturnsExpectedValue2()
        {
            buffer.CurrentBit = 2;

            var bitValue = fileReader.ReadBit();

            Assert.IsFalse(bitValue);
        }

        [TestMethod]
        public void ReadBitIncreasesBufferCurrentBitByOne()
        {
            var bufferCurrentBitInitialValue = buffer.CurrentBit;

            fileReader.ReadBit();

            Assert.AreEqual(bufferCurrentBitInitialValue + 1, buffer.CurrentBit);
        }

        [TestMethod]
        public void ReadBitResetsBufferCurrentBitIfCurrentBitIsEqualTo7()
        {
            buffer.CurrentBit = 7;

            fileReader.ReadBit();

            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void ReadBitChangesBufferValueToNextByteFromFileIfCurrentBitIsEqualTo7()
        {
            buffer.CurrentBit = 7;

            fileReader.ReadBit();

            Assert.AreEqual(Constants.TestBytes[1], buffer.Value);
        }

        [TestMethod]
        public void ReadBitsReturnsExpectedValue()
        {
            var value = fileReader.ReadBits(3);

            Assert.AreEqual(Constants.ValueFromFirstByteBits012, value);
        }

        [TestMethod]
        public void ReadBitsReturnsExpectedValueForOverflow()
        {
            buffer.CurrentBit = 6;

            var value = fileReader.ReadBits(5);

            Assert.AreEqual(Constants.ValueFromFirstByteBits78FollowedBySecondByteBits012, value);
        }

        [TestMethod]
        public void ReadBitsIncreasesBufferCurrentBitByNumberOfBitsFromParameter()
        {
            var bufferCurrentBitInitialValue = buffer.CurrentBit;
            const byte numberOfBitsToRead = 4;

            fileReader.ReadBits(numberOfBitsToRead);

            var expectedCurrentBit = bufferCurrentBitInitialValue + numberOfBitsToRead;
            Assert.AreEqual(expectedCurrentBit, buffer.CurrentBit);
        }

        [TestMethod]
        public void ReadBitsSetsCurrentBitValueAsExpectedForOverflow()
        {
            const byte numberOfBitsToRead = 5;

            fileReader.ReadBits(numberOfBitsToRead);
            fileReader.ReadBits(numberOfBitsToRead);

            Assert.AreEqual(2, buffer.CurrentBit);
        }

        [TestMethod]
        public void ReadBitsSetsValueAsExpectedForOverflow()
        {
            const byte numberOfBitsToRead = 5;

            fileReader.ReadBits(numberOfBitsToRead);
            fileReader.ReadBits(numberOfBitsToRead);

            Assert.AreEqual(Constants.TestBytes[1], buffer.Value);
        }
    }
}
