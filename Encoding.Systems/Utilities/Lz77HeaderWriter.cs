using System.Collections.Generic;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class Lz77HeaderWriter : ILz77HeaderWriter
    {
        public void WriteHeaderToFile(List<Lz77Token> lz77Tokens, IFileWriter fileWriter)
        {
            throw new System.NotImplementedException();
        }
    }
}