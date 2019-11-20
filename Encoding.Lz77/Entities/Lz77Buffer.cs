using System;
using System.Collections.Generic;

namespace Encoding.Lz77.Entities
{
    public class Lz77Buffer
    {
        public int Offset { get; }
        public int Length { get; }

        public List<byte> SearchBuffer { get; }
        public List<byte> LookAheadBuffer { get; }

        public Lz77Buffer(int offset, int length)
        {
            if (offset < 1)
            {
                throw new ArgumentException($"{nameof(offset)} should be at least 1");
            }

            if (length < 1)
            {
                throw new ArgumentException($"{nameof(length)} should be at least 1");
            }

            Offset = offset;
            Length = length;

            var searchBufferCapacity = (int)Math.Pow(2, offset) - 1;
            var lookAheadBufferCapacity = (int)Math.Pow(2, length) - 1;

            SearchBuffer = new List<byte>(searchBufferCapacity);
            LookAheadBuffer = new List<byte>(lookAheadBufferCapacity);
        }
    }
}