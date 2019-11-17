using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.Systems.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string HuffmanEncodedFilePath = "HuffmanEncodedFile.txt";
        public const string HuffmanDecodedFilePath = "HuffmanDecodedFile.txt";
        public const string Text1 = "Ana has apples";
        public static byte[] Bytes1()
        {
            return new byte[]
            {
                (byte)'A',
                (byte)'n',
                (byte)'a',
                (byte)' ',
                (byte)'h',
                (byte)'a',
                (byte)'s',
                (byte)' ',
                (byte)'a',
                (byte)'p',
                (byte)'p',
                (byte)'l',
                (byte)'e',
                (byte)'s'
            };
        }

        public static byte[] Bytes2()
        {
            return new byte[]
            {
                12,65,4,29,35,
                41,92,18,90,10,
                89,26,75,33,17,
                47,69,24,99,2,
                90,91,40,79,66,
                11,85,50,65,51,
                46,68,62,98,73,
                72,39,15,72,68,
                11,92,97,97,39,
                27,2,53,59,55,
                28,90,90,99,57,
                14,13,96,6,39,
                61,14,79,67,70,
                100,4,60,63,28,
                93,67,98,10,25,
                100,11,78,58,55,
                45,21,27,56,39,
                55,94,13,15,84,
                89,68,82,8,70,
                48,57,71,42,51
            };
        }

        public static byte[] Bytes3()
        {
            var list = new List<byte>(Bytes1());

            for (int i = 0; i < Math.Pow(2, 8) + 2; i++)
            {
                list.Add(4);
            }

            return list.ToArray();
        }

        public static byte[] Bytes4()
        {
            var list = new List<byte>(Bytes1());

            for (int i = 0; i < Math.Pow(2, 8) - 10; i++)
            {
                list.Add(3);
            }

            for (int i = 0; i < Math.Pow(2, 8) + 2; i++)
            {
                list.Add(4);
            }

            for (int i = 0; i < Math.Pow(2, 16) + 5; i++)
            {
                list.Add(5);
            }

            for (int i = 0; i < Math.Pow(2, 16) + 6; i++)
            {
                list.Add(41);
            }

            for (int i = 0; i < Math.Pow(2, 16) + 10; i++)
            {
                list.Add(66);
            }

            return list.ToArray();
        }
    }
}