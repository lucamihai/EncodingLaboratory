using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileWriter : IDisposable
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        private readonly FileStream fileStream;

        public string FilePath { get; }
        public IBuffer Buffer { get; }

        public FileWriter(string filePath, IBuffer buffer)
        {
            FilePathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            fileStream = new FileStream(filePath, FileMode.Open);

            FilePath = filePath;
            Buffer = buffer;
            
            Buffer.OnCurrentBitReset += OnCurrentBitReset;
        }

        [ExcludeFromCodeCoverage]
        private void OnCurrentBitReset(byte valueFromBuffer)
        {
            if (fileStream.Position == fileStream.Length)
            {
                throw new IndexOutOfRangeException();
            }

            fileStream.WriteByte(Buffer.Value);

            Buffer.Flush();
        }

        public void WriteBit(bool bitValue)
        {
            var valueToWrite = bitValue ? (byte)1 : (byte)0;
            Buffer.AddValueStartingFromCurrentBit(valueToWrite, 1);
        }

        public void WriteValueOnBits(byte value, byte numberOfBits)
        {
            if (numberOfBits == 0)
            {
                throw new ArgumentException();
            }

            Buffer.AddValueStartingFromCurrentBit(value, numberOfBits);
        }

        [ExcludeFromCodeCoverage]
        ~FileWriter()
        {
            Dispose(false);
        }

        [ExcludeFromCodeCoverage]
        private void ReleaseUnmanagedResources()
        {
            fileStream.Close();
            fileStream.Dispose();
        }

        [ExcludeFromCodeCoverage]
        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                fileStream?.Dispose();
            }
        }

        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
