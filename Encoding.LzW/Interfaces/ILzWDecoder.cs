using Encoding.FileOperations.Interfaces;

namespace Encoding.LzW.Interfaces
{
    public interface ILzWDecoder
    {
        void DecodeFile(IFileReader fileReader, IFileWriter fileWriter);
    }
}