using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman.Utilities
{
    public class HuffmanHeaderReader : IHuffmanHeaderReader
    {
        public List<ByteStatistics> ReadByteStatistics(IFileReader fileReader)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            var characterStatistics = new List<ByteStatistics>();
            var bytesNecessaryForCharacterStatistics = GetBytesNecessaryForCharacterStatistics(fileReader);

            foreach (var characterStats in bytesNecessaryForCharacterStatistics.Keys)
            {
                var bitsToRead = bytesNecessaryForCharacterStatistics[characterStats] * 8;
                characterStats.Apparitions = fileReader.ReadBits((byte)bitsToRead);

                characterStatistics.Add(characterStats);
            }

            return characterStatistics;
        }

        private Dictionary<ByteStatistics, uint> GetBytesNecessaryForCharacterStatistics(IFileReader fileReader)
        {
            var bytesNecessaryForCharacterStatistics = new Dictionary<ByteStatistics, uint>();

            for (int characterCode = 0; characterCode < 256; characterCode++)
            {
                var bytesNecessaryForCurrentCharacterCode = fileReader.ReadBits(2);

                if (bytesNecessaryForCurrentCharacterCode == 0)
                {
                    continue;
                }

                if (bytesNecessaryForCurrentCharacterCode == 3)
                {
                    bytesNecessaryForCurrentCharacterCode = 4;
                }

                var characterStats = new ByteStatistics { Byte = (byte)characterCode };
                bytesNecessaryForCharacterStatistics.Add(characterStats, bytesNecessaryForCurrentCharacterCode);
            }

            return bytesNecessaryForCharacterStatistics;
        }
    }
}