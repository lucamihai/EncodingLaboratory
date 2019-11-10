using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities
{
    [ExcludeFromCodeCoverage]
    public class CharacterStatistics
    {
        public char Character { get; set; }
        public uint Apparitions { get; set; }
    }
}
