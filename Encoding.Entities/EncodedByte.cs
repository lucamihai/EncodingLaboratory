using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities
{
    [ExcludeFromCodeCoverage]
    public class EncodedByte
    {
        public byte Byte { get; set; }
        public List<bool> EncodingBits { get; }

        public EncodedByte()
        {
            EncodingBits = new List<bool>();
        }
    }
}
