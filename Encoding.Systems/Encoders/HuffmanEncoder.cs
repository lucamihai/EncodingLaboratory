using System;
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
            throw new NotImplementedException();
        }
    }
}
