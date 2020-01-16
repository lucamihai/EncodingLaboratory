﻿using System;

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
            var quantizeHelperMatrix = GetHelperMatrixForMethod2(R);
            var dctLength0 = dct.GetLength(0);
            var dctLength1 = dct.GetLength(1);
            var quantized = new double[dctLength0, dctLength1];

            for (int i = 0; i < dctLength0; i++)
            {
                for (int j = 0; j < dctLength1; j++)
                {
                    quantized[i, j] = dct[i, j] / quantizeHelperMatrix[i % 8, j % 8];
                }
            }

            return quantized;
        }

        public static double[,] GetQuantizeUsingJpegQualityMethod(this double[,] dct, int jpegQuality)
        {
            var dctLength0 = dct.GetLength(0);
            var dctLength1 = dct.GetLength(1);
            var quantized = new double[dctLength0, dctLength1];
            var quantizeHelperMatrix = GetHelperMatrixForJpegQualityMethod(dctLength0 == 256, jpegQuality);

            for (int i = 0; i < dctLength0; i++)
            {
                for (int j = 0; j < dctLength1; j++)
                {
                    quantized[i, j] = dct[i, j] / quantizeHelperMatrix[i % 8, j % 8];
                }
            }

            return quantized;
        }

        public static double[,] GetIQuantizeUsingZigZagMethod(this double[,] quantized, int N)
        {
            throw new NotImplementedException("Maybe do it later");
        }

        public static double[,] GetIQuantizeUsingMethod2(this double[,] quantized, int R)
        {
            var quantizeHelperMatrix = GetHelperMatrixForMethod2(R);
            var dctLength0 = quantized.GetLength(0);
            var dctLength1 = quantized.GetLength(1);
            var iQuantized = new double[dctLength0, dctLength1];

            for (int i = 0; i < dctLength0; i++)
            {
                for (int j = 0; j < dctLength1; j++)
                {
                    iQuantized[i, j] = quantized[i, j] * quantizeHelperMatrix[i % 8, j % 8];
                }
            }

            return iQuantized;
        }

        public static double[,] GetIQuantizeUsingJpegQualityMethod(this double[,] quantized, int jpegQuality)
        {
            var dctLength0 = quantized.GetLength(0);
            var dctLength1 = quantized.GetLength(1);
            var iQuantized = new double[dctLength0, dctLength1];
            var quantizeHelperMatrix = GetHelperMatrixForJpegQualityMethod(dctLength0 == 256, jpegQuality);

            for (int i = 0; i < dctLength0; i++)
            {
                for (int j = 0; j < dctLength1; j++)
                {
                    iQuantized[i, j] = quantized[i, j] * quantizeHelperMatrix[i % 8, j % 8];
                }
            }

            return iQuantized;
        }

        private static int[,] GetHelperMatrixForMethod2(int R)
        {
            var quantizeHelperMatrix = new int[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    quantizeHelperMatrix[x, y] = 1 + (x + y) * R;
                }
            }

            return quantizeHelperMatrix;
        }

        private static int[,] GetHelperMatrixForJpegQualityMethod(bool isForY, int jpegQuality)
        {
            int[,] helperMatrix;

            if (isForY)
            {
                helperMatrix = new[,]
                {
                    {16, 11, 10, 16, 24, 40, 51, 61},
                    {12, 12, 14, 19, 26, 58, 60, 55},
                    {14, 13, 16, 24, 40, 57, 69, 56},
                    {14, 17, 22, 29, 51, 87, 80, 62},
                    {18, 22, 37, 56, 68, 109, 103, 77},
                    {24, 35, 55, 64, 81, 104, 113, 92},
                    {49, 64, 78, 87, 103, 121, 120, 101},
                    {72, 92, 95, 98, 112, 100, 103, 99}
                };
            }
            else
            {
                helperMatrix = new[,]
                {
                    {17, 18, 24, 47, 99, 99, 99, 99},
                    {18, 21, 26, 66, 99, 99, 99, 99},
                    {24, 26, 56, 99, 99, 99, 99, 99},
                    {47, 66, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99},
                    {99, 99, 99, 99, 99, 99, 99, 99}
                };
            }

            if (jpegQuality != 100)
            {
                var mul = jpegQuality <= 50
                    ? 50d / jpegQuality
                    : (2 - jpegQuality) / 50d;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        helperMatrix[i, j] = (int)(helperMatrix[i, j] * mul);
                    }
                }
            }

            return helperMatrix;
        }
    }
}