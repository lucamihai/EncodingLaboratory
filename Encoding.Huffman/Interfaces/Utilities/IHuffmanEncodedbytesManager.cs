using System.Collections.Generic;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IHuffmanEncodedBytesManager
    {
        List<EncodedByte> GetEncodedBytesFromByteStatistics(List<ByteStatistics> characterStatistics);
    }
}