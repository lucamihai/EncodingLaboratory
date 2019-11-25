using System;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77.Utilities
{
    public class Lz77BufferManager : ILz77BufferManager
    {
        public void ChangeLz77BufferContentsBasedOnToken(Lz77Buffer lz77Buffer, Lz77Token lz77Token, IFileReader fileReader)
        {
            if (lz77Buffer == null)
            {
                throw new ArgumentNullException(nameof(lz77Buffer));
            }

            if (lz77Token == null)
            {
                throw new ArgumentNullException(nameof(lz77Token));
            }

            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            throw new NotImplementedException();
        }
    }
}