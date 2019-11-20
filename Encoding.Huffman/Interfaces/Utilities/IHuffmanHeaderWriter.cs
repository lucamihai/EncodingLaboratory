using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IHuffmanHeaderWriter
    {
        void WriteHeaderToFile(List<ByteStatistics> byteStatistics, IFileWriter fileWriter);
    }
}