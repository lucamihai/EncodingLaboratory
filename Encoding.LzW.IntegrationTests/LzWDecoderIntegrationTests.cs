using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.LzW.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWDecoderIntegrationTests
    {
        private LzWDecoder lzWDecoder;
        private string filePathFile;
        private string filePathEncodedFile;

        [TestInitialize]
        public void Setup()
        {
            filePathFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}.lzw";

            File.WriteAllBytes(filePathEncodedFile, Constants.EncodedFileBytes.ToArray());

            lzWDecoder = new LzWDecoder();
        }

        [TestMethod]
        public void DecodeFileWritesFileAsExpected()
        {
            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathFile, new Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            var bytes = File.ReadAllBytes(filePathFile);
            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.FileContentsBytes.ToArray(), bytes).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(filePathFile))
            {
                File.Delete(filePathFile);
            }

            if (File.Exists(filePathEncodedFile))
            {
                File.Delete(filePathEncodedFile);
            }
        }
    }
}