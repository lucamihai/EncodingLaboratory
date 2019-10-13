using System;
using System.Collections;
using Encoding.FileOperations.Interfaces;

namespace Encoding.FileOperations
{
    public class Buffer : IBuffer
    {
        private readonly BitArray bitArray;

        public byte Value => GetByteFromBitArray(bitArray);

        private byte previousCurrentBit;
        private byte currentBit;

        public byte CurrentBit
        {
            get => currentBit;
            set
            {
                previousCurrentBit = currentBit;
                currentBit = (byte)(value % 8);

                if (currentBit <= previousCurrentBit)
                {
                    OnCurrentBitReset(Value);
                }
            }
        }

        public delegate void CurrentBitReset(byte valueFromBuffer);
        public CurrentBitReset OnCurrentBitReset { get; set; } = valueFromBuffer => { };

        public Buffer()
        {
            bitArray = new BitArray(8);
            bitArray.SetAll(false);
        }

        public void AddValueStartingFromCurrentBit(byte value, byte numberOfBitsToWrite)
        {
            if (numberOfBitsToWrite == 0)
            {
                throw new ArgumentException();
            }

            var valueBitArray = new BitArray(new[] {value});
            valueBitArray.Length = numberOfBitsToWrite;

            var currentBitTemporary = CurrentBit;
            for(int i = 0; i < numberOfBitsToWrite; i++)
            {
                var valueBitArrayIndex = i % 8;
                bitArray[currentBitTemporary] = valueBitArray[valueBitArrayIndex];

                currentBitTemporary++;
                currentBitTemporary = (byte)(currentBitTemporary % 8);
            }

            CurrentBit = currentBitTemporary;
        }

        public byte GetValueStartingFromCurrentBit(byte numberOfBitsToRead)
        {
            if (numberOfBitsToRead == 0)
            {
                throw new ArgumentException();
            }

            var valueBitArray = new BitArray(8);
            valueBitArray.SetAll(false);

            var currentBitTemporary = CurrentBit;
            for (int i = 0; i < numberOfBitsToRead; i++)
            {
                var valueBitArrayIndex = i % 8;
                valueBitArray[valueBitArrayIndex] = bitArray[currentBitTemporary];

                currentBitTemporary++;
                currentBitTemporary = (byte)(currentBitTemporary % 8);
            }

            CurrentBit = currentBitTemporary;

            return GetByteFromBitArray(valueBitArray);
        }

        public void Flush()
        {
            bitArray.SetAll(false);
            CurrentBit = 0;
        }

        private byte GetByteFromBitArray(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }

            var bytes = new byte[1];
            bits.CopyTo(bytes, 0);

            return bytes[0];
        }
    }
}
