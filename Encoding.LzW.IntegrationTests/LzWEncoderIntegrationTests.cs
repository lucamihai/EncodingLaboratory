using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.LzW.Interfaces;
using Encoding.LzW.Options;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.LzW.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWEncoderIntegrationTests
    {
        private LzWEncoder lzWEncoder;
        private string filePathFile;
        private string filePathEncodedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            lzWEncoder = (LzWEncoder)dependencyResolver.GetObject<ILzWEncoder>();

            filePathFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}.lzw";

            File.WriteAllText(filePathFile, Constants.FileContents);
        }

        [TestMethod]
        public void EncodeFileSetsIndexesAsExpected()
        {
            using (var fileReader = new FileReader(filePathFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, OnFullDictionaryOption.Empty, 9);
                }
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.ExpectedIndexes, lzWEncoder.IndexesFromLastRun).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathFile);
            TestMethods.DeleteFileIfExists(filePathEncodedFile);
        }
    }
}
