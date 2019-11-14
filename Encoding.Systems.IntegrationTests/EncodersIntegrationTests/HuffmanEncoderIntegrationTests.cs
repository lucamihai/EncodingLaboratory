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
        private string filePath;

        [TestInitialize]
        public void Setup()
        {
            filePath = $"{Environment.CurrentDirectory}\\{Constants.HuffmanEncodedFilePath}";

            var textAnalyzer = new TextAnalyzer();
            var huffmanEncodedBytesManager = new HuffmanEncodedBytesManager(new HuffmanNodesManager());
            var huffmanHeaderWriter = new HuffmanHeaderWriter();

            huffmanEncoder = new HuffmanEncoder(textAnalyzer, huffmanEncodedBytesManager, huffmanHeaderWriter);
        }

        [TestMethod]
        public void EncodeTextToFileCreatesFileWithExpectedContent()
        { 
            using (var fileWriter = new FileWriter(filePath, new Buffer()))
            {
                huffmanEncoder.EncodeTextToFile(Constants.Text1, fileWriter);
            }

            Assert.IsTrue(File.Exists(filePath));
        }

        //private bool TextIsValid()
        //{
            
        //}

        //private bool StatisticsFromTextAreValid(string text)
        //{
        //    var stringStatistics = text.Substring(0, 64);
        //    foreach (var character in stringStatistics)
        //    {
                
        //    }
        //}

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
