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
                    downSampledMatrix[row / 2, column / 2] = GetAverage(
                        matrix[row, column], 
                        matrix[row, column + 1], 
                        matrix[row + 1, column], 
                        matrix[row + 1, column + 1]
                    );
                }
            }

            return downSampledMatrix;
        }

        private static double GetAverage(params double[] values)
        {
            return values.Sum() / values.Length;
        }
    }
}