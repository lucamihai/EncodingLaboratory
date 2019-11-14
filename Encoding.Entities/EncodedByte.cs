﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities
{
    public class EncodedByte
    {
        [ExcludeFromCodeCoverage]
        public byte Byte { get; set; }
        public List<bool> EncodingBits { get; }

        public uint EncodedValue
        {
            get
            {
                uint value = 0;

                for (int index = EncodingBits.Count - 1; index >= 0; index--)
                {
                    if (!EncodingBits[EncodingBits.Count - 1 - index])
                    {
                        continue;
                    }

                    value += (uint)1 << index;
                }

                return value;
            }
        }

        public EncodedByte()
        {
            EncodingBits = new List<bool>();
        }
    }
}
