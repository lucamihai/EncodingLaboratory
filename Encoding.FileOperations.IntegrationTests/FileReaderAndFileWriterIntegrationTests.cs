using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using Encoding.FileOperations.IntegrationTests.Properties;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileReaderAndFileWriterIntegrationTests
    {
        private FileReader fileReader;
        private FileWriter fileWriter;
        private string filePathOriginalImage;
        private string filePathFinalImage;
        private byte[] bytesInOriginalImage;

        [TestInitialize]
        public void Setup()
        {
            filePathOriginalImage = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImage}";
            filePathFinalImage = $"{Environment.CurrentDirectory}\\{Constants.TestFileNameImageDestination}";

            CreateOriginalImageFile();
            bytesInOriginalImage = File.ReadAllBytes(filePathOriginalImage);

            fileReader = new FileReader(filePathOriginalImage, new Buffer());
            fileWriter = new FileWriter(filePathFinalImage, new Buffer());
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
            stopWatch.Start();

            var bitsRead = 0;
            while (bitsRead < bytesInOriginalImage.Length * 8)
            {
                var random = new Random();
                var numberOfBits = (byte)random.Next(1, 8);

                var readStuff = fileReader.ReadBits(numberOfBits);

                fileWriter.WriteValueOnBits(readStuff, numberOfBits);

                bitsRead += numberOfBits;
            }

            stopWatch.Stop();
            Console.WriteLine($"File copying in '{GetCurrentMethod()}' took {stopWatch.ElapsedMilliseconds} ms for {bytesInOriginalImage.Length} bytes");

            fileReader.Dispose();
            fileWriter.Dispose();

            var bytesInFinalImage = File.ReadAllBytes(filePathFinalImage);
            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytesInOriginalImage, bytesInFinalImage).AreEqual);
        }

        [TestMethod]
        public void FileIsCopiedCorrectlyForNumberOfBitsBetween8And32()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var bitsRead = 0;
            while (bitsRead < bytesInOriginalImage.Length * 8)
            {
                var random = new Random();
                var numberOfBits = (byte)random.Next(8, 32);

                var readStuff = fileReader.ReadBits(numberOfBits);

                fileWriter.WriteValueOnBits(readStuff, numberOfBits);

                bitsRead += numberOfBits;
            }

            stopWatch.Stop();
            Console.WriteLine($"File copying in '{GetCurrentMethod()}' took {stopWatch.ElapsedMilliseconds} ms for {bytesInOriginalImage.Length} bytes");

            fileReader.Dispose();
            fileWriter.Dispose();

            var bytesInFinalImage = File.ReadAllBytes(filePathFinalImage);
            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(bytesInOriginalImage, bytesInFinalImage).AreEqual);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        [TestCleanup]
        public void Cleanup()
        {
            fileReader.Dispose();
            fileWriter.Dispose();

            if (File.Exists(filePathOriginalImage))
            {
                File.Delete(filePathOriginalImage);
            }

            if (File.Exists(filePathFinalImage))
            {
                File.Delete(filePathFinalImage);
            }
        }
    }
}