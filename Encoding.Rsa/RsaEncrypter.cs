using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Rsa.Interfaces;
using Encoding.Rsa.Utilities;

namespace Encoding.Rsa
{
    public class RsaEncrypter : IRsaEncrypter
    {
        public List<byte> KeysFromLastRun { get; set; }
        public List<uint> RsaKeysFromLastRun { get; set; }

        public RsaEncrypter()
        {
            KeysFromLastRun = new List<byte>();
            RsaKeysFromLastRun = new List<uint>();
        }

        public void EncryptFile(IFileReader fileReader, IFileWriter fileWriter, uint n, uint e)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            if (n < 1)
            {
                throw new ArgumentException($"{nameof(n)} must be higher than 0");
            }

            if (e < 1)
            {
                throw new ArgumentException($"{nameof(e)} must be higher than 0");
            }

            KeysFromLastRun.Clear();
            RsaKeysFromLastRun.Clear();

            // TODO: Is it normal for the random key to be smaller than n?
            var randomKeys = GetRandomKeys(n - 1);
            var rsaKeys = GetRsaKeys(randomKeys, n, e);

            fileWriter.WriteValueOnBits(e, 32);
            fileWriter.WriteValueOnBits(n, 32);
            WriteRsaKeysToFile(rsaKeys, fileWriter);

            var currentIndex = 0;
            while (!fileReader.ReachedEndOfFile)
            {
                var currentByte = (byte)fileReader.ReadBits(8);
                var encodedByte = GetEncodedByte(currentByte, randomKeys, currentIndex);

                fileWriter.WriteValueOnBits(encodedByte, 8);

                currentIndex++;
            }
        }

        private byte[] GetRandomKeys(uint max)
        {
            var rng = new Random();
            var keys = new byte[8];

            if (max > 255)
            {
                max = 255;
            }

            for (int index = 0; index < 8; index++)
            {
                var key = (byte)rng.Next(0, (int)max);
                keys[index] = key;
                KeysFromLastRun.Add(key);
            }

            return keys;
        }

        private uint[] GetRsaKeys(byte[] keys, uint n, uint e)
        {
            var rsaKeys = new uint[8];

            for (int index = 0; index < 8; index++)
            {
                var rsaKey = RsaComputer.GetRsa(keys[index], e, n);
                rsaKeys[index] = rsaKey;
                RsaKeysFromLastRun.Add(rsaKey);
            }

            return rsaKeys;
        }

        private void WriteRsaKeysToFile(uint[] rsaKeys, IFileWriter fileWriter)
        {
            for (int index = 0; index < 8; index++)
            {
                fileWriter.WriteValueOnBits(rsaKeys[index], 32);
            }
        }

        private byte GetEncodedByte(byte b, byte[] keys, int indexOfByte)
        {
            return (byte)(b ^ keys[indexOfByte % 8]);
        }
    }
}