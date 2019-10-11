using System;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileWriter
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();

        public string FilePath { get; }

        public FileWriter(string filePath)
        {
            FilePathValidator.ValidateAndThrow(filePath);

            FilePath = filePath;
        }

        public void WriteBit(bool bitValue)
        {
            throw new NotImplementedException();
        }

        public void WriteValueOnBits(byte value, byte numberOfBits)
        {
            throw new NotImplementedException();
        }
    }
}
