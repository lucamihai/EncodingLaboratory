using System;
using System.Drawing;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces;
using Encoding.ImagePrediction.Interfaces.Predictors;
using Encoding.ImagePrediction.Interfaces.Utilities;
using Encoding.ImagePrediction.Predictors;

namespace Encoding.ImagePrediction
{
    public class ImagePredictionEncoder : IImagePredictionEncoder
    {
        private readonly IErrorMatrixWriter errorMatrixWriter;

        public ImagePredictionEncoder(IErrorMatrixWriter errorMatrixWriter)
        {
            this.errorMatrixWriter = errorMatrixWriter;
        }

        public Bitmap OriginalImage { get; private set; }
        public byte[,] ImageCodes { get; private set; }
        public byte[,] PredictionMatrix { get; private set; }
        public int[,] ErrorMatrix { get; private set; }

        public void EncodeImage(IFileReader fileReader, IFileWriter fileWriter, IImagePredictor imagePredictor)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            if (imagePredictor == null)
            {
                throw new ArgumentNullException(nameof(imagePredictor));
            }

            ValidateImageFromFileReader(fileReader);

            fileReader.Close();
            using (var fileStream = new FileStream(fileReader.FilePath, FileMode.Open))
            {
                var bmp = new Bitmap(fileStream);
                OriginalImage = bmp;
            }
            fileReader.Open();

            ImageCodes = new byte[OriginalImage.Width, OriginalImage.Height];
            PredictionMatrix = new byte[OriginalImage.Width, OriginalImage.Height];
            ErrorMatrix = new int[OriginalImage.Width, OriginalImage.Height];

            UpdateImageCodes();

            HandleFirstPixel();
            HandleFirstColumn(imagePredictor);
            HandleFirstRow(imagePredictor);

            for (int row = 1; row < 256; row++)
            {
                for (int column = 1; column < 256; column++)
                {
                    var a = ImageCodes[row - 1, column];
                    var b = ImageCodes[row, column - 1];
                    var c = ImageCodes[row - 1, column - 1];

                    var prediction = imagePredictor.PredictValue(a, b, c);

                    HandlePrediction(row, column, prediction);
                }
            }

            CopyBitmapHeader(fileReader, fileWriter);
            WriteUsedImagePredictor(fileWriter, imagePredictor);
            errorMatrixWriter.WriteErrorMatrix(ErrorMatrix, fileWriter);

            fileWriter.Flush();
        }

        private void ValidateImageFromFileReader(IFileReader fileReader)
        {
            if (!fileReader.FilePath.EndsWith(".bmp"))
            {
                throw new InvalidOperationException("Only bmp images can be encoded");
            }

            fileReader.Close();
            var image = new Bitmap(fileReader.FilePath);
            

            try
            {
                if (image.Size != new Size(256, 256))
                {
                    throw new InvalidOperationException("Image must be 256x256");
                }
            }
            finally
            {
                image.Dispose();
                fileReader.Open();
            }
        }

        private void UpdateImageCodes()
        {
            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    ImageCodes[row, column] = OriginalImage.GetPixel(row, column).R;
                }
            }
        }

        private void HandleFirstPixel()
        {
            HandlePrediction(0, 0, 128);
        }

        private void HandleFirstColumn(IImagePredictor imagePredictor)
        {
            const byte b = 0;
            const byte c = 0;

            for (int row = 1; row < OriginalImage.Width; row++)
            {
                var a = ImageCodes[row - 1, 0];
                var prediction = imagePredictor.PredictValue(a, b, c);

                HandlePrediction(row, 0, prediction);
            }
        }

        private void HandleFirstRow(IImagePredictor imagePredictor)
        {
            const byte a = 0;
            const byte c = 0;

            for (int column = 1; column < OriginalImage.Height; column++)
            {
                var b = ImageCodes[0, column - 1];
                var prediction = imagePredictor.PredictValue(a, b, c);

                HandlePrediction(0, column, prediction);
            }
        }

        private void HandlePrediction(int row, int column, byte prediction)
        {
            PredictionMatrix[row, column] = prediction;
            ErrorMatrix[row, column] = ImageCodes[row, column] - prediction;
        }

        private void CopyBitmapHeader(IFileReader fileReader, IFileWriter fileWriter)
        {
            for (int index = 0; index < 1078; index++)
            {
                var currentByte = fileReader.ReadBits(8);
                fileWriter.WriteValueOnBits(currentByte, 8);
            }
        }

        private void WriteUsedImagePredictor(IFileWriter fileWriter, IImagePredictor imagePredictor)
        {
            if (imagePredictor is ImagePredictor0)
            {
                fileWriter.WriteValueOnBits(0, 4);
            }

            if (imagePredictor is ImagePredictor1)
            {
                fileWriter.WriteValueOnBits(1, 4);
            }

            if (imagePredictor is ImagePredictor2)
            {
                fileWriter.WriteValueOnBits(2, 4);
            }

            if (imagePredictor is ImagePredictor3)
            {
                fileWriter.WriteValueOnBits(3, 4);
            }

            if (imagePredictor is ImagePredictor4)
            {
                fileWriter.WriteValueOnBits(4, 4);
            }

            if (imagePredictor is ImagePredictor5)
            {
                fileWriter.WriteValueOnBits(5, 4);
            }

            if (imagePredictor is ImagePredictor6)
            {
                fileWriter.WriteValueOnBits(6, 4);
            }

            if (imagePredictor is ImagePredictor7)
            {
                fileWriter.WriteValueOnBits(7, 4);
            }

            if (imagePredictor is ImagePredictor8)
            {
                fileWriter.WriteValueOnBits(8, 4);
            }
        }
    }
}