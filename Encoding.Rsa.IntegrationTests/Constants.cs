using System.Diagnostics.CodeAnalysis;

namespace Encoding.Rsa.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string FileContents = "abcdabcdabcdabcdabcde";

        public const uint N = 143;
        public const uint E = 7;
        public const uint D = 103;
    }
}