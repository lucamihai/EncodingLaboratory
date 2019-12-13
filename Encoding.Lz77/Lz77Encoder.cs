using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77
{
    public class Lz77Encoder : ILz77Encoder
    {
        public Lz77Buffer Lz77Buffer { get; private set; }
        public List<Lz77Token> TokensFromPreviousRun { get; }

        private readonly ILz77TokenExtractor lz77TokenExtractor;
        private readonly ILz77BufferManager lz77BufferManager;
        private readonly ILz77TokenWriter lz77TokenWriter;

        public Lz77Encoder(ILz77TokenExtractor lz77TokenExtractor, ILz77BufferManager lz77BufferManager, ILz77TokenWriter lz77TokenWriter)
        {
            this.lz77TokenExtractor = lz77TokenExtractor;
            this.lz77BufferManager = lz77BufferManager;
            this.lz77TokenWriter = lz77TokenWriter;

            Lz77Buffer = new Lz77Buffer(4, 4);

            TokensFromPreviousRun = new List<Lz77Token>();
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

            if (Lz77Buffer.Length != bitsForLength || Lz77Buffer.Offset != bitsForOffset)
            {
                Lz77Buffer.SetOffsetAndLimit(bitsForLength, bitsForLength);
            }

            WriteHeader(fileWriter, bitsForOffset, bitsForLength);

            TokensFromPreviousRun.Clear();
            lz77BufferManager.TryToFillLookAheadBuffer(Lz77Buffer, fileReader);

            while (Lz77Buffer.LookAheadBuffer.Count > 0)
            {
                var lz77Token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(Lz77Buffer);

                lz77BufferManager.TryToFillSearchBufferBasedOnLz77Token(Lz77Buffer, lz77Token);
                lz77BufferManager.EmptyLookAheadBufferBasedOnLz77Token(Lz77Buffer, lz77Token);
                lz77BufferManager.TryToFillLookAheadBuffer(Lz77Buffer, fileReader);

                lz77TokenWriter.WriteToken(lz77Token, fileWriter, bitsForOffset, bitsForLength);

                TokensFromPreviousRun.Add(lz77Token);
            }

            fileWriter.Flush();
        }

        private void WriteHeader(IFileWriter fileWriter, int bitsForOffset, int bitsForLength)
        {
            fileWriter.WriteValueOnBits((uint)bitsForOffset, 4);
            fileWriter.WriteValueOnBits((uint)bitsForLength, 3);
        }
    }
}