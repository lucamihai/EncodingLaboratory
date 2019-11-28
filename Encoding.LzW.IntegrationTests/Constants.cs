using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.LzW.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string FileName = "test.txt";
        public const string FileContents = "ABCD" +
                                           "ABCD" +
                                           "ABDC" +
                                           "ABCD" +
                                           "ABDD" +
                                           "CD";

        public static List<byte> FileContentsBytes => new List<byte>
        {
            65, 66, 67, 68,
            65, 66, 67, 68, 
            65, 66, 68, 67,
            65, 66, 67, 68,
            65, 66, 68, 68,
            67, 68
        };

        public static List<byte> EncodedFileBytes => new List<byte>
        {
            41, 136, 144, 33, 68, 0, 10, 4, 72, 100, 8, 193, 129, 66, 136, 28, 36, 242
        };

        public static List<uint> ExpectedIndexes => new List<uint>
        {
            65, 66, 67, 68, 256, 258, 256, 68, 67, 260, 259, 66, 68, 263, 68
        };
    }
}