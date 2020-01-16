using System.Linq;
using Encoding.Jpeg.Interfaces.Utilities;

namespace Encoding.Jpeg.Utilities
{
    public class DownSampler411 : IDownSampler
    {
        public double[,] GetDownSampledMatrix(double[,] matrix)
        {
            var downSampledMatrix = new double[128, 128];

            for (int row = 0; row < 255; row += 2)
            {
                for (int column = 0; column < 255; column += 2)
                {
                    //downSampledMatrix[row / 2, column / 2] = GetAverage(
                    //    matrix[row, column],
                    //    matrix[row, column + 1],
                    //    matrix[row + 1, column],
                    //    matrix[row + 1, column + 1]
                    //);

                    downSampledMatrix[row / 2, column / 2] = matrix[row, column];
                }
            }

            return downSampledMatrix;
        }

        public double[,] GetUpSampledMatrix(double[,] matrix)
        {
            var upSampledMatrix = new double[256, 256];

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    upSampledMatrix[i, j] = matrix[i, j];
                    upSampledMatrix[i, j + 1] = matrix[i, j];
                    upSampledMatrix[i + 1, j] = matrix[i, j];
                    upSampledMatrix[i + 1, j + 1] = matrix[i, j];
                }
            }

            return upSampledMatrix;
        }

        private static double GetAverage(params double[] values)
        {
            return values.Sum() / values.Length;
        }
    }
}