using System;
using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces;
using Encoding.ImagePrediction.Interfaces.Predictors;
using Encoding.ImagePrediction.Interfaces.Utilities;
using Encoding.ImagePrediction.Predictors;

namespace Encoding.ImagePrediction
{
    public class ImagePredictionDecoder : IImagePredictionDecoder
    {
        private readonly IErrorMatrixReader errorMatrixReader;
        private int imageSize;

        public byte[,] ImageCodes { get; private set; }
        public int[,] ErrorMatrix { get; private set; }

        public ImagePredictionDecoder(IErrorMatrixReader errorMatrixReader)
        {
            this.errorMatrixReader = errorMatrixReader;
        }

        public void DecodeImage(IFileReader fileReader, IFileWriter fileWriter)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            CopyBitmapHeader(fileReader, fileWriter);
            var usedImagePredictor = DetermineUsedImagePredictor(fileReader);

            ErrorMatrix = errorMatrixReader.ReadErrorMatrix(fileReader);
            imageSize = ErrorMatrix.GetLength(0);
            ImageCodes = new byte[imageSize, imageSize];

            HandleFirstPixel();
            HandleFirstColumn(usedImagePredictor);
            HandleFirstRow(usedImagePredictor);

            for (int row = 1; row < imageSize; row++)
            {
                for (int column = 1; column < imageSize; column++)
                {
                    var a = ImageCodes[row - 1, column];
                    var b = ImageCodes[row, column - 1];
                    var c = ImageCodes[row - 1, column - 1];

                    var prediction = usedImagePredictor.PredictValue(a, b, c);

                    ImageCodes[row, column] = (byte)Math.Abs(prediction + ErrorMatrix[row, column]);
                }
            }

            WriteImageCodes(fileWriter);
        }

        private static void CopyBitmapHeader(IFileReader fileReader, IFileWriter fileWriter)
        {
            for (int index = 0; index < 1078; index++)
            {
                var currentByte = fileReader.ReadBits(8);
                fileWriter.WriteValueOnBits(currentByte, 8);
            }
        }

        private static IImagePredictor DetermineUsedImagePredictor(IFileReader fileReader)
        {
            var bits = fileReader.ReadBits(4);

            if (bits == 0)
            {
                return new ImagePredictor0();
            }

            if (bits == 1)
            {
                return new ImagePredictor1();
            }

            if (bits == 2)
            {
                return new ImagePredictor2();
            }

            if (bits == 3)
            {
                return new ImagePredictor3();
            }

            if (bits == 4)
            {
                return new ImagePredictor4();
            }

            if (bits == 5)
            {
                return new ImagePredictor5();
            }

            if (bits == 6)
            {
                return new ImagePredictor6();
            }

            if (bits == 7)
            {
                return new ImagePredictor7();
            }

            if (bits == 8)
            {
                return new ImagePredictor8();
            }

            throw new InvalidOperationException();
        }

        private void HandleFirstPixel()
        {
            ImageCodes[0, 0] = (byte)(128 + ErrorMatrix[0, 0]);
        }

        private void HandleFirstColumn(IImagePredictor imagePredictor)
        {
            const byte b = 0;
            const byte c = 0;

            for (int row = 1; row < imageSize; row++)
            {
                var a = ImageCodes[row - 1, 0];
                var predictedValue = imagePredictor.PredictValue(a, b, c);
                ImageCodes[row, 0] = (byte)(predictedValue + ErrorMatrix[row, 0]);
            }
        }

        private void HandleFirstRow(IImagePredictor imagePredictor)
        {
            const byte a = 0;
            const byte c = 0;

            for (int column = 1; column < imageSize; column++)
            {
                var b = ImageCodes[0, column - 1];
                var predictedValue = imagePredictor.PredictValue(a, b, c);
                ImageCodes[0, column] = (byte)(predictedValue + ErrorMatrix[0, column]);
            }
        }

        private void WriteImageCodes(IFileWriter fileWriter)
        {
            for (int row = 255; row >= 0; row--)
            {
                for (int column = 0; column < 256; column++)
                {
                    fileWriter.WriteValueOnBits(ImageCodes[column, row], 8);
                }
            }
        }
    }
}