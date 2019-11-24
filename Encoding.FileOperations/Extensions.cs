using Encoding.FileOperations.Interfaces;

namespace Encoding.FileOperations
{
    public static class Extensions
    {
        public static void WriteToFile(this string s, IFileWriter fileWriter)
        {
            foreach (var character in s)
            {
                fileWriter.WriteValueOnBits((byte)character, 8);
            }
        }
    }
}