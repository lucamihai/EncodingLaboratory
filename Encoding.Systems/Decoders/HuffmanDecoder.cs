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

                if (currentBits.Count != encodedByteBits.Count)
                {
                    continue;
                }

                if (GetValueFromBoolList(encodedByteBits) != GetValueFromBoolList(currentBits))
                {
                    continue;
                }

                if (!BitsAreContainedMoreThanOneTimeInEncodedBytes(currentBits, encodedBytes))
                {
                    character = (char)encodedByte.Byte;
                }
            }

            return character;
        }

        private uint GetValueFromBoolList(List<bool> boolList)
        {
            uint value = 0;

            for (int index = 0; index < boolList.Count; index++)
            {
                if (!boolList[index])
                {
                    continue;
                } 

                value += (uint)1 << index;
            }

            return value;
        }

        private bool BitsAreContainedMoreThanOneTimeInEncodedBytes(List<bool> bits, List<EncodedByte> encodedBytes)
        {
            var count = 0;

            foreach (var encodedByte in encodedBytes)
            {
                var encodedByteBits = encodedByte.EncodingBits;

                if (encodedByteBits.Count < bits.Count)
                {
                    continue;
                }

                var isFound = true;
                for (int index = 0; index < bits.Count; index++)
                {
                    if (bits[index] != encodedByteBits[index])
                    {
                        isFound = false;
                        break;
                    }
                }

                if (isFound)
                {
                    count++;
                }
            }

            return count > 1;
        }
    }
}
