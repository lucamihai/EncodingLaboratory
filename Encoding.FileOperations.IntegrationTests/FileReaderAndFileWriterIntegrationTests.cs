using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        private string filePathSource;
        private string filePathDestination;
        private long originalFileSizeInBytes;

        [TestInitialize]
        public void Setup()
        {
            filePathSource = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filePathDestination = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";

            TestMethods.CreateFileFromPngImage(filePathSource, Resources.testImage);

            originalFileSizeInBytes = new FileInfo(filePathSource).Length;
        }

        [TestMethod]
        public void FileIsCopiedCorrectlyForNumberOfBitsBetween1And8()
        {
            var stopWatch = new Stopwatch();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDestination, new Buffer()))
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

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDestination));
        }

        [TestMethod]
        public void FileIsCopiedCorrectlyForNumberOfBitsBetween8And32()
        {
            var stopWatch = new Stopwatch();
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDestination, new Buffer()))
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

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDestination));
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathSource);
            TestMethods.DeleteFileIfExists(filePathDestination);
        }
    }
}