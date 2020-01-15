using System;
using Encoding.Jpeg.Interfaces.Utilities;

namespace Encoding.Jpeg.Utilities
{
    public class DCT : IDCT
    {
        private static readonly double OneDividedBy2Sqrt = 1 / Math.Sqrt(2);

        public double[,] GetDiscreteCosineTransform(double[,] matrix)
        {
            var discreteCosineTransform = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var sum = 0d;
                    var iIndexInsideBlock = i % 8;
                    var jIndexInsideBlock = j % 8;

                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            var firstIFromBlock = i / 8 * 8;
                            var firstJFromBlock = j / 8 * 8;

                            var pixel = matrix[x + firstIFromBlock, y + firstJFromBlock];
                            var firstCos = Math.Cos(((2 * x + 1) * iIndexInsideBlock * Math.PI) / 16);
                            var secondCos = Math.Cos(((2 * y + 1) * jIndexInsideBlock * Math.PI) / 16);
                            sum += firstCos * secondCos * pixel;
                        }
                    }

                    var ci = iIndexInsideBlock == 0 
                        ? 1 / OneDividedBy2Sqrt 
                        : 1;
                    var cj = jIndexInsideBlock == 0 
                        ? 1 / OneDividedBy2Sqrt
                        : 1;

                    discreteCosineTransform[i, j] = sum * 0.25 * ci * cj;
                }
            }

            return discreteCosineTransform;
        }
    }
}