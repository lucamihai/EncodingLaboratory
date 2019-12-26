using System;
using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Rsa.Interfaces;
using Encoding.Rsa.Utilities;

namespace Encoding.Rsa
{
    public class RsaDecrypter : IRsaDecrypter
    {
        public List<byte> KeysFromLastRun { get; set; }
        public List<uint> RsaKeysFromLastRun { get; set; }

        public RsaDecrypter()
        {
            KeysFromLastRun = new List<byte>();
            RsaKeysFromLastRun = new List<uint>();
        }

        public void DecryptFile(IFileReader fileReader, IFileWriter fileWriter, uint d)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            if (d < 1)
            {
                throw new ArgumentException($"{nameof(d)} must be higher than 0");
            }

            KeysFromLastRun.Clear();
            RsaKeysFromLastRun.Clear();

            var e = fileReader.ReadBits(32);
            var n = fileReader.ReadBits(32);
            var keys = GetKeysFromFile(fileReader, n, d);

            var indexOfByte = 0;
            while (!fileReader.ReachedEndOfFile)
            {
                var encryptedByte = (byte)fileReader.ReadBits(8);
                var decryptedByte = DecryptByte(encryptedByte, keys, indexOfByte);
                fileWriter.WriteValueOnBits(decryptedByte, 8);

                indexOfByte++;
            }
        }

        private byte[] GetKeysFromFile(IFileReader fileReader, uint n, uint d)
        {
            var keys = new byte[8];

            for (int index = 0; index < 8; index++)
            {
                var rsaKey = fileReader.ReadBits(32);
                var key = (byte)RsaComputer.GetRsa(rsaKey, d, n);
                keys[index] = key;

                KeysFromLastRun.Add(key);
                RsaKeysFromLastRun.Add(rsaKey);
            }

            return keys;
        }

        private byte DecryptByte(byte encryptedByte, byte[] keys, int indexOfByte)
        {
            return (byte)(encryptedByte ^ keys[indexOfByte % 8]);
        }
    }
}