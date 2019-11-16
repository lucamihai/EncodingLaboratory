using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class BytesAnalyzer : IBytesAnalyzer
    {
        public List<ByteStatistics> GetByteStatisticsFromBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException();
            }

            var byteStatisticsList = new List<ByteStatistics>();

            var uniqueBytes = bytes
                .Distinct()
                .ToList();

            foreach (var uniqueByte in uniqueBytes)
            {
                var characterFrequency = bytes.Count(x => x == uniqueByte);
                var characterStatistics = new ByteStatistics
                {
                    Byte = uniqueByte,
                    Apparitions = (uint)characterFrequency
                };

                byteStatisticsList.Add(characterStatistics);
            }

            return byteStatisticsList
                .OrderBy(x => x.Byte)
                .ToList();
        }
    }
}
