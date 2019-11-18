using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Encoders
{
    public class HuffmanEncoder
    {
        private readonly IBytesAnalyzer bytesAnalyzer;
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

        public HuffmanEncoder(IBytesAnalyzer bytesAnalyzer, IHuffmanEncodedBytesManager huffmanEncodedBytesManager, IHuffmanHeaderWriter huffmanHeaderWriter)
        {
            this.bytesAnalyzer = bytesAnalyzer;
            this.huffmanEncodedBytesManager = huffmanEncodedBytesManager;
            this.huffmanHeaderWriter = huffmanHeaderWriter;
        }

        public void EncodeBytesToFile(byte[] bytes, IFileWriter fileWriter)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            var byteStatistics = bytesAnalyzer.GetByteStatisticsFromBytes(bytes);
            var encodedBytes = huffmanEncodedBytesManager.GetEncodedBytesFromByteStatistics(byteStatistics);
            encodedBytesFromPreviousRun = encodedBytes;

            huffmanHeaderWriter.WriteHeaderToFile(byteStatistics, fileWriter);

            foreach (var currentByte in bytes)
            {
                var encodedByteForCurrentCharacter = encodedBytes.First(x => x.Byte == currentByte);
                fileWriter.WriteValueOnBits(encodedByteForCurrentCharacter.EncodedValue, (byte)encodedByteForCurrentCharacter.EncodingBits.Count);
            }
        }
    }
}
