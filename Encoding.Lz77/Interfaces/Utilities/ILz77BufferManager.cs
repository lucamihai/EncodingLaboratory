using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77.Interfaces.Utilities
{
    public interface ILz77BufferManager
    {
        void ChangeLz77BufferContentsBasedOnToken(Lz77Buffer lz77Buffer, Lz77Token lz77Token, IFileReader fileReader);
    }
}