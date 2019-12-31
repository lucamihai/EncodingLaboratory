using System;
using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces.Utilities;

namespace Encoding.ImagePrediction.Utilities
{
    public class ErrorMatrixWriter : IErrorMatrixWriter
    {
        public void WriteErrorMatrix(int[,] errorMatrix, IFileWriter fileWriter)
        {
            if (errorMatrix == null)
            {
                throw new ArgumentNullException(nameof(errorMatrix));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    var number = errorMatrix[row, column]; 
                    WriteNumber(number, fileWriter);
                }
            }
        }

        private static void WriteNumber(int number, IFileWriter fileWriter)
        {
            var requiredBits = NumberOfBitsRequiredForNumber(Math.Abs(number));

            for (int i = 0; i < requiredBits; i++)
            {
                fileWriter.WriteBit(true);
            }

            fileWriter.WriteBit(false);

            if (number == 0)
            {
                return;
            }

            if (number < 0)
            {
                var maxValueForGivenBits = Math.Pow(2, requiredBits) - 1;
                var numberToWrite = (uint)(maxValueForGivenBits + number);
                fileWriter.WriteValueOnBits(numberToWrite, (byte)requiredBits);
            }
            else
            {
                fileWriter.WriteValueOnBits((uint)number, (byte)requiredBits);
            }
        }

        private static int NumberOfBitsRequiredForNumber(int number)
        {
            return (int)Math.Log(number, 2) + 1;
        }
    }
}