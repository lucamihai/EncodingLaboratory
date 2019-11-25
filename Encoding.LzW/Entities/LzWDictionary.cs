using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.LzW.Options;

namespace Encoding.LzW.Entities
{
    public class LzWDictionary
    {
        private Dictionary<string, uint> dictionary;
        private uint dictionaryLastIndex;

        public int Limit { get; }
        public OnFullDictionaryOption OnFullDictionaryOption { get; }

        public LzWDictionary(int limit, OnFullDictionaryOption onFullDictionaryOption)
        {
            if (limit < 256)
            {
                throw new ArgumentException($"{nameof(limit)} must be at least 256");
            }

            Limit = limit;
            OnFullDictionaryOption = onFullDictionaryOption;

            dictionary = new Dictionary<string, uint>();
            for (uint key = 0; key < 256; key++)
            {
                dictionary.Add(((char)key).ToString(), key);
            }

            dictionaryLastIndex = 255;
        }

        public void Add(string s)
        {
            if (dictionary.Count > Limit)
            {
                if (OnFullDictionaryOption == OnFullDictionaryOption.Freeze)
                {
                    return;
                }

                EmptyDictionaryExceptDefaultPairs();
                dictionaryLastIndex++;
                dictionary.Add(s, dictionaryLastIndex);
            }
            else
            {
                dictionaryLastIndex++;
                dictionary.Add(s, dictionaryLastIndex);
            }
        }

        public bool ContainsString(string s)
        {
            return dictionary.ContainsKey(s);
        }

        public uint GetIndexByString(string s)
        {
            return dictionary[s];
        }

        public bool ContainsIndex(uint index)
        {
            return dictionary.ContainsValue(index);
        }

        public string GetStringByIndex(uint index)
        {
            return dictionary.First(x => x.Value == index).Key;
        }

        private void EmptyDictionaryExceptDefaultPairs()
        {
            dictionary = dictionary
                .Take(256)
                .ToDictionary(x => x.Key, x => x.Value);

            dictionaryLastIndex = 255;
        }
    }
}