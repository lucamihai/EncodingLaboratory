using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations;
using Encoding.Systems.Encoders;
using Encoding.Systems.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Systems.IntegrationTests.EncodersIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanEncoderIntegrationTests
    {
        private HuffmanEncoder huffmanEncoder;
        private FileWriter fileWriter;
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";

            var textAnalyzer = new TextAnalyzer();
            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());
            var huffmanHeaderWriter = new HuffmanHeaderWriter();

            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);

            fileWriter = new FileWriter(filePath, new Buffer());
        }

        [TestMethod]
        public void EncodeTextToFileCreatesFile()
        {
            huffmanEncoder.EncodeTextToFile(Constants.Text1, fileWriter);

            fileWriter.Dispose();

            Assert.IsTrue(File.Exists(filePath));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
