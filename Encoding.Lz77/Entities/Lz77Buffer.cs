using System;
using System.Collections.Generic;

namespace Encoding.Lz77.Entities
{
    public class Lz77Buffer
    {
        public int Offset { get; private set; }
        public int Length { get; private set; }

        public List<byte> SearchBuffer { get; private set; }
        public List<byte> LookAheadBuffer { get; private set; }

        public Lz77Buffer(int offset, int length)
        {
            SetOffsetAndLimit(offset, length);
        }

        public void SetOffsetAndLimit(int offset, int length)
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