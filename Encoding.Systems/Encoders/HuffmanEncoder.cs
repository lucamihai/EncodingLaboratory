using System;
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

            //while (characterStatistics.Count > 0)
            //{
            //    var firstMinimum = characterStatistics.Min(x => x.Apparitions);
            //}

            return head;
        }
    }
}
