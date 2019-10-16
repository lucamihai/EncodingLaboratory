using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;

namespace Encoding.Systems.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string Text1 = "Ana has apples";
        public static List<CharacterStatistics> TextCharacterStatistics1 => new List<CharacterStatistics>
        {
            new CharacterStatistics
            {
                Character = ' ',
                Apparitions = 2
            },
            new CharacterStatistics
            {
                Character = 'A',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'a',
                Apparitions = 3
            },
            new CharacterStatistics
            {
                Character = 'e',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'h',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'l',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'n',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'p',
                Apparitions = 2
            },
            new CharacterStatistics
            {
                Character = 's',
                Apparitions = 2
            }
        };
    }
}
