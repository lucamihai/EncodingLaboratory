using System;
using Encoding.FileOperations;
using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Entities;
using Encoding.LzW.Interfaces;
using Encoding.LzW.Options;

namespace Encoding.LzW
{
    public class LzWDecoder : ILzWDecoder
    {
        private LzWDictionary lzWDictionary;
        private byte numberOfBitsForIndex;

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

            InterpretHeader(fileReader);

            var firstIndex = fileReader.ReadBits(numberOfBitsForIndex);
            var firstString = lzWDictionary.GetStringByIndex(firstIndex);
            firstString.WriteToFile(fileWriter);

            var lastString = firstString;

            while (!fileReader.ReachedEndOfFile && fileReader.BitsLeft >= numberOfBitsForIndex)
            {
                var currentIndex = fileReader.ReadBits(numberOfBitsForIndex);
                string currentString;

                if (lzWDictionary.ContainsIndex(currentIndex))
                {
                    currentString = lzWDictionary.GetStringByIndex(currentIndex);

                    var dictionaryNewString = lastString + currentString[0];
                    lzWDictionary.Add(dictionaryNewString);
                }
                else
                {
                    var dictionaryNewString = lastString + lastString[0];
                    lzWDictionary.Add(dictionaryNewString);

                    currentString = lzWDictionary.GetStringByIndex(currentIndex);
                }

                currentString.WriteToFile(fileWriter);
                lastString = currentString;
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
    }
}