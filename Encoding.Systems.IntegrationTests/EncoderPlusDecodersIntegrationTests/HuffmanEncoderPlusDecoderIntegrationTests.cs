using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations;
using Encoding.Systems.Decoders;
using Encoding.Systems.Encoders;
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
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\{Constants.HuffmanDecodedFilePath}";

            CreateOriginalFile();

            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());

            var textAnalyzer = new BytesAnalyzer();
            var huffmanHeaderWriter = new HuffmanHeaderWriter();
            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);

            var huffmanHeaderReader = new HuffmanHeaderReader();
            huffmanDecoder = new HuffmanDecoder(huffmanHeaderReader, huffmanEncodedBytesManager);
        }

        private void CreateOriginalFile()
        {
            File.WriteAllText(filePathDecodedFile, Constants.Text1);
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

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(filePathEncodedFile))
            {
                File.Delete(filePathEncodedFile);
            }

            if (File.Exists(filePathDecodedFile))
            {
                File.Delete(filePathDecodedFile);
            }
        }
    }
}