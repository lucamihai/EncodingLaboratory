using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces;

namespace Encoding.Lz77
{
    public class Lz77Decoder : ILz77Decoder
    {
        public List<Lz77Token> TokensFromPreviousRun { get; private set; }

        public Lz77Decoder()
        {
            TokensFromPreviousRun = new List<Lz77Token>();
        }

        public void DecodeFile(IFileReader fileReader, IFileWriter fileWriter)
        {
            TokensFromPreviousRun.Clear();

            var bitsForOffset = (byte)fileReader.ReadBits(4);
            var bitsForLength = (byte)fileReader.ReadBits(3);

            var bytesBuffer = new List<byte> {Capacity = (int)Math.Pow(2, bitsForOffset) - 1};
            var tokenLengthInBits = bitsForOffset + bitsForLength + 8;

            while (!fileReader.ReachedEndOfFile && fileReader.BitsLeft >= tokenLengthInBits)
            {
                var position = (int) fileReader.ReadBits(bitsForOffset);
                var length = (int) fileReader.ReadBits(bitsForLength);
                var byteRead = (byte) fileReader.ReadBits(8);

                var lz77Token = new Lz77Token
                {
                    Position = position,
                    Length = length,
                    Byte = byteRead
                };
                TokensFromPreviousRun.Add(lz77Token);

                var bytes = GetBytesFromBufferBasedOnToken(bytesBuffer, lz77Token);
                foreach (var b in bytes)
                {
                    AddByteAndPrintIfBufferIsFull(bytesBuffer, b, fileWriter);
                }

                AddByteAndPrintIfBufferIsFull(bytesBuffer, lz77Token.Byte, fileWriter);
            }

            foreach (var byteLeft in bytesBuffer)
            {
                fileWriter.WriteValueOnBits(byteLeft, 8);
            }
        }

        private void AddByteAndPrintIfBufferIsFull(List<byte> bytesBuffer, byte byteToAdd, IFileWriter fileWriter)
        {
            if (bytesBuffer.Count >= bytesBuffer.Capacity)
            {
                fileWriter.WriteValueOnBits(bytesBuffer[0], 8);
                bytesBuffer.RemoveAt(0);
            }

            bytesBuffer.Add(byteToAdd);
        }

        private List<byte> GetBytesFromBufferBasedOnToken(List<byte> buffer, Lz77Token lz77Token)
        {
            var bytes = new List<byte>();

            var position = buffer.Count - 1 - lz77Token.Position;
            position = position < 0 ? 0 : position;

            for (int i = 0; i < lz77Token.Length; i++)
            {
                bytes.Add(buffer[position]);
                position++;
            }


            return bytes;
        }
    }
}