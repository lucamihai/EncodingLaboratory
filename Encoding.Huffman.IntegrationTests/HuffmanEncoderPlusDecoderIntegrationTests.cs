using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using Encoding.FileOperations;
using Encoding.Huffman.IntegrationTests.Properties;
using Encoding.Huffman.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Huffman.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderPlusDecoderIntegrationTests
    {
        private HuffmanEncoder huffmanEncoder;
        private HuffmanDecoder huffmanDecoder;
        private string filePathSource;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            filePathSource = $"{Environment.CurrentDirectory}\\temp.png";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.png.hs";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.hs.png";

            CreateInitialFile();

            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());

            var textAnalyzer = new StatisticsGenerator();
            var huffmanHeaderWriter = new HuffmanHeaderWriter();
            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);

            var huffmanHeaderReader = new HuffmanHeaderReader();
            huffmanDecoder = new HuffmanDecoder(huffmanHeaderReader, huffmanEncodedBytesManager);
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectly()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    huffmanEncoder.EncodeFile(fileReader, fileWriter);
                    fileWriter.Buffer.Flush();
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    huffmanDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathSource);
            TestMethods.DeleteFileIfExists(filePathEncodedFile);
            TestMethods.DeleteFileIfExists(filePathDecodedFile);
        }

        private void CreateInitialFile()
        {
            var img = new Bitmap(Resources.Capture);
            img.Save(filePathSource, ImageFormat.Png);
            img.Dispose();
        }
    }
}