using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Options;

namespace Encoding.LzW.Interfaces
{
    public interface ILzWEncoder
    {
        void EncodeFile(IFileReader fileReader, IFileWriter fileWriter, OnFullDictionaryOption onFullDictionaryOption, int numberOfBitsIndex);
    }
}