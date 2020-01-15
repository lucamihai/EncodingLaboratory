using System;

namespace Encoding.Jpeg.Utilities
{
    internal static class QuantizeMethods
    {
        public static double[,] GetQuantizeUsingZigZagMethod(this double[,] dct, int N)
        {
            throw new NotImplementedException("Maybe do it later");
        }

        public static double[,] GetQuantizeUsingMethod2(this double[,] dct, int R)
        {
            var quantized = new double[64, 64];

            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    quantized[x, y] = 1 + (x + y) * R;
                }
            }

            return quantized;
        }

        public static double[,] GetQuantizeUsingJpegQualityMethod(this double[,] dct, int jpegQuality)
        {
            var quantized = new double[64, 64];

            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    if (jpegQuality >= 1 && jpegQuality <= 50)
                    {
                        quantized[x, y] = 50d / jpegQuality * dct[x, y];
                    }

                    if (jpegQuality >= 1 && jpegQuality <= 50)
                    {
                        quantized[x, y] = 50d / jpegQuality * dct[x, y];
                    }
                }
            }

            return quantized;
        }
    }
}