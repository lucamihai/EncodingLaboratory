using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileReader : IDisposable
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        private readonly FileStream fileStream;

        public string FilePath { get; }
        public IBuffer Buffer { get; }

        public FileReader(string filePath, IBuffer buffer)
        {
            FilePathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            FilePath = filePath;
            Buffer = buffer;

            fileStream = new FileStream(filePath, FileMode.Open);

            Buffer.OnCurrentBitReset += OnCurrentBitReset;
        }

        [ExcludeFromCodeCoverage]
        private void OnCurrentBitReset(byte valueFromBuffer)
        {
            if (fileStream.Position == fileStream.Length)
            {
                throw new IndexOutOfRangeException();
            }

            Buffer.Flush();
            Buffer.AddValueStartingFromCurrentBit((byte)fileStream.ReadByte(), 8);
        }

        public bool ReadBit()
        {
            return Buffer.GetValueStartingFromCurrentBit(1) == 1;
        }

        public byte ReadBits(byte numberOfBits)
        {
            if (numberOfBits == 0)
            {
                throw new ArgumentException();
            }

            return Buffer.GetValueStartingFromCurrentBit(numberOfBits);
        }

        [ExcludeFromCodeCoverage]
        ~FileReader()
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
