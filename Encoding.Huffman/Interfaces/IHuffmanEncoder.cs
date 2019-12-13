using Encoding.FileOperations.Interfaces;

namespace Encoding.Huffman.Interfaces
{
    public interface IHuffmanEncoder
    {
        void EncodeFile(IFileReader fileReader, IFileWriter fileWriter);
    }
}