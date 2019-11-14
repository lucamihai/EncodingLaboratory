﻿using System;
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
        private FileWriter fileWriter;
        private FileReader fileReader;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\{Constants.HuffmanDecodedFilePath}";

            CreateOriginalFile();

            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());

            var textAnalyzer = new TextAnalyzer();
            var huffmanHeaderWriter = new HuffmanHeaderWriter();
            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);

            var huffmanHeaderReader = new HuffmanHeaderReader();
            huffmanDecoder = new HuffmanDecoder(huffmanHeaderReader, huffmanEncodedBytesManager);

            fileWriter = new FileWriter(filePathEncodedFile, new Buffer());
            fileReader = new FileReader(filePathDecodedFile, new Buffer());
        }

        private void CreateOriginalFile()
        {
            File.WriteAllText(filePathDecodedFile, Constants.Text1);
        }

        [TestMethod]
        [Ignore("Endless loop")]
        public void FileIsEncodedThenDecodedCorrectly()
        {
            huffmanEncoder.EncodeTextToFile(Constants.Text1, fileWriter);
            var decodedText = huffmanDecoder.GetDecodedText(fileReader);

            fileReader.Dispose();
            fileWriter.Dispose();

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.Text1, decodedText).AreEqual);
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