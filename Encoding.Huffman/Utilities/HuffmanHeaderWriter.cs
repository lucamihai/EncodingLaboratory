using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman.Utilities
{
    public class HuffmanHeaderWriter : IHuffmanHeaderWriter
    {
        public void WriteHeaderToFile(List<ByteStatistics> byteStatistics, IFileWriter fileWriter)
        {
            var byteApparitionsToWrite = new List<uint>();

            for (int currentByte = 0; currentByte < 256; currentByte++)
            {
                var stats = byteStatistics.FirstOrDefault(x => x.Byte == (char)currentByte);
                if (stats != null)
                {
                    byteApparitionsToWrite.Add(stats.Apparitions);
                    var numberOfBitsNecessaryToWriteApparitions = stats.Apparitions > Math.Pow(2, 16)
                        ? 3
                        : stats.Apparitions > Math.Pow(2, 8)
                            ? 2
                            : 1;

                    fileWriter.WriteValueOnBits((uint)numberOfBitsNecessaryToWriteApparitions, 2);
                }
                else
                {
                    fileWriter.WriteValueOnBits(0, 2);
                }
            }

            foreach (var apparition in byteApparitionsToWrite)
            {
                var numberOfBitsNecessaryToWriteApparitions = apparition > Math.Pow(2, 16)
                    ? 32
                    : apparition > Math.Pow(2, 8)
                        ? 16
                        : 8;

                fileWriter.WriteValueOnBits(apparition, (byte)numberOfBitsNecessaryToWriteApparitions);
            }
        }
    }
}