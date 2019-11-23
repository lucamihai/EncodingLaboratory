using System;
using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Entities;
using Encoding.LzW.Options;

namespace Encoding.LzW
{
    public class LzWDecoder
    {
        private LzWDictionary lzWDictionary;
        private byte numberOfBitsForIndex;

        public void DecodeFile(IFileReader fileReader, IFileWriter fileWriter)
        {
            InterpretHeader(fileReader);

            var firstIndex = (int)fileReader.ReadBits(numberOfBitsForIndex);
            var firstString = lzWDictionary.GetStringByIndex(firstIndex);
            var lastString = firstString;
            
            WriteString(firstString, fileWriter);

            while (!fileReader.ReachedEndOfFile)
            {
                var currentIndex = (int)fileReader.ReadBits(numberOfBitsForIndex);

                if (lzWDictionary.ContainsIndex(currentIndex))
                {
                    var currentString = lzWDictionary.GetStringByIndex(currentIndex);
                    WriteString(currentString, fileWriter);

                    lzWDictionary.Add(lastString + currentString[0]);
                    lastString = currentString;
                }
            }
        }

        private void InterpretHeader(IFileReader fileReader)
        {
            numberOfBitsForIndex = (byte)fileReader.ReadBits(4);

            var onFullDictionaryOption = fileReader.ReadBit()
                ? OnFullDictionaryOption.Freeze
                : OnFullDictionaryOption.Empty;

            lzWDictionary = new LzWDictionary((int)Math.Pow(2, numberOfBitsForIndex) - 1, onFullDictionaryOption);
        }

        private void WriteString(string s, IFileWriter fileWriter)
        {
            foreach (var character in s)
            {
                var b = (byte) character;
                fileWriter.WriteValueOnBits((byte)character, 8);
            }
        }
    }
}