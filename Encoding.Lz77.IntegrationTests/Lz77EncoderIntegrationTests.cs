using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Lz77.Interfaces;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Lz77.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77EncoderIntegrationTests
    {
        private Lz77Encoder lz77Encoder;
        private string filePathFile;
        private string filePathEncodedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            lz77Encoder = (Lz77Encoder)dependencyResolver.GetObject<ILz77Encoder>();

            filePathFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\{Constants.FileName}.lz77";

            TestMethods.CreateFileWithTextContents(filePathFile, Constants.FileContents);
        }

        [TestMethod]
        public void EncodeFileSetsTokensFromPreviousRunAsExpected()
        {
            using (var fileReader = new FileReader(filePathFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lz77Encoder.EncodeFile(fileReader, fileWriter, Constants.BitsForOffset1, Constants.BitsForLength1);
                }
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.GetTokens1(), lz77Encoder.TokensFromPreviousRun).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathFile);
            TestMethods.DeleteFileIfExists(filePathEncodedFile);
        }
    }
}
