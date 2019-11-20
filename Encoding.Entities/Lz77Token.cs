using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities
{
    [ExcludeFromCodeCoverage]
    public class Lz77Token
    {
        public int Position { get; set; }
        public int Length { get; set; }
        public byte Byte { get; set; }
    }
}