using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Imaging;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Jpeg.Enums;
using Encoding.Jpeg.Interfaces;
using Encoding.Jpeg.Interfaces.Utilities;
using Encoding.Jpeg.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Jpeg.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TemporaryTests
    {
        private IDownSampler downSampler;
        private JpegEncoder jpegEncoder;
        private string filePathSource;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            jpegEncoder = (JpegEncoder)dependencyResolver.GetObject<IJpegEncoder>();
            downSampler = new DownSampler411();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.bmp";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.bmp.pre";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.pre.jpg";

            TestMethods.CopyFileAndReplaceIfAlreadyExists($"{Environment.CurrentDirectory}\\Images\\TestImage1.bmp", filePathSource);
        }

        [TestMethod]
        public void TempTest1()
        {
            using (var fileReader = new FileReader(filePathSource, new FileOperations.Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new FileOperations.Buffer()))
                {
                    jpegEncoder.EncodeImage(fileReader, fileWriter, downSampler);
                    jpegEncoder.DecodeImage(downSampler, QuantizeMethod.Method2, 50);
                }
            }

            jpegEncoder.ReconstructedImage.Save(filePathDecodedFile, ImageFormat.Jpeg);
        }

        [TestMethod]
        public void TempTest2()
        {
            using (var fileReader = new FileReader(filePathSource, new FileOperations.Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new FileOperations.Buffer()))
                {
                    jpegEncoder.EncodeImage(fileReader, fileWriter, downSampler);
                    jpegEncoder.DecodeImage(downSampler, QuantizeMethod.JpegQuality, 50);
                }
            }
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