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
    }
}
