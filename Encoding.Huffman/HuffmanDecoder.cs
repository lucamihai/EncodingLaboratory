using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman
{
    public class HuffmanDecoder
    {
        private readonly IHuffmanHeaderReader huffmanHeaderReader;
        private readonly IHuffmanEncodedBytesManager huffmanEncodedBytesManager;

        private List<EncodedByte> encodedBytesFromPreviousRun;
        public List<EncodedByte> EncodedBytesFromPreviousRun
        {
            get
            {
                var encodedBytes = new List<EncodedByte>();
                encodedBytes.AddRange(encodedBytesFromPreviousRun);

                return encodedBytes;
            }
        }

        public HuffmanDecoder(IHuffmanHeaderReader huffmanHeaderReader, IHuffmanEncodedBytesManager huffmanEncodedBytesManager)
        {
            this.huffmanHeaderReader = huffmanHeaderReader;
            this.huffmanEncodedBytesManager = huffmanEncodedBytesManager;
        }

        public void DecodeFile(IFileReader fileReader, IFileWriter fileWriter)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            var byteStatistics = huffmanHeaderReader.ReadByteStatistics(fileReader);
            var encodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(byteStatistics);
            var maximumNumberOfBits = encodedBytes.Max(x => x.EncodingBits.Count);

            encodedBytesFromPreviousRun = encodedBytes;

            var charactersLeftToRead = byteStatistics.Sum(x => x.Apparitions);

            while (charactersLeftToRead > 0)
            {
                byte? currentByte = null;
                var currentBits = new List<bool>();

                while (currentByte == null)
                {
                    if (currentBits.Count >= maximumNumberOfBits)
                    {
                        throw new InvalidOperationException($"There is no character coded as '{string.Join("", currentBits)}'");
                    }

                    currentBits.Add(fileReader.ReadBit());
                    currentByte = GetByteIfThereIsAnEncodedByteForIt(currentBits, encodedBytes);
                }

                fileWriter.WriteValueOnBits(currentByte.Value, 8);
                charactersLeftToRead--;
            }
        }

        private byte? GetByteIfThereIsAnEncodedByteForIt(List<bool> currentBits, List<EncodedByte> encodedBytes)
        {
            byte? character = null;

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
                    character = encodedByte.Byte;
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
