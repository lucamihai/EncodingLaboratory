using Encoding.FileOperations.Interfaces;

namespace Encoding.Huffman.Interfaces
{
    public interface IHuffmanDecoder
    {
        void DecodeFile(IFileReader fileReader, IFileWriter fileWriter);
    }
}