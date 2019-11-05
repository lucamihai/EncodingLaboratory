using System;
using System.Collections.Generic;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Encoders
{
    public class HuffmanEncoder
    {
        public ITextAnalyzer TextAnalyzer { get; }
        public IHuffmanNodesManager HuffmanNodesManager { get; }

        public HuffmanEncoder(ITextAnalyzer textAnalyzer, IHuffmanNodesManager huffmanNodesManager)
        {
            TextAnalyzer = textAnalyzer;
            HuffmanNodesManager = huffmanNodesManager;
        }

        public List<EncodedByte> GetEncodedBytesForText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }

            var characterStatistics = TextAnalyzer.GetCharacterStatisticsFromText(text);
            var huffmanTreeRoot = HuffmanNodesManager.GetNodeFromCharacterStatistics(characterStatistics);

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

                var encodedByte = new EncodedByte {Byte = node.NodeInfo.Code.Value};
                HuffmanNodesManager.SetPathFromNodeToParent(encodedByte.EncodingBits, node, huffmanTreeRoot, 20);

                encodedBytes.Add(encodedByte);
            }

            return encodedBytes;
        }
    }
}
