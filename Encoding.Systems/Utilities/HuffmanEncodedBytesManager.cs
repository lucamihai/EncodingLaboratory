using System;
using System.Collections.Generic;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class HuffmanEncodedBytesManager : IHuffmanEncodedBytesManager
    {
        private readonly IHuffmanNodesManager huffmanNodesManager;

        public HuffmanEncodedBytesManager(IHuffmanNodesManager huffmanNodesManager)
        {
            this.huffmanNodesManager = huffmanNodesManager;
        }

        public List<EncodedByte> GetEncodedBytesFromCharacterStatistics(List<CharacterStatistics> characterStatistics)
        {
            if (characterStatistics == null)
            {
                throw new ArgumentNullException(nameof(characterStatistics));
            }

            var huffmanTreeRoot = huffmanNodesManager.GetNodeFromCharacterStatistics(characterStatistics);

            var encodedBytes = new List<EncodedByte>();

            foreach (var node in huffmanTreeRoot.NodesInPreOrder)
            {
                if (node == huffmanTreeRoot)
                {
                    continue;
                }

                if (!node.NodeInfo.Code.HasValue)
                {
                    continue;
                }

                var encodedByte = new EncodedByte { Byte = node.NodeInfo.Code.Value };
                huffmanNodesManager.SetPathFromNodeToParent(encodedByte.EncodingBits, node, huffmanTreeRoot, 20);

                encodedBytes.Add(encodedByte);
            }

            return encodedBytes;
        }
    }
}