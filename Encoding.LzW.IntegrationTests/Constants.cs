using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.LzW.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string FileName = "test.txt";
        public const string FileContents = "ABCDABCDABDCABCDABDDCD";

        public static List<int> ExpectedIndexes => new List<int>
        {
            65, 66, 67, 68, 256, 258, 256, 68, 67, 260, 259, 66, 68, 263, 68
        };
    }
}