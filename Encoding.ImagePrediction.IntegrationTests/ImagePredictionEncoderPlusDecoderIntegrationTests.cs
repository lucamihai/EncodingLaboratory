using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.ImagePrediction.Interfaces;
using Encoding.ImagePrediction.Predictors;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.ImagePrediction.IntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ImagePredictionEncoderPlusDecoderIntegrationTests
    {
        private ImagePredictionEncoder imagePredictionEncoder;
        private ImagePredictionDecoder imagePredictionDecoder;
        private string filePathSource;
        private string filePathEncodedFile;
        private string filePathDecodedFile;

        [TestInitialize]
        public void Setup()
        {
            var dependencyResolver = new DependencyResolver();
            imagePredictionEncoder = (ImagePredictionEncoder)dependencyResolver.GetObject<IImagePredictionEncoder>();
            imagePredictionDecoder = (ImagePredictionDecoder)dependencyResolver.GetObject<IImagePredictionDecoder>();

            filePathSource = $"{Environment.CurrentDirectory}\\temp.bmp";
            filePathEncodedFile = $"{Environment.CurrentDirectory}\\temp.bmp.pre";
            filePathDecodedFile = $"{Environment.CurrentDirectory}\\temp.png.pre.bmp";

            TestMethods.CopyFileAndReplaceIfAlreadyExists($"{Environment.CurrentDirectory}\\Images\\TestImage1.bmp", filePathSource);
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor0()
        {
            var imagePredictor = new ImagePredictor0();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor1()
        {
            var imagePredictor = new ImagePredictor1();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor2()
        {
            var imagePredictor = new ImagePredictor2();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor3()
        {
            var imagePredictor = new ImagePredictor3();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor4()
        {
            var imagePredictor = new ImagePredictor4();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            } 

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor5()
        {
            var imagePredictor = new ImagePredictor5();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor6()
        {
            var imagePredictor = new ImagePredictor6();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor7()
        {
            var imagePredictor = new ImagePredictor7();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor8()
        {
            var imagePredictor = new ImagePredictor8();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            Assert.IsTrue(TestMethods.FilesHaveTheSameContent(filePathSource, filePathDecodedFile));
        }

        [TestMethod]
        public void ImageIsEncodedThenDecodedCorrectlyWithImagePredictor9()
        {
            var imagePredictor = new ImagePredictor9();

            using (var fileReader = new FileReader(filePathSource, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathEncodedFile, new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictor);
                }
            }

            using (var fileReader = new FileReader(filePathEncodedFile, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedFile, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
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
    }
}
