using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.LzW.Interfaces;
using Encoding.Tests.Common;
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
            var dependencyResolver = new DependencyResolver();
            lzWDecoder = (LzWDecoder)dependencyResolver.GetObject<ILzWDecoder>();

            filePathFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}.lzw";

            TestMethods.CreateFileWithGivenBytes(filePathEncodedFile, Constants.EncodedFileBytes.ToArray());
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
            TestMethods.DeleteFileIfExists(filePathFile);
            TestMethods.DeleteFileIfExists(filePathEncodedFile);
        }
    }
}