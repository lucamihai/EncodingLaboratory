using System;

namespace Encoding.FileOperations
{
    public class FileWriter
    {
        public string FilePath { get; }

        public FileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public void WriteBit(bool bitValue)
        {
            throw new NotImplementedException();
        }

        public void WriteValueOnBits(byte value, byte numberOfBits)
        {
            throw new NotImplementedException();
        }
    }
}
