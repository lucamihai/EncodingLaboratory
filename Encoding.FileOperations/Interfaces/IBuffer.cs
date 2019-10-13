using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoding.FileOperations.Interfaces
{
    public interface IBuffer
    {
        byte Value { get; }
        byte CurrentBit { get; set; }

        void AddValueStartingFromCurrentBit(byte value, byte numberOfBitsToWrite);
        byte GetValueStartingFromCurrentBit(byte numberOfBitsToRead);
        void Flush();
    }
}
