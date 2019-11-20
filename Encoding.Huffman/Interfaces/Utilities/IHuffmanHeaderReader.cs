using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IHuffmanHeaderReader
    {
        List<ByteStatistics> ReadByteStatistics(IFileReader fileReader);
    }
}