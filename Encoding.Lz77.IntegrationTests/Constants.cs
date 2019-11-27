using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    internal static  class Constants
    {
        public const string FileName = "test.txt";
        public const string FileContents = "abcdabcdabcdabcdabcde";

        public const int BitsForOffset1 = 4;
        public const int BitsForLength1 = 4;

        public static List<Lz77Token> GetTokens1()
        {
            return new List<Lz77Token>
            {
                new Lz77Token
                {
                    Length = 0,
                    Position = 0,
                    Byte = (byte)'a'
                },
                new Lz77Token
                {
                    Length = 0,
                    Position = 0,
                    Byte = (byte)'b'
                },
                new Lz77Token
                {
                    Length = 0,
                    Position = 0,
                    Byte = (byte)'c'
                },
                new Lz77Token
                {
                    Length = 0,
                    Position = 0,
                    Byte = (byte)'d'
                },
                new Lz77Token
                {
                    Length = 4,
                    Position = 1,
                    Byte = (byte)'a'
                },
                new Lz77Token
                {
                    Length = 8,
                    Position = 2,
                    Byte = (byte)'b'
                },
                new Lz77Token
                {
                    Length = 2,
                    Position = 4,
                    Byte = (byte)'e'
                },
            };
        }
    }
}