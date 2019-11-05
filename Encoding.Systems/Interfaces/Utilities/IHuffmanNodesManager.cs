using System.Collections.Generic;
using Encoding.Entities;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface IHuffmanNodesManager
    {
        Node GetNodeFromCharacterStatistics(List<CharacterStatistics> characterStatistics);
        void SetPathFromNodeToParent(List<bool> path, Node node, Node parent, int maxNodesToClimb);
    }
}
