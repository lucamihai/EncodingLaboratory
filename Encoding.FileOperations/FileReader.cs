using System;

namespace Encoding.FileOperations
{
    public class FileReader
    {
        public string FilePath { get; }

        public FileReader(string filePath)
        {
            FilePath = filePath;
        }

        public void ReadBit()
        {
            throw new NotImplementedException();
        }

        public void ReadBits(byte numberOfBits)
        {
            throw new NotImplementedException();
        }
    }
}
