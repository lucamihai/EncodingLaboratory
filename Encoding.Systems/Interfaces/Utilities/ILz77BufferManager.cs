using Encoding.Entities;
using Encoding.FileOperations.Interfaces;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface ILz77BufferManager
    {
        void ChangeLz77BufferContentsBasedOnToken(Lz77Buffer lz77Buffer, Lz77Token lz77Token, IFileReader fileReader);
    }
}