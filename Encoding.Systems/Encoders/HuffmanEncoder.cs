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
            var head = new Node();
            var nodes = GenerateNodeListFromCharacterStatisticsList(characterStatistics);

            while (nodes.Count > 1)
            {
                var firstMinimum = nodes.Min(x => x.NodeInfo);
                var firstNode = nodes.First(x => x.NodeInfo == firstMinimum);
                nodes.Remove(firstNode);
            }

            return head;
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
