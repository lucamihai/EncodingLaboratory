using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Encoders
{
    public class HuffmanEncoder
    {
        public ITextAnalyzer TextAnalyzer { get; }

        public HuffmanEncoder(ITextAnalyzer textAnalyzer)
        {
            TextAnalyzer = textAnalyzer;
        }

        public Node GetNodesForText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }

            var characterStatistics = TextAnalyzer.GetCharacterStatisticsFromText(text);
            var nodes = GenerateNodeListFromCharacterStatisticsList(characterStatistics);

            while (nodes.Count > 1)
            {
                var firstMinimum = nodes.Min(x => x.NodeInfo);
                var firstNode = nodes.First(x => x.NodeInfo == firstMinimum);
                nodes.Remove(firstNode);

                var secondMinimum = nodes.Min(x => x.NodeInfo);
                var secondNode = nodes.First(x => x.NodeInfo == secondMinimum);
                nodes.Remove(secondNode);

                var newNode = new Node
                {
                    LeftChild = firstNode,
                    RightChild = secondNode,
                    NodeInfo = new NodeInfo
                    {
                        NumericValue = firstNode.NodeInfo.NumericValue + secondNode.NodeInfo.NumericValue
                    }
                };
                nodes.Add(newNode);
            }

            return nodes.Count == 1
                ? nodes[0]
                : new Node();
        }

        private List<Node> GenerateNodeListFromCharacterStatisticsList(List<CharacterStatistics> characterStatisticsList)
        {
            var nodes = new List<Node>();

            foreach (var characterStatistics in characterStatisticsList)
            {
                var node = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = characterStatistics.Apparitions, Code = (byte)characterStatistics.Character}
                };

                nodes.Add(node);
            }

            return nodes;
        }
    }
}
