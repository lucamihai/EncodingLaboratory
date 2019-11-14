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
            var maximumNumberOfBits = encodedBytes.Max(x => x.EncodingBits.Count);

            var decodedText = string.Empty;
            var charactersLeftToRead = characterStatistics.Sum(x => x.Apparitions);

            while (charactersLeftToRead > 0)
            {
                char? currentCharacter = null;
                var currentBits = new List<bool>();

                while (currentCharacter == null)
                {
                    if (currentBits.Count >= maximumNumberOfBits)
                    {
                        throw new InvalidOperationException($"There is no character coded as '{string.Join("", currentBits)}'");
                    }

                    currentBits.Add(fileReader.ReadBit());
                    currentCharacter = GetCharIfThereIsAnEncodedByteForIt(currentBits.AsQueryable().Reverse().ToList(), encodedBytes);
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

                if (comparer.Compare(currentBits, encodedByteBits).AreEqual && !ThereAreNoEncodedBytesContainingThisSequenceOfBitesAsASubsequence(currentBits, encodedBytes))
                {
                    character = (char)encodedByte.Byte;
                    break;
                }
            }

            return character;
        }

        private bool ThereAreNoEncodedBytesContainingThisSequenceOfBitesAsASubsequence(List<bool> currentBits, List<EncodedByte> encodedBytes)
        {
            foreach (var encodedByte in encodedBytes)
            {
                var encodedByteBits = encodedByte.EncodingBits;

                for (int index = 0; index < currentBits.Count; index++)
                {
                    if (currentBits[index] != encodedByteBits[index])
                    {
                        break;
                    }

                    if (index == currentBits.Count - 1)
                    {
                        if (currentBits.Count == encodedByteBits.Count)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
