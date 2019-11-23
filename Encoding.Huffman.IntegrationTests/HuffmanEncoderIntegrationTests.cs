using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations;
using Encoding.Huffman.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Huffman.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderIntegrationTests
    {
        private HuffmanEncoder huffmanEncoder;
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";

            var textAnalyzer = new BytesAnalyzer();
            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());
            var huffmanHeaderWriter = new HuffmanHeaderWriter();

            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);
        }

        [TestMethod]
        public void EncodeBytesToFileCreatesFileWithExpectedContent()
        {
            var bytes = System.Text.Encoding.ASCII.GetBytes(Constants.Text1);

            using (var fileWriter = new FileWriter(filePath, new Buffer()))
            {
                huffmanEncoder.EncodeBytesToFile(bytes, fileWriter);
            }

            Assert.IsTrue(File.Exists(filePath));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePath);
        }
    }
}
