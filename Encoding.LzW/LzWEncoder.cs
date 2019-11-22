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
        public List<int> IndexesFromLastRun { get; }

        private int dictionaryLastIndex;

        public LzWEncoder()
        {
            Dictionary = new Dictionary<string, int>();

            for (int key = 0; key < 256; key++)
            {
                Dictionary.Add(((char)key).ToString(), key);
            }

            dictionaryLastIndex = 255;

            IndexesFromLastRun = new List<int>();
        }

        public void EncodeFile(IFileReader fileReader, IFileWriter fileWriter, OnFullDictionaryOption onFullDictionaryOption, int numberOfBitsIndex)
        {
            EmptyDictionaryExceptDefaultPairs();

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
            IndexesFromLastRun.Clear();

            var lastCharacter = (char)fileReader.ReadBits(8);

            while (!fileReader.ReachedEndOfFile)
            {
                var currentString = lastCharacter.ToString();
                var lastIndex = 0;

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

                                dictionaryLastIndex++;
                                Dictionary.Add(currentString, dictionaryLastIndex);
                            }
                        }
                        else
                        {
                            dictionaryLastIndex++;
                            Dictionary.Add(currentString, dictionaryLastIndex);
                        }

                        fileWriter.WriteValueOnBits((uint)lastIndex, (byte)numberOfBitsIndex);
                        IndexesFromLastRun.Add(lastIndex);

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
            fileWriter.WriteValueOnBits((uint)numberOfBitsIndex, 4);
            fileWriter.WriteValueOnBits((uint)onFullDictionaryOption, 1);
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
