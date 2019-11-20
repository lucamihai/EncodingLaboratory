﻿using System.Collections.Generic;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;

namespace Encoding.Systems.Interfaces.Utilities
{
    public interface IHuffmanHeaderWriter
    {
        void WriteHeaderToFile(List<ByteStatistics> byteStatistics, IFileWriter fileWriter);
    }
}