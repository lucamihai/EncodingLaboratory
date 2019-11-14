using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;
using KellermanSoftware.CompareNetObjects;

namespace Encoding.Systems.Decoders
{
    public class HuffmanDecoder
    {
        private readonly IHuffmanHeaderReader huffmanHeaderReader;
        private readonly IHuffmanEncodedBytesManager huffmanEncodedBytesManager;

        private readonly CompareLogic comparer;

        public HuffmanDecoder(IHuffmanHeaderReader huffmanHeaderReader, IHuffmanEncodedBytesManager huffmanEncodedBytesManager)
        {
            this.huffmanHeaderReader = huffmanHeaderReader;
            this.huffmanEncodedBytesManager = huffmanEncodedBytesManager;

            comparer = new CompareLogic();
        }

        public string GetDecodedText(IFileReader fileReader)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            var characterStatistics = huffmanHeaderReader.ReadCharacterStatistics(fileReader);
            var encodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromCharacterStatistics(characterStatistics);

            var decodedText = string.Empty;
            var charactersLeftToRead = characterStatistics.Sum(x => x.Apparitions);

            while (charactersLeftToRead > 0)
            {
                char? currentCharacter = null;
                var currentBits = new List<bool>();

                while (currentCharacter == null)
                {
                    currentBits.Add(fileReader.ReadBit());
                    currentCharacter = GetCharIfThereIsAnEncodedByteForIt(currentBits, encodedBytes);
                }

                decodedText += currentCharacter.Value;
                charactersLeftToRead--;
            }

            return decodedText;
        }

        private char? GetCharIfThereIsAnEncodedByteForIt(List<bool> currentBits, List<EncodedByte> encodedBytes)
        {
            char? character = null;

            foreach (var encodedByte in encodedBytes)
            {
                var encodedByteBits = encodedByte.EncodingBits;

                if (comparer.Compare(currentBits, encodedByteBits).AreEqual)
                {
                    character = (char)encodedByte.Byte;
                    break;
                }
            }

            return character;
        }
    }
}
