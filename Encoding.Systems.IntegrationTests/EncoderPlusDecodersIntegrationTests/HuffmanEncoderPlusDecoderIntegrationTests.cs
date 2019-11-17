using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Encoding.FileOperations;
using Encoding.Systems.Decoders;
using Encoding.Systems.Encoders;
using Encoding.Systems.IntegrationTests.Properties;
using Encoding.Systems.Utilities;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Systems.IntegrationTests.EncoderPlusDecodersIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderPlusDecoderIntegrationTests
    {
        private HuffmanEncoder huffmanEncoder;
        private HuffmanDecoder huffmanDecoder;
        private string filePathEncodedFile;

        [TestInitialize]
        public void Setup()
        {
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";

            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());

            var textAnalyzer = new BytesAnalyzer();
            var huffmanHeaderWriter = new HuffmanHeaderWriter();
            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);

            var huffmanHeaderReader = new HuffmanHeaderReader();
            huffmanDecoder = new HuffmanDecoder(huffmanHeaderReader, huffmanEncodedBytesManager);
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly1()
        {
            var bytes = Constants.Bytes1();

            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytes, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytes, decodedBytes).AreEqual);
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly2()
        {
            var bytes = Constants.Bytes2();

            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytes, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytes, decodedBytes).AreEqual);
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly3()
        {
            var bytes = Constants.Bytes3();

            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytes, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytes, decodedBytes).AreEqual);
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly4()
        {
            var bytes = Constants.Bytes4();

            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytes, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytes, decodedBytes).AreEqual);
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectlyFromFile()
        {
            var bytes = Constants.Bytes4();
            var temporaryFilePath = $"{Environment.CurrentDirectory}\\temp.txt";
            File.WriteAllBytes(temporaryFilePath, bytes);
            var bytesFromFile = File.ReadAllBytes(temporaryFilePath);
            File.Delete(temporaryFilePath);

            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytesFromFile, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytesFromFile, decodedBytes).AreEqual);
        }

        [TestMethod]
        public void BytesFromImageAreEncodedThenDecodedCorrectly()
        {
            var temporaryFilePath = $"{Environment.CurrentDirectory}\\temp.png";
            var img = new Bitmap(Resources.Capture);
            img.Save(temporaryFilePath, ImageFormat.Png);
            img.Dispose();

            var bytesFromFile = File.ReadAllBytes(temporaryFilePath);
            using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytesFromFile, fileWriter);
                fileWriter.Buffer.Flush();
            }

            byte[] decodedBytes;
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                decodedBytes = huffmanDecoder.GetDecodedBytes(fileReader);
            }

            File.WriteAllBytes($"{Environment.CurrentDirectory}\\tempp.png", decodedBytes);
            File.Delete(temporaryFilePath);
            File.Delete($"{Environment.CurrentDirectory}\\tempp.png");

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytesFromFile, decodedBytes).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(filePathEncodedFile))
            {
                File.Delete(filePathEncodedFile);
            }
        }
    }
}