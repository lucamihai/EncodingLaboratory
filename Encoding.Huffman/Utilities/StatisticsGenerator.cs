using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman.Utilities
{
    public class StatisticsGenerator : IStatisticsGenerator
    {
        public List<ByteStatistics> GetByteStatisticsFromFile(IFileReader fileReader)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException();
            }

            var byteApparitions = new uint[256];

            while (!fileReader.ReachedEndOfFile)
            {
                var readByte = fileReader.ReadBits(8);
                byteApparitions[readByte]++;
            }

            var byteStatisticsList = new List<ByteStatistics>();
            for (int currentByte = 0; currentByte < 256; currentByte++)
            {
                byteStatisticsList.Add(new ByteStatistics {Byte = (byte) currentByte, Apparitions = byteApparitions[currentByte]});
            }

            return byteStatisticsList;
        }
    }
}
