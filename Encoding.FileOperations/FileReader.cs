using System;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileReader
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();

        public string FilePath { get; }

        public FileReader(string filePath)
        {
            FilePathValidator.ValidateAndThrow(filePath);

            FilePath = filePath;
        }

        public void ReadBit()
        {
            throw new NotImplementedException();
        }

        public void ReadBits(byte numberOfBits)
        {
            throw new NotImplementedException();
        }
    }
}
