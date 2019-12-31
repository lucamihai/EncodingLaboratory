using System;
using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces.Utilities;

namespace Encoding.ImagePrediction.Utilities
{
    public class ErrorMatrixReader : IErrorMatrixReader
    {
        public int[,] ReadErrorMatrix(IFileReader fileReader)
        {
            var errorMatrix = new int[256, 256];

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    var number = GetNextNumber(fileReader);
                    errorMatrix[row, column] = number;
                }
            }

            return errorMatrix;
        }

        private int GetNextNumber(IFileReader fileReader)
        {
            var bitsToRead = 0;
            while (fileReader.ReadBit())
            {
                bitsToRead++;
            }

            if (bitsToRead == 0)
            {
                return 0;
            }

            var value = fileReader.ReadBits((byte)bitsToRead);
            var maxValueForGivenBits = Math.Pow(2, bitsToRead) - 1;

            if (value < maxValueForGivenBits / 2)
            {
                var cv = (int) (maxValueForGivenBits - value) * (-1);
                return cv;
            }

            return (int)value;
        }
    }
}