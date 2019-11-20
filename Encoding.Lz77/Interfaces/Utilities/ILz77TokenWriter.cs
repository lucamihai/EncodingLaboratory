using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77.Interfaces.Utilities
{
    public interface ILz77TokenWriter
    {
        void WriteToken(Lz77Token lz77Token, IFileWriter fileWriter);
    }
}