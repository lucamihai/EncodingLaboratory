using System.Collections.Generic;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77
{
    public class Lz77Decoder
    {
        public List<Lz77Token> TokensFromPreviousRun { get; private set; }

        public Lz77Decoder()
        {
            TokensFromPreviousRun = new List<Lz77Token>();
        }

        public void DecodeFile(IFileReader fileReader, IFileWriter fileWriter)
        {
            TokensFromPreviousRun.Clear();

            var bitsForOffset = (byte)fileReader.ReadBits(4);
            var bitsForLength = (byte)fileReader.ReadBits(3);

            var tokenLengthInBits = bitsForOffset + bitsForLength + 8;

            while (!fileReader.ReachedEndOfFile && fileReader.BitsLeft >= tokenLengthInBits)
            {
                var lz77Token = new Lz77Token
                {
                    Position = (int)fileReader.ReadBits(bitsForOffset),
                    Length = (int)fileReader.ReadBits(bitsForLength),
                    Byte = (byte)fileReader.ReadBits(8)
                };
                TokensFromPreviousRun.Add(lz77Token);
            }
        }

        
    }
}