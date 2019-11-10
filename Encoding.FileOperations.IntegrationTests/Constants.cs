using System.Diagnostics.CodeAnalysis;

namespace Encoding.FileOperations.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string TestFileNameImage = "imageTest.png";
        public const string TestFileNameImageDestination = "imageTestWritten.png";
        public const string TestFileName = "testFile.txt";
        public static byte[] TestBytes = new byte[]
        {
                // Binary representation
            11, // 0000 1011
            4,  // 0000 0100
            7   // 0000 0111
        };

        // Binary: 0000 0011
        public const byte ValueFromFirstByteBits012 = 3;

        // Binary: 0001 0000
        public const byte ValueFromFirstByteBits78FollowedBySecondByteBits012 = 16;

        // Binary: 1010
        public const byte ValueTenOnFourBits = 10;

        // Binary: 10
        public const byte ValueTenOnTwoBits = 2;
    }
}
