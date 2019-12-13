using System;
using System.Collections.Generic;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman.Utilities
{
    public class HuffmanEncodedBytesManager : IHuffmanEncodedBytesManager
    {
        private readonly IHuffmanNodesManager huffmanNodesManager;

        public HuffmanEncodedBytesManager(IHuffmanNodesManager huffmanNodesManager)
        {
            this.huffmanNodesManager = huffmanNodesManager;
        }

        public List<EncodedByte> GetEncodedBytesFromByteStatistics(List<ByteStatistics> characterStatistics)
        {
            if (characterStatistics == null)
            {
                throw new ArgumentNullException(nameof(characterStatistics));
            }

            var huffmanTreeRoot = huffmanNodesManager.GetNodeFromByteStatistics(characterStatistics);

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
                huffmanNodesManager.SetPathFromNodeToParent(encodedByte.EncodingBits, node, huffmanTreeRoot, 100);

                encodedBytes.Add(encodedByte);
            }

            return encodedBytes;
        }
    }
}