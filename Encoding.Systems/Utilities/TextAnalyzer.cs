using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class TextAnalyzer : ITextAnalyzer
    {
        public List<CharacterStatistics> GetCharacterStatisticsFromText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }

            var characterStatisticsList = new List<CharacterStatistics>();

            var textCharArray = text.ToCharArray();
            var uniqueCharacters = textCharArray
                .Distinct()
                .ToList();

            foreach (var uniqueCharacter in uniqueCharacters)
            {
                var characterFrequency = textCharArray.Count(x => x == uniqueCharacter);
                var characterStatistics = new CharacterStatistics
                {
                    Character = uniqueCharacter,
                    Apparitions = (uint)characterFrequency
                };

                characterStatisticsList.Add(characterStatistics);
            }

            return characterStatisticsList
                .OrderBy(x => x.Character)
                .ToList();
        }
    }
}
