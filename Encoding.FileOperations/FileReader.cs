using System;
using Encoding.FileOperations.Interfaces;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileReader
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        public string FilePath { get; }
        public IBuffer Buffer { get; }

        public FileReader(string filePath, IBuffer buffer)
        {
            FilePathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            FilePath = filePath;
            Buffer = buffer;
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
