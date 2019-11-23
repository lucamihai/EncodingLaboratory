using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Encoding.FileOperations.Interfaces;
using Encoding.FileOperations.Validators;

namespace Encoding.FileOperations
{
    public class FileReader : IFileReader, IDisposable
    {
        private static readonly FilePathValidator FilePathValidator = new FilePathValidator();
        private static readonly BufferValidator BufferValidator = new BufferValidator();

        private readonly FileStream fileStream;

        public bool ReachedEndOfFile { get; private set; }
        public long BitsLeft { get; private set; }

        public string FilePath { get; }
        public IBuffer Buffer { get; }

        public FileReader(string filePath, IBuffer buffer)
        {
            FilePathValidator.ValidateAndThrow(filePath);
            BufferValidator.ValidateAndThrow(buffer);

            FilePath = filePath;
            Buffer = buffer;

            fileStream = new FileStream(filePath, FileMode.Open);
            BitsLeft = fileStream.Length * 8;

            Buffer.OnCurrentBitReset += OnCurrentBitReset;
            Buffer.Value = (byte)fileStream.ReadByte();
        }

        [ExcludeFromCodeCoverage]
        private void OnCurrentBitReset(byte valueFromBuffer)
        {
            if (ReachedEndOfFile)
            {
                return;
            }

            if (fileStream.Position == fileStream.Length)
            {
                ReachedEndOfFile = true;
                Buffer.AddValueStartingFromCurrentBit(127, 7);
            }

            Buffer.Value = (byte)fileStream.ReadByte();
        }

        public bool ReadBit()
        {
            BitsLeft -= 1;
            return Buffer.GetValueStartingFromCurrentBit(1) == 1;
        }

        public uint ReadBits(byte numberOfBits)
        {
            uint returnedValue = 0;

            if (numberOfBits == 0)
            {
                throw new ArgumentException();
            }

            BitsLeft -= numberOfBits;

            if (numberOfBits <= 8)
            {
                return Buffer.GetValueStartingFromCurrentBit(numberOfBits);
            }
            else
            {
                var numberOfBitsRead = 0;

                while (numberOfBits > 0)
                {
                    var numberOfBitsToRead = numberOfBits > 8
                        ? (byte)8
                        : numberOfBits;

                    returnedValue += (uint)Buffer.GetValueStartingFromCurrentBit(numberOfBitsToRead) << numberOfBitsRead;
                    numberOfBits -= numberOfBitsToRead;
                    numberOfBitsRead += numberOfBitsToRead;
                }
            }

            return returnedValue;
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
