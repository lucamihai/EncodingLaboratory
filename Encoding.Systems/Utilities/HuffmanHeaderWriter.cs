using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class HuffmanHeaderWriter : IHuffmanHeaderWriter
    {
        public void WriteHeaderToFile(List<CharacterStatistics> characterStatistics, IFileWriter fileWriter)
        {
            var byteApparitionsToWrite = new List<uint>();

            for (int currentByte = 0; currentByte < 256; currentByte++)
            {
                var stats = characterStatistics.FirstOrDefault(x => x.Character == (char)currentByte);
                if (stats != null)
                {
                    byteApparitionsToWrite.Add(stats.Apparitions);
                    var numberOfBitsNecessaryToWriteApparitions = stats.Apparitions > short.MaxValue
                        ? 4
                        : stats.Apparitions > byte.MaxValue
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
                var numberOfBitsNecessaryToWriteApparitions = apparition > short.MaxValue
                    ? 32
                    : apparition > byte.MaxValue
                        ? 16
                        : 8;

                fileWriter.WriteValueOnBits(apparition, (byte)numberOfBitsNecessaryToWriteApparitions);
            }
        }
    }
}