using Encoding.Lz77.Entities;

namespace Encoding.Lz77.Interfaces.Utilities
{
    public interface ILz77TokenExtractor
    {
        Lz77Token GetLz77TokenFromLz77Buffer(Lz77Buffer lz77Buffer);
    }
}