using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Entities;
using Encoding.LzW.Options;

namespace Encoding.LzW
{
    public class LzWEncoder
    {
        public LzWDictionary LzWDictionary{ get; private set; }
        public List<uint> IndexesFromLastRun { get; }

        public LzWEncoder()
        {
            IndexesFromLastRun = new List<uint>();
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

            WriteHeader(fileWriter, onFullDictionaryOption, numberOfBitsIndex);
            IndexesFromLastRun.Clear();

            LzWDictionary = new LzWDictionary((int)Math.Pow(2, numberOfBitsIndex) - 1, onFullDictionaryOption);

            var lastCharacter = (char)fileReader.ReadBits(8);
            var shouldStop = false;

            while (true)
            {
                var currentString = lastCharacter.ToString();
                uint lastIndex = 0;

                if (shouldStop)
                {
                    break;
                }

                while (true)
                {
                    if (LzWDictionary.ContainsString(currentString))
                    {
                        lastIndex = LzWDictionary.GetIndexByString(currentString);

                        if (shouldStop)
                        {
                            fileWriter.WriteValueOnBits(lastIndex, (byte)numberOfBitsIndex);
                            IndexesFromLastRun.Add(lastIndex);

                            break;
                        }
                    }
                    else
                    {
                        LzWDictionary.Add(currentString);

                        fileWriter.WriteValueOnBits(lastIndex, (byte)numberOfBitsIndex);
                        IndexesFromLastRun.Add(lastIndex);

                        break;
                    }

                    if (!fileReader.ReachedEndOfFile)
                    {
                        var readByte = (byte)fileReader.ReadBits(8);
                        currentString += (char)readByte;
                        lastCharacter = (char)readByte;
                    }
                    else
                    {
                        shouldStop = true;
                    }
                }
            }

            fileWriter.Flush();
        }

        private void WriteHeader(IFileWriter fileWriter, OnFullDictionaryOption onFullDictionaryOption, int numberOfBitsIndex)
        {
            fileWriter.WriteValueOnBits((uint)numberOfBitsIndex, 4);
            fileWriter.WriteValueOnBits((uint)onFullDictionaryOption, 1);
        }
    }
}
