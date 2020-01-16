using System.Drawing;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.Jpeg.Entities;
using Encoding.Jpeg.Enums;
using Encoding.Jpeg.Interfaces;
using Encoding.Jpeg.Interfaces.Mappers;
using Encoding.Jpeg.Interfaces.Utilities;
using Encoding.Jpeg.Utilities;

namespace Encoding.Jpeg
{
    public class JpegEncoder : IJpegEncoder
    {
        private readonly IPixelMapper pixelMapper;
        private readonly IDCT dct;

        public Bitmap OriginalImage { get; private set; }
        public Bitmap ReconstructedImage { get; private set; }
        public double[,] DctY { get; private set; }
        public double[,] DctCb { get; private set; }
        public double[,] DctCr { get; private set; }
        

        public JpegEncoder(IPixelMapper pixelMapper, IDCT dct)
        {
            this.pixelMapper = pixelMapper;
            this.dct = dct;
        }

        public void EncodeImage(IFileReader fileReader, IDownSampler downSampler)
        {
            GetImageFromFileReader(fileReader);

            var pixels = GetYCbCrPixelsFromImage(OriginalImage);
            GetMatrices(pixels, out var yMatrix, out var cbMatrix, out var crMatrix);

            var downSampledCbMatrix = downSampler.GetDownSampledMatrix(cbMatrix);
            var downSampledCrMatrix = downSampler.GetDownSampledMatrix(crMatrix);

            DctY = dct.GetDiscreteCosineTransform(yMatrix);
            DctCb = dct.GetDiscreteCosineTransform(downSampledCbMatrix);
            DctCr = dct.GetDiscreteCosineTransform(downSampledCrMatrix);
        }

        public void DecodeImage(IDownSampler downSampler, QuantizeMethod quantizeMethod, int quantizeParameter)
        {
            GetQuantizeds(quantizeMethod, quantizeParameter, out var quantizedY, out var quantizedCb, out var quantizedCr);

            var iQuantizedY = new double[256, 256];
            var iQuantizedCb = new double[128, 128];
            var iQuantizedCr = new double[128, 128];

            if (quantizeMethod == QuantizeMethod.ZigZag)
            {
                iQuantizedY = quantizedY.GetIQuantizeUsingZigZagMethod(quantizeParameter);
                iQuantizedCb = quantizedCb.GetIQuantizeUsingZigZagMethod(quantizeParameter);
                iQuantizedCr = quantizedCr.GetIQuantizeUsingZigZagMethod(quantizeParameter);
            }

            if (quantizeMethod == QuantizeMethod.Method2)
            {
                iQuantizedY = quantizedY.GetIQuantizeUsingMethod2(quantizeParameter);
                iQuantizedCb = quantizedCb.GetIQuantizeUsingMethod2(quantizeParameter);
                iQuantizedCr = quantizedCr.GetIQuantizeUsingMethod2(quantizeParameter);
            }

            if (quantizeMethod == QuantizeMethod.JpegQuality)
            {
                iQuantizedY = quantizedY.GetIQuantizeUsingJpegQualityMethod(quantizeParameter);
                iQuantizedCb = quantizedCb.GetIQuantizeUsingJpegQualityMethod(quantizeParameter);
                iQuantizedCr = quantizedCr.GetIQuantizeUsingJpegQualityMethod(quantizeParameter);
            }

            var iDctY = dct.GetIDiscreteCosineTransform(iQuantizedY);
            var iDctCb = dct.GetIDiscreteCosineTransform(iQuantizedCb);
            var iDctCr = dct.GetIDiscreteCosineTransform(iQuantizedCr);

            var upSampledCb = downSampler.GetUpSampledMatrix(iDctCb);
            var upSampledCr = downSampler.GetUpSampledMatrix(iDctCr);

            var yCbCrPixels = new YCbCrPixel[256, 256];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    yCbCrPixels[i, j] = new YCbCrPixel
                    {
                        Y = (byte)iDctY[i, j],
                        Cb = (byte)upSampledCb[i, j],
                        Cr = (byte)upSampledCr[i, j]
                    };
                }
            }

            ReconstructedImage = GetBitmapFromYCbCrPixels(yCbCrPixels);
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

        private void GetQuantizeds(QuantizeMethod quantizeMethod, int quantizeParameter, out double[,] quantizedY, out double[,] quantizedCb, out double[,] quantizedCr)
        {
            quantizedY = new double[256, 256];
            quantizedCb = new double[128, 128];
            quantizedCr = new double[128, 128];

            if (quantizeMethod == QuantizeMethod.ZigZag)
            {
                quantizedY = DctY.GetQuantizeUsingZigZagMethod(quantizeParameter);
                quantizedCb = DctCb.GetQuantizeUsingZigZagMethod(quantizeParameter);
                quantizedCr = DctCr.GetQuantizeUsingZigZagMethod(quantizeParameter);
            }

            if (quantizeMethod == QuantizeMethod.Method2)
            {
                quantizedY = DctY.GetQuantizeUsingMethod2(quantizeParameter);
                quantizedCb = DctCb.GetQuantizeUsingMethod2(quantizeParameter);
                quantizedCr = DctCr.GetQuantizeUsingMethod2(quantizeParameter);
            }

            if (quantizeMethod == QuantizeMethod.JpegQuality)
            {
                quantizedY = DctY.GetQuantizeUsingJpegQualityMethod(quantizeParameter);
                quantizedCb = DctCb.GetQuantizeUsingJpegQualityMethod(quantizeParameter);
                quantizedCr = DctCr.GetQuantizeUsingJpegQualityMethod(quantizeParameter);
            }
        }

        private Bitmap GetBitmapFromYCbCrPixels(YCbCrPixel[,] pixels)
        {
            var bitmap = new Bitmap(256, 256);

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    var rgb = pixelMapper.GetRgbFromYCbCrPixel(pixels[i, j]);
                    bitmap.SetPixel(i, j, rgb);

                }
            }

            return bitmap;
        }
    }
}