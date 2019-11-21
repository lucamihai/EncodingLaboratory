using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Options;

namespace Encoding.LzW
{
    public class LzWEncoder
    {
        public Dictionary<string, int> Dictionary { get; private set; }
        public int DictionaryKeysLimit { get; private set; }

        private int dictionaryLastIndex;

        public LzWEncoder()
        {
            Dictionary = new Dictionary<string, int>();

            for (int key = 0; key < 256; key++)
            {
                Dictionary.Add(((char)key).ToString(), key);
            }

            dictionaryLastIndex = 255;
        }

        public void EncodeFile(IFileReader fileReader, IFileWriter fileWriter, OnFullDictionaryOption onFullDictionaryOption, int numberOfBitsIndex)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            if (numberOfBitsIndex < 9 || numberOfBitsIndex > 15)
            {
                throw new ArgumentException($"{nameof(numberOfBitsIndex)} must be at least 9, and at most 15");
            }

            DictionaryKeysLimit = (int)Math.Pow(2, numberOfBitsIndex) - 1;
            WriteHeader(fileWriter, onFullDictionaryOption, numberOfBitsIndex);

            char? lastCharacter = null;

            while (!fileReader.ReachedEndOfFile)
            {
                var currentString = lastCharacter.HasValue ? lastCharacter.Value.ToString() : string.Empty;
                var lastIndex = 0;

                if (currentString == string.Empty)
                {
                    var readByte = (byte)fileReader.ReadBits(8);
                    currentString += (char)readByte;
                    lastCharacter = (char)readByte;
                }

                while (true)
                {
                    if (Dictionary.ContainsKey(currentString))
                    {
                        lastIndex = Dictionary[currentString];
                    }
                    else
                    {
                        if (Dictionary.Count >= DictionaryKeysLimit)
                        {
                            if (onFullDictionaryOption == OnFullDictionaryOption.Empty)
                            {
                                EmptyDictionaryExceptDefaultPairs();

                                Dictionary.Add(currentString, dictionaryLastIndex);
                                dictionaryLastIndex++;
                            }
                        }
                        else
                        {
                            Dictionary.Add(currentString, dictionaryLastIndex);
                            dictionaryLastIndex++;
                        }

                        fileWriter.WriteValueOnBits((uint)lastIndex, (byte)numberOfBitsIndex);

                        break;
                    }

                    var readByte = (byte)fileReader.ReadBits(8);
                    currentString += (char)readByte;
                    lastCharacter = (char)readByte;
                }
            }

            fileWriter.Flush();
        }

        private void WriteHeader(IFileWriter fileWriter, OnFullDictionaryOption onFullDictionaryOption, int numberOfBitsIndex)
        {
            var cv = (uint)onFullDictionaryOption;

            fileWriter.WriteValueOnBits((uint)numberOfBitsIndex, 4);
            fileWriter.WriteValueOnBits(onFullDictionaryOption == OnFullDictionaryOption.Empty ? (uint)0 : (uint)1, 1);
        }

        private void EmptyDictionaryExceptDefaultPairs()
        {
            Dictionary = Dictionary
                .Take(256)
                .ToDictionary(x => x.Key, x => x.Value);

            dictionaryLastIndex = 255;
        }
    }
}
