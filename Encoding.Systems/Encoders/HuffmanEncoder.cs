using System;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Encoders
{
    public class HuffmanEncoder
    {
        private readonly ITextAnalyzer textAnalyzer;
        private readonly IHuffmanEncodedBytesManager huffmanEncodedBytesManager;
        private readonly IHuffmanHeaderWriter huffmanHeaderWriter;

        public HuffmanEncoder(ITextAnalyzer textAnalyzer, IHuffmanEncodedBytesManager huffmanEncodedBytesManager, IHuffmanHeaderWriter huffmanHeaderWriter)
        {
            this.textAnalyzer = textAnalyzer;
            this.huffmanEncodedBytesManager = huffmanEncodedBytesManager;
            this.huffmanHeaderWriter = huffmanHeaderWriter;
        }

        public void EncodeTextToFile(string text, IFileWriter fileWriter)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            var characterStatistics = textAnalyzer.GetCharacterStatisticsFromText(text);
            var encodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromCharacterStatistics(characterStatistics);

            huffmanHeaderWriter.WriteHeaderToFile(characterStatistics, fileWriter);

            foreach (var character in text)
            {
                var encodedByteForCurrentCharacter = encodedBytes.First(x => x.Byte == (byte) character);
                fileWriter.WriteValueOnBits(encodedByteForCurrentCharacter.EncodedValue, (byte)encodedByteForCurrentCharacter.EncodingBits.Count);
            }
        }
    }
}
