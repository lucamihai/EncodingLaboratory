using System.Diagnostics.CodeAnalysis;

namespace Encoding.Lz77.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    internal static  class Constants
    {
        public const string FileName = "test.txt";
        public const string FileContents = "abcdabcdabcdabcdabcde";

        public const int BitsForOffset1 = 4;
        public const int BitsForLength1 = 4;
    }
}