using System;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77.Utilities
{
    public class Lz77TokenWriter : ILz77TokenWriter
    {
        public void WriteToken(Lz77Token lz77Token, IFileWriter fileWriter, int bitsForOffset, int bitsForLength)
        {
            if (lz77Token == null)
            {
                throw new ArgumentNullException(nameof(lz77Token));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            fileWriter.WriteValueOnBits((uint)lz77Token.Position, (byte)bitsForOffset);
            fileWriter.WriteValueOnBits((uint)lz77Token.Length, (byte)bitsForLength);
            fileWriter.WriteValueOnBits(lz77Token.Byte, 8);
        }
    }
}