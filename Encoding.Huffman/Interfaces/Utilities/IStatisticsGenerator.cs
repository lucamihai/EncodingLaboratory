using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IStatisticsGenerator
    {
        List<ByteStatistics> GetByteStatisticsFromFile(IFileReader fileReader);
    }
}
