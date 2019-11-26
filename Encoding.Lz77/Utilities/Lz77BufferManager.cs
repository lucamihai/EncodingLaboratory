using System;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77.Utilities
{
    public class Lz77BufferManager : ILz77BufferManager
    {
        public void TryToFillSearchBufferBasedOnLz77Token(Lz77Buffer lz77Buffer, Lz77Token lz77Token)
        {
            if (lz77Buffer == null)
            {
                throw new ArgumentNullException(nameof(lz77Buffer));
            }

            if (lz77Token == null)
            {
                throw new ArgumentNullException(nameof(lz77Token));
            }

            for (int index = 0; index < lz77Token.Length + 1; index++)
            {
                if (lz77Buffer.SearchBuffer.Count >= lz77Buffer.SearchBuffer.Capacity)
                {
                    break;
                }

                if (index > lz77Buffer.LookAheadBuffer.Count - 1)
                {
                    break;
                }

                lz77Buffer.SearchBuffer.Add(lz77Buffer.LookAheadBuffer[index]);
            }
        }

        public void EmptyLookAheadBufferBasedOnLz77Token(Lz77Buffer lz77Buffer, Lz77Token lz77Token)
        {
            if (lz77Buffer == null)
            {
                throw new ArgumentNullException(nameof(lz77Buffer));
            }

            if (lz77Token == null)
            {
                throw new ArgumentNullException(nameof(lz77Token));
            }

            var bytesToRemove = lz77Token.Length + 1;
            while (bytesToRemove > 0 && lz77Buffer.LookAheadBuffer.Count > 0)
            {
                lz77Buffer.LookAheadBuffer.RemoveAt(0);
                bytesToRemove--;
            }
        }

        public void TryToFillLookAheadBuffer(Lz77Buffer lz77Buffer, IFileReader fileReader)
        {
            if (lz77Buffer == null)
            {
                throw new ArgumentNullException(nameof(lz77Buffer));
            }

            if (fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            while (lz77Buffer.LookAheadBuffer.Count < lz77Buffer.LookAheadBuffer.Capacity && !fileReader.ReachedEndOfFile)
            {
                lz77Buffer.LookAheadBuffer.Add((byte)fileReader.ReadBits(8));
            }
        }
    }
}