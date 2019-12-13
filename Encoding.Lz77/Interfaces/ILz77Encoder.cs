using Encoding.FileOperations.Interfaces;

namespace Encoding.Lz77.Interfaces
{
    public interface ILz77Encoder
    {
        void EncodeFile(IFileReader fileReader, IFileWriter fileWriter, int bitsForOffset, int bitsForLength);
    }
}