using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Rsa.Interfaces;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.Rsa.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RsaEncrypterPlusDecrypterIntegrationTests
    {
        private RsaEncrypter rsaEncrypter;
        private RsaDecrypter rsaDecrypter;
        private string filePathSource;
        private string filePathEncryptedFile;
        private string filePathDecryptedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            rsaEncrypter = (RsaEncrypter)dependencyResolver.GetObject<IRsaEncrypter>();
            rsaDecrypter = (RsaDecrypter)dependencyResolver.GetObject<IRsaDecrypter>();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.txt";
            filePathEncryptedFile = $"{Environment.CurrentDirectory}\\temp.txt.rsa";
            filePathDecryptedFile = $"{Environment.CurrentDirectory}\\temp.txt.rsa.txt";

            TestMethods.CreateFileWithTextContents(filePathSource, Constants.FileContents);
        }

        [TestMethod]
        public void FileIsEncryptedThenDecryptedCorrectly()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncryptedFile, new Buffer()))
                {
                    rsaEncrypter.EncryptFile(fileReader, fileWriter, Constants.N, Constants.E);
                }
            }

            using (var fileReader = new FileReader(filePathEncryptedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecryptedFile, new Buffer()))
                {
                    rsaDecrypter.DecryptFile(fileReader, fileWriter, Constants.D);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecryptedFile));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestMethods.DeleteFileIfExists(filePathSource);
            TestMethods.DeleteFileIfExists(filePathEncryptedFile);
            TestMethods.DeleteFileIfExists(filePathDecryptedFile);
        }
    }
}
