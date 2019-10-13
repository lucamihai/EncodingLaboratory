using System.Diagnostics.CodeAnalysis;

namespace Encoding.FileOperations.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal class Constants
    {
        public const string TestFileName = "testFile.txt";
        public static byte[] TestFileBytes = new byte[]
        {
            1, 2, 3
        };

        // Binary: 10
        public const byte Value1 = 2;
        public const byte Value1BitsRequired = 2;
        public const byte Value1OneBitFromBitZero = 0;

        // Binary: 1011
        public const byte Value2 = 11;
        public const byte Value2BitsRequired = 4;
        public const byte Value2ThreeBitsFromBitOne = 5;

        // Binary: 101110
        public const byte Value1FollowedByValue2 = 46;
    }
}
