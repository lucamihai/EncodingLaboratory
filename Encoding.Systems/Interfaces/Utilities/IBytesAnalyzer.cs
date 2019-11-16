using System.Collections.Generic;
using Encoding.Entities;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface IBytesAnalyzer
    {
        List<ByteStatistics> GetByteStatisticsFromBytes(byte[] bytes);
    }
}
