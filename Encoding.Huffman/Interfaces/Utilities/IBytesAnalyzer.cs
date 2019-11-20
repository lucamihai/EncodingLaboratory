using System.Collections.Generic;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IBytesAnalyzer
    {
        List<ByteStatistics> GetByteStatisticsFromBytes(byte[] bytes);
    }
}
