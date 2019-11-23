using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces.Utilities;

namespace Encoding.Huffman
{
    public class HuffmanEncoder
    {
        private readonly IStatisticsGenerator statisticsGenerator;
        private readonly IHuffmanEncodedBytesManager huffmanEncodedBytesManager;
        private readonly IHuffmanHeaderWriter huffmanHeaderWriter;

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

        public HuffmanEncoder(IStatisticsGenerator statisticsGenerator, IHuffmanEncodedBytesManager huffmanEncodedBytesManager, IHuffmanHeaderWriter huffmanHeaderWriter)
        {
            this.statisticsGenerator = statisticsGenerator;
            this.huffmanEncodedBytesManager = huffmanEncodedBytesManager;
            this.huffmanHeaderWriter = huffmanHeaderWriter;
        }

        public void EncodeFile(IFileReader fileReader, IFileWriter fileWriter)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            var byteStatistics = statisticsGenerator.GetByteStatisticsFromFile(fileReader);
            var encodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(byteStatistics);
            encodedBytesFromPreviousRun = encodedBytes;

            huffmanHeaderWriter.WriteHeaderToFile(byteStatistics, fileWriter);
            fileReader.Reset();

            while (!fileReader.ReachedEndOfFile)
            {
                var currentByte = fileReader.ReadBits(8);
                var encodedByteForCurrentCharacter = encodedBytes.First(x => x.Byte == currentByte);
                fileWriter.WriteValueOnBits(encodedByteForCurrentCharacter.EncodedValue, (byte)encodedByteForCurrentCharacter.EncodingBits.Count);
            }
        }
    }
}
