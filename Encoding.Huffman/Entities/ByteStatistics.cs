using System.Diagnostics.CodeAnalysis;

namespace Encoding.Huffman.Entities
{
    [ExcludeFromCodeCoverage]
    public class ByteStatistics
    {
        public byte Byte { get; set; }
        public uint Apparitions { get; set; }
    }
}
