using Encoding.Entities;
using Encoding.FileOperations.Interfaces;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface ILz77TokenWriter
    {
        void WriteToken(Lz77Token lz77Token, IFileWriter fileWriter);
    }
}