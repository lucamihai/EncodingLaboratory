using System;
using Encoding.FileOperations.Interfaces;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileWriter
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        public string FilePath { get; }
        public IBuffer Buffer { get; }

        public FileWriter(string filePath, IBuffer buffer)
        {
            FilePathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            FilePath = filePath;
            Buffer = buffer;
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
