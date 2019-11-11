using System.Collections.Generic;
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

                for (int index = 0; index < EncodingBits.Count; index++)
                {
                    if (!EncodingBits[index])
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
