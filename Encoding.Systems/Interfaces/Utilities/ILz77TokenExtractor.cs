using Encoding.Entities;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface ILz77TokenExtractor
    {
        Lz77Token GetLz77TokenFromLz77Buffer(Lz77Buffer lz77Buffer);
    }
}