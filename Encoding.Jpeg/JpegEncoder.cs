using System.Drawing;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.Jpeg.Entities;
using Encoding.Jpeg.Interfaces;
using Encoding.Jpeg.Interfaces.Mappers;
using Encoding.Jpeg.Interfaces.Utilities;

namespace Encoding.Jpeg
{
    public class JpegEncoder : IJpegEncoder
    {
        private readonly IPixelMapper pixelMapper;
        private readonly IDownSampler downSampler;

        public Bitmap OriginalImage { get; private set; }

        public JpegEncoder(IPixelMapper pixelMapper, IDownSampler downSampler)
        {
            this.pixelMapper = pixelMapper;
            this.downSampler = downSampler;
        }

        public void EncodeImage(IFileReader fileReader, IFileWriter fileWriter)
        {
            GetImageFromFileReader(fileReader);

            var pixels = GetYCbCrPixelsFromImage(OriginalImage);
            GetMatrices(pixels, out var yMatrix, out var cbMatrix, out var crMatrix);

            var downSampledCbMatrix = downSampler.GetDownSampledMatrix(cbMatrix);
            var downSampledCrMatrix = downSampler.GetDownSampledMatrix(crMatrix);
        }

        private void GetImageFromFileReader(IFileReader fileReader)
        {
            fileReader.Close();
            using (var fileStream = new FileStream(fileReader.FilePath, FileMode.Open))
            {
                var bmp = new Bitmap(fileStream);
                OriginalImage = bmp;
            }
            fileReader.Open();
        }

        private YCbCrPixel[,] GetYCbCrPixelsFromImage(Bitmap image)
        {
            var pixels = new YCbCrPixel[256, 256];

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    pixels[i, j] = pixelMapper.GetYCbCrPixelFromRgb(image.GetPixel(i, j));
                }
            }

            return pixels;
        }

        private void GetMatrices(YCbCrPixel[,] pixels, out double[,] yMatrix, out double[,] cbMatrix, out double[,] crMatrix)
        {
            yMatrix = new double[256, 256];
            cbMatrix = new double[256, 256];
            crMatrix = new double[256, 256];

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    yMatrix[i, j] = pixels[i, j].Y;
                    cbMatrix[i, j] = pixels[i, j].Cb;
                    crMatrix[i, j] = pixels[i, j].Cr;
                }
            }
        }
    }
}