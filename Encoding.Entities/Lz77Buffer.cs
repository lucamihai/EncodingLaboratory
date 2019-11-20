using System;
using System.Collections.Generic;

namespace Encoding.Entities
{
    public class Lz77Buffer
    {
        public int Offset { get; }
        public int Length { get; }

        public List<byte> SearchBuffer { get; }
        public List<byte> LookAheadBuffer { get; }

        public Lz77Buffer(int offset, int length)
        {
            Offset = offset;
            Length = length;

            var searchBufferCapacity = (int)Math.Pow(offset, 2) - 1;
            var lookAheadBufferCapacity = (int)Math.Pow(length, 2) - 1;

            SearchBuffer = new List<byte>(searchBufferCapacity);
            LookAheadBuffer = new List<byte>(lookAheadBufferCapacity);
        }
    }
}