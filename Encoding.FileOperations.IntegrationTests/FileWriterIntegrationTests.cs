using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileWriterIntegrationTests
    {
        private FileWriter fileWriter;
        private string filePath;
        private IBuffer buffer;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.TestFileName}";
            buffer = new Buffer();

            var fileStreamCreate = File.Create(filePath);
            fileStreamCreate.Close();

            fileWriter = new FileWriter(filePath, buffer);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileWriter?.Dispose();

            TestMethods.DeleteFileIfExists(filePath);
        }

        [TestMethod]
        public void BufferIsInitializedWithValueSetToZero()
        {
            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void BufferIsInitializedWithCurrentBitSetToZero()
        {
            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void WriteBitAddsExpectedValueToBuffer1()
        {
            fileWriter.WriteBit(true);

            Assert.AreEqual(1, buffer.Value);
        }

        [TestMethod]
        public void WriteBitAddsExpectedValueToBuffer2()
        {
            fileWriter.WriteBit(false);

            Assert.AreEqual(0, buffer.Value);
        }

        [TestMethod]
        public void WriteBitAddsExpectedValueToBuffer3()
        {
            buffer.Value = 3;
            buffer.CurrentBit = 2;

            fileWriter.WriteBit(true);

            Assert.AreEqual(7, buffer.Value);
        }

        [TestMethod]
        public void WriteBitAddsExpectedValueToBuffer4()
        {
            buffer.Value = 3;
            buffer.CurrentBit = 2;

            fileWriter.WriteBit(false);

            Assert.AreEqual(3, buffer.Value);
        }

        [TestMethod]
        public void WriteBitDoesNotWriteByteToFileIfBufferCurrentBitIsLessThanSeven()
        {
            fileWriter.WriteBit(true);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(0, fileBytes.Length);
        }

        [TestMethod]
        public void WriteBitWritesByteToFileIfBufferCurrentBitIsSeven()
        {
            buffer.CurrentBit = 7;

            fileWriter.WriteBit(true);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(1, fileBytes.Length);
            const byte expectedWrittenByteValue = 128;
            Assert.AreEqual(expectedWrittenByteValue, fileBytes[0]);
        }

        [TestMethod]
        public void WriteBitIncreasesBufferCurrentBitByOne()
        {
            var bufferInitialCurrentBit = buffer.CurrentBit;

            fileWriter.WriteBit(true);

            Assert.AreEqual(bufferInitialCurrentBit + 1, buffer.CurrentBit);
        }

        [TestMethod]
        public void WriteBitResetsBufferCurrentBitIfCurrentBitIsSeven()
        {
            buffer.CurrentBit = 7;

            fileWriter.WriteBit(true);

            Assert.AreEqual(0, buffer.CurrentBit);
        }

        [TestMethod]
        public void WriteValueOnBitsAddsExpectedValueToBuffer1()
        {
            fileWriter.WriteValueOnBits(10, 4);

            Assert.AreEqual(Constants.ValueTenOnFourBits, buffer.Value);
        }

        [TestMethod]
        public void WriteValueOnBitsAddsExpectedValueToBuffer2()
        {
            fileWriter.WriteValueOnBits(10, 2);

            Assert.AreEqual(Constants.ValueTenOnTwoBits, buffer.Value);
        }

        [TestMethod]
        public void WriteValueOnBitsAddsExpectedValueToBuffer4()
        {
            buffer.CurrentBit = 1;

            fileWriter.WriteValueOnBits(10, 2);

            Assert.AreEqual(Constants.ValueTenOnTwoBits << 1, buffer.Value);
        }

        [TestMethod]
        public void WriteValueOnBitsDoesNotWriteByteToFileIfDoesNotCauseOverflow()
        {
            fileWriter.WriteValueOnBits(10, 4);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(0, fileBytes.Length);
        }

        [TestMethod]
        public void WriteValueOnBitsWritesByteToFileIfCausesOverflow()
        {
            buffer.CurrentBit = 5;

            fileWriter.WriteValueOnBits(10, 4);

            fileWriter.Dispose();
            var fileBytes = File.ReadAllBytes(filePath);
            Assert.AreEqual(1, fileBytes.Length);
            const byte expectedWrittenByteValue = 64;
            Assert.AreEqual(expectedWrittenByteValue, fileBytes[0]);
        }
    }
}
