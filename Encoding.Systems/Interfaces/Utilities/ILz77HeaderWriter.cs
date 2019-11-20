﻿using System.Collections.Generic;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface ILz77HeaderWriter
    {
        void WriteHeaderToFile(List<Lz77Token> lz77Tokens, IFileWriter fileWriter);
    }
}