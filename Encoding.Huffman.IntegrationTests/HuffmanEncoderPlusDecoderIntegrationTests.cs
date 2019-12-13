using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Huffman.IntegrationTests.Properties;
using Encoding.Huffman.Interfaces;
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
            var dependencyResolver = new DependencyResolver();
            huffmanEncoder = (HuffmanEncoder)dependencyResolver.GetObject<IHuffmanEncoder>();
            huffmanDecoder = (HuffmanDecoder)dependencyResolver.GetObject<IHuffmanDecoder>();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.png";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.png.hs";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.hs.png";

            TestMethods.CreateFileFromPngImage(filePathSource, Resources.Capture);
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
    }
}