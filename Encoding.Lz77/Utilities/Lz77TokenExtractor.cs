using System;
using System.Collections.Generic;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77.Utilities
{
    public class Lz77TokenExtractor : ILz77TokenExtractor
    {
        public Lz77Token GetLz77TokenFromLz77Buffer(Lz77Buffer lz77Buffer)
        {
            if (lz77Buffer == null)
            {
                throw new ArgumentNullException(nameof(lz77Buffer));
            }

            if (lz77Buffer.LookAheadBuffer.Count == 0)
            {
                throw new ArgumentException("Look ahead buffer shouldn't be empty");
            }

            var firstByteToLookFor = lz77Buffer.LookAheadBuffer[0];

            if (!lz77Buffer.SearchBuffer.Contains(firstByteToLookFor))
            {
                return new Lz77Token
                {
                    Byte = firstByteToLookFor,
                    Length = 0,
                    Position = 0
                };
            }

            var bytesFound = 1;
            var bytesToLookFor = new List<byte> {firstByteToLookFor};
            var indexOfFirstByteFoundInSearchBuffer = lz77Buffer.SearchBuffer.IndexOf(firstByteToLookFor);
            byte byteThatWasNotContained;

            while (Lz77BufferContainsGivenSequence(lz77Buffer, bytesToLookFor, indexOfFirstByteFoundInSearchBuffer, out byteThatWasNotContained))
            {
                if (bytesFound >= lz77Buffer.LookAheadBuffer.Count)
                {
                    break;
                }

                bytesToLookFor.Add(lz77Buffer.LookAheadBuffer[bytesFound]);
                bytesFound++;
            }

            return new Lz77Token
            {
                Byte = byteThatWasNotContained,
                Length = bytesFound,
                Position = indexOfFirstByteFoundInSearchBuffer + 1
            };
        }

        private bool Lz77BufferContainsGivenSequence(Lz77Buffer lz77Buffer, List<byte> sequence, int indexOfFirstByteFoundInSearchBuffer, out byte byteThatWasNotContained)
        {
            var lookAheadBufferIndex = 0;

            for (int index = 0; index < sequence.Count; index++)
            {
                var searchBufferIndex = indexOfFirstByteFoundInSearchBuffer - index;

                if (searchBufferIndex >= 0)
                {
                    if (lz77Buffer.SearchBuffer[searchBufferIndex] != sequence[index])
                    {
                        byteThatWasNotContained = sequence[index];
                        return false;
                    }
                }
                else
                {
                    if (lz77Buffer.LookAheadBuffer[lookAheadBufferIndex] != sequence[index])
                    {
                        byteThatWasNotContained = sequence[index];
                        return false;
                    }

                    lookAheadBufferIndex++;
                }
            }

            byteThatWasNotContained = 0;
            return true;
        }
    }
}