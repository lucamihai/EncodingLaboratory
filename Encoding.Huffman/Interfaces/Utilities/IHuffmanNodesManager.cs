using System.Collections.Generic;
using Encoding.Huffman.Entities;

namespace Encoding.Huffman.Interfaces.Utilities
{
    public interface IHuffmanNodesManager
    {
        Node GetNodeFromByteStatistics(List<ByteStatistics> byteStatistics);
        void SetPathFromNodeToParent(List<bool> path, Node node, Node parent, int maxNodesToClimb);
    }
}
