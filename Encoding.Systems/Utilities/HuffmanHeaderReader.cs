using System;
using System.Collections.Generic;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class HuffmanHeaderReader : IHuffmanHeaderReader
    {
        public List<CharacterStatistics> ReadCharacterStatistics(IFileReader fileReader)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            var characterStatistics = new List<CharacterStatistics>();
            var bytesNecessaryForCharacterStatistics = GetBytesNecessaryForCharacterStatistics(fileReader);

            foreach (var characterStats in bytesNecessaryForCharacterStatistics.Keys)
            {
                var bitsToRead = bytesNecessaryForCharacterStatistics[characterStats] * 8;
                characterStats.Apparitions = fileReader.ReadBits((byte)bitsToRead);

                characterStatistics.Add(characterStats);
            }

            return characterStatistics;
        }

        private Dictionary<CharacterStatistics, uint> GetBytesNecessaryForCharacterStatistics(IFileReader fileReader)
        {
            var bytesNecessaryForCharacterStatistics = new Dictionary<CharacterStatistics, uint>();

            for (int characterCode = 0; characterCode < 256; characterCode++)
            {
                var bytesNecessaryForCurrentCharacterCode = fileReader.ReadBits(2);

                if (bytesNecessaryForCurrentCharacterCode == 0)
                {
                    continue;
                }

                var characterStats = new CharacterStatistics { Character = (char)characterCode };
                bytesNecessaryForCharacterStatistics.Add(characterStats, bytesNecessaryForCurrentCharacterCode);
            }

            return bytesNecessaryForCharacterStatistics;
        }
    }
}