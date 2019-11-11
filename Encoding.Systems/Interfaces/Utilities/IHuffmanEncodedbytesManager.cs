using System.Collections.Generic;
using Encoding.Entities;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface IHuffmanEncodedBytesManager
    {
        List<EncodedByte> GetEncodedBytesFromCharacterStatistics(List<CharacterStatistics> characterStatistics);
    }
}