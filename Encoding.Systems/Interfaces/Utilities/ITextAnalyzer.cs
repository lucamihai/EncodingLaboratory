using System.Collections.Generic;
using Encoding.Entities;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface ITextAnalyzer
    {
        List<CharacterStatistics> GetCharacterStatisticsFromText(string text);
    }
}
