using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations;
using Encoding.Lz77.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Lz77.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77EncoderPlusDecoderIntegrationTests
    {
        private Lz77Encoder lz77Encoder;
        private Lz77Decoder lz77Decoder;
        private string filePathSource;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            lz77Encoder = new Lz77Encoder(new Lz77TokenExtractor(), new Lz77BufferManager(), new Lz77TokenWriter());
            lz77Decoder = new Lz77Decoder();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.png";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.png.lz77";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.lz77.png";
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly1()
        {
            File.WriteAllText(filePathSource, Constants.FileContents);

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lz77Encoder.EncodeFile(fileReader, fileWriter, Constants.BitsForOffset1, Constants.BitsForLength1);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    lz77Decoder.DecodeFile(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }


        [TestCleanup]
        public void TestCleanup()
        {
            TestMethods.DeleteFileIfExists(filePathSource);
            TestMethods.DeleteFileIfExists(filePathEncodedFile);
            TestMethods.DeleteFileIfExists(filePathDecodedFile);
        }
    }
}