using Encoding.FileOperations.Interfaces;

namespace Encoding.Lz77.Interfaces
{
    public interface ILz77Decoder
    {
        void DecodeFile(IFileReader fileReader, IFileWriter fileWriter);
    }
}