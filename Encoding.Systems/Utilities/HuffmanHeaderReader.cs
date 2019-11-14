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
            var bitsNecessaryForCharacterStatistics = GetBitsNecessaryForCharacterStatistics(fileReader);

            foreach (var characterStats in bitsNecessaryForCharacterStatistics.Keys)
            {
                var bitsToRead = bitsNecessaryForCharacterStatistics[characterStats] * 8;
                characterStats.Apparitions = fileReader.ReadBits((byte)bitsToRead);

                characterStatistics.Add(characterStats);
            }

            return characterStatistics;
        }

        private Dictionary<CharacterStatistics, uint> GetBitsNecessaryForCharacterStatistics(IFileReader fileReader)
        {
            var bitsNecessaryForCharacterStatistics = new Dictionary<CharacterStatistics, uint>();

            for (int characterCode = 0; characterCode < 256; characterCode++)
            {
                var bitsNecessaryForCurrentCharacterCode = fileReader.ReadBits(2);

                if (bitsNecessaryForCurrentCharacterCode == 0)
                {
                    continue;
                }

                var characterStats = new CharacterStatistics { Character = (char)characterCode };
                bitsNecessaryForCharacterStatistics.Add(characterStats, bitsNecessaryForCurrentCharacterCode);
            }

            return bitsNecessaryForCharacterStatistics;
        }
    }
}