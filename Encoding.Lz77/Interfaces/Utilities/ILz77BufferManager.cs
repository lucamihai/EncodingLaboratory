using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77.Interfaces.Utilities
{
    public interface ILz77BufferManager
    {
        void TryToFillLookAheadBuffer(Lz77Buffer lz77Buffer, IFileReader fileReader);
        void EmptyLookAheadBufferBasedOnLz77Token(Lz77Buffer lz77Buffer, Lz77Token lz77Token);
    }
}