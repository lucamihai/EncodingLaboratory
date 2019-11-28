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

            var bytesFoundFinal = 0;
            var indexFinal = lz77Buffer.SearchBuffer.Count - 1 - lz77Buffer.SearchBuffer.IndexOf(firstByteToLookFor);
            byte byteThatWasNotContainedFinal = 0;

            var indexes = GetIndexesOfGivenByte(lz77Buffer, firstByteToLookFor);

            foreach (var index in indexes)
            {
                var bytesFoundInCurrentIteration = 0;
                var bytesToLookFor = new List<byte> { firstByteToLookFor };
                byte byteThatWasNotContained = 0;

                while (Lz77BufferContainsGivenSequence(lz77Buffer, bytesToLookFor, index, out byteThatWasNotContained))
                {
                    if (bytesFoundInCurrentIteration >= lz77Buffer.LookAheadBuffer.Count)
                    {
                        break;
                    }

                    bytesFoundInCurrentIteration++;

                    if (bytesFoundInCurrentIteration < lz77Buffer.LookAheadBuffer.Count)
                    {
                        bytesToLookFor.Add(lz77Buffer.LookAheadBuffer[bytesFoundInCurrentIteration]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (bytesFoundInCurrentIteration >= bytesFoundFinal)
                {
                    bytesFoundFinal = bytesFoundInCurrentIteration;
                    indexFinal = lz77Buffer.SearchBuffer.Count - 1 - index;
                    byteThatWasNotContainedFinal = byteThatWasNotContained;
                }
            }

            return new Lz77Token
            {
                Byte = byteThatWasNotContainedFinal,
                Length = bytesFoundFinal,
                Position = indexFinal
            };
        }

        private List<int> GetIndexesOfGivenByte(Lz77Buffer lz77Buffer, byte b)
        {
            if (!lz77Buffer.SearchBuffer.Contains(b))
            {
                return new List<int>();
            }

            var indexes = new List<int>();

            for (int index = 0; index < lz77Buffer.SearchBuffer.Count; index++)
            {
                if (lz77Buffer.SearchBuffer[index] == b)
                {
                    indexes.Add(index);
                }
            }

            return indexes;
        }

        private bool Lz77BufferContainsGivenSequence(Lz77Buffer lz77Buffer, List<byte> sequence, int indexOfFirstByteFoundInSearchBuffer, out byte byteThatWasNotContained)
        {
            // TODO: Maybe implement properly at some other time
            //var lookAheadBufferIndex = 0;

            for (int index = 0; index < sequence.Count; index++)
            {
                var searchBufferIndex = indexOfFirstByteFoundInSearchBuffer + index;
                var contains = true;

                if (searchBufferIndex > lz77Buffer.SearchBuffer.Count - 1)
                {
                    contains = false;
                }
                else
                {
                    if (searchBufferIndex >= 0)
                    {
                        if (lz77Buffer.SearchBuffer[searchBufferIndex] != sequence[index])
                        {
                            contains = false;
                        }
                    }
                    else
                    {
                        contains = false;
                    }
                    // TODO: Maybe implement properly at some other time
                    //else
                    //{
                    //    if (Lz77Buffer.LookAheadBuffer[lookAheadBufferIndex] != sequence[index])
                    //    {
                    //        contains = false;
                    //    }

                    //    lookAheadBufferIndex++;
                    //}
                }

                if (!contains)
                {
                    byteThatWasNotContained = sequence[index];
                    return false;
                }
            }

            byteThatWasNotContained = 0;
            return true;
        }
    }
}