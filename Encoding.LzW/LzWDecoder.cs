﻿using System;
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
            WriteStringToFile(firstString, fileWriter);

            var lastString = firstString;

            while (!fileReader.ReachedEndOfFile && fileReader.BitsLeft >= numberOfBitsForIndex)
            {
                var currentIndex = (int)fileReader.ReadBits(numberOfBitsForIndex);
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

                WriteStringToFile(currentString, fileWriter);
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

        private void WriteStringToFile(string s, IFileWriter fileWriter)
        {
            foreach (var character in s)
            {
                fileWriter.WriteValueOnBits((byte)character, 8);
            }
        }
    }
}