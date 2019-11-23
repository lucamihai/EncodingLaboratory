using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Encoding.FileOperations.IntegrationTests.Properties;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderAndFileWriterIntegrationTests
    {
        private string filePathOriginalImage;
        private string filePathFinalImage;
        private long originalFileSizeInBytes;

        [TestInitialize]
        public void Setup()
        {
            filePathOriginalImage = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filePathFinalImage = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";

            CreateOriginalImageFile();

            originalFileSizeInBytes = new FileInfo(filePathOriginalImage).Length;
        }

        private void CreateOriginalImageFile()
        {
            var img = new Bitmap(Resources.testImage);
            img.Save(filePathOriginalImage, ImageFormat.Png);
            img.Dispose();
        }

        [TestMethod]
        public void FileIsCopiedCorrectlyForNumberOfBitsBetween1And8()
        {
            var stopWatch = new Stopwatch();
            
            using (var fileReader = new FileReader(filePathOriginalImage, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathFinalImage, new Buffer()))
                {
                    stopWatch.Start();

                    while (!fileReader.ReachedEndOfFile)
                    {
                        var random = new Random();
                        var numberOfBits = fileReader.BitsLeft < 8
                            ? (byte)fileReader.BitsLeft
                            : (byte)random.Next(1, 8);

                        var readStuff = fileReader.ReadBits(numberOfBits);
                        fileWriter.WriteValueOnBits(readStuff, numberOfBits);
                    }

                    stopWatch.Stop();
                }
            }

            Console.WriteLine($"File copying in '{TestMethods.GetCurrentMethodName()}' took {stopWatch.ElapsedMilliseconds} ms for {originalFileSizeInBytes} bytes");

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathOriginalImage, filePathFinalImage));
        }

        [TestMethod]
        public void FileIsCopiedCorrectlyForNumberOfBitsBetween8And32()
        {
            var stopWatch = new Stopwatch();
            using (var fileReader = new FileReader(filePathOriginalImage, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathFinalImage, new Buffer()))
                {
                    stopWatch.Start();

                    while (!fileReader.ReachedEndOfFile)
                    {
                        var random = new Random();
                        var numberOfBits = fileReader.BitsLeft < 32
                            ? (byte)fileReader.BitsLeft
                            : (byte)random.Next(8, 32);

                        var readStuff = fileReader.ReadBits(numberOfBits);

                        fileWriter.WriteValueOnBits(readStuff, numberOfBits);
                    }

                    stopWatch.Stop();
                }
            }
            Console.WriteLine($"File copying in '{TestMethods.GetCurrentMethodName()}' took {stopWatch.ElapsedMilliseconds} ms for {originalFileSizeInBytes} bytes");

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathOriginalImage, filePathFinalImage));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathOriginalImage);
            TestMethods.DeleteFileIfExists(filePathFinalImage);
        }
    }
}