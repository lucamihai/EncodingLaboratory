﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.LzW.IntegrationTests.Properties;
using Encoding.LzW.Interfaces;
using Encoding.LzW.Options;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.LzW.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWEncoderPlusDecoderIntegrationTests
    {
        private LzWEncoder lzWEncoder;
        private LzWDecoder lzWDecoder;
        private string filePathSource;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            lzWEncoder = (LzWEncoder)dependencyResolver.GetObject<ILzWEncoder>();
            lzWDecoder = (LzWDecoder)dependencyResolver.GetObject<ILzWDecoder>();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.png";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.png.lzw";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.lzw.png";

            CreateInitialFile();
        }

        [TestMethod]
        public void FileIsCodedThenDecodedCorrectly1()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, OnFullDictionaryOption.Freeze, 9);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void FileIsCodedThenDecodedCorrectly2()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, OnFullDictionaryOption.Freeze, 12);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void FileIsCodedThenDecodedCorrectly3()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, OnFullDictionaryOption.Empty, 9);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void FileIsCodedThenDecodedCorrectly4()
        {
            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, OnFullDictionaryOption.Empty, 12);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
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

        private void CreateInitialFile()
        {
            var img = new Bitmap(Resources.capture);
            img.Save(filePathSource, ImageFormat.Png);
            img.Dispose();
        }
    }
}