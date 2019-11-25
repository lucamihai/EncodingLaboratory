using System;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77
{
    public class Lz77Encoder
    {
        private readonly Lz77Buffer lz77Buffer;
        private readonly ILz77TokenExtractor lz77TokenExtractor;
        private readonly ILz77BufferManager lz77BufferManager;
        private readonly ILz77TokenWriter lz77TokenWriter;

        public Lz77Encoder(Lz77Buffer lz77Buffer, ILz77TokenExtractor lz77TokenExtractor, ILz77BufferManager lz77BufferManager, ILz77TokenWriter lz77TokenWriter)
        {
            this.lz77Buffer = lz77Buffer;
            this.lz77TokenExtractor = lz77TokenExtractor;
            this.lz77BufferManager = lz77BufferManager;
            this.lz77TokenWriter = lz77TokenWriter;
        }

        public void EncodeFile(IFileReader fileReader, IFileWriter fileWriter, int bitsForOffset, int bitsForLength)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            if (bitsForOffset < 3 || bitsForOffset > 15)
            {
                throw new ArgumentException($"{nameof(bitsForOffset)} should be between 3 and 15");
            }

            if (bitsForLength < 2 || bitsForLength > 7)
            {
                throw new ArgumentException($"{nameof(bitsForLength)} should be between 3 and 15");
            }

            lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, fileReader);

            while (lz77Buffer.LookAheadBuffer.Count > 0)
            {
                var lz77Token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(lz77Buffer);

                lz77BufferManager.EmptyLookAheadBufferBasedOnLz77Token(lz77Buffer, lz77Token);
                lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, fileReader);

                lz77TokenWriter.WriteToken(lz77Token, fileWriter, bitsForOffset, bitsForLength);
            }

            fileWriter.Flush();
        }
    }
}