using System.Collections.Generic;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface IHuffmanHeaderReader
    {
        List<ByteStatistics> ReadByteStatistics(IFileReader fileReader);
    }
}