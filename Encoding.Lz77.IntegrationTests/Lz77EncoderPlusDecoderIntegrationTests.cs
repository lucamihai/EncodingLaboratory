using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Lz77.IntegrationTests.Properties;
using Encoding.Lz77.Interfaces;
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
            var dependencyResolver = new DependencyResolver();
            lz77Encoder = (Lz77Encoder)dependencyResolver.GetObject<ILz77Encoder>();
            lz77Decoder = (Lz77Decoder)dependencyResolver.GetObject<ILz77Decoder>();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.bmp";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.bmp.lz77";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.lz77.bmp";
        }

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly1()
        {
            TestMethods.CreateFileWithTextContents(filePathSource, Constants.FileContents);

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

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly2()
        {
            TestMethods.CreateFileWithTextContents(filePathSource, Resources.Text1);

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

        [TestMethod]
        public void FileIsEncodedThenDecodedCorrectly3()
        {
            TestMethods.CreateBmpFileFromImage(filePathSource, Resources.capture);

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