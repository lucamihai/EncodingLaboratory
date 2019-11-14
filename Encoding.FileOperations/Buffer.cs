using System;
using System.Collections;
using Encoding.FileOperations.Interfaces;

namespace Encoding.FileOperations
{
    public class Buffer : IBuffer
    {
        private BitArray bitArray;

        public byte Value
        {
            get => GetByteFromBitArray(bitArray);
            set => bitArray = new BitArray(new[] {value});
        }

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

            for (int index = 0; index < numberOfBitsToWrite; index++)
            {
                var valueToWrite = index < bitArray.Length
                    ? valueBitArray[index]
                    : false;

                bitArray[CurrentBit] = valueToWrite;
                CurrentBit++;
            }
        }

        public byte GetValueStartingFromCurrentBit(byte numberOfBitsToRead)
        {
            if (numberOfBitsToRead == 0)
            {
                throw new ArgumentException();
            }

            var valueBitArray = new BitArray(8);
            valueBitArray.SetAll(false);

            for (int i = 0; i < numberOfBitsToRead; i++)
            {
                var valueBitArrayIndex = i % 8;
                valueBitArray[valueBitArrayIndex] = bitArray[CurrentBit];

                CurrentBit++;
            }

            return GetByteFromBitArray(valueBitArray);
        }

        public void Flush()
        {
            AddValueStartingFromCurrentBit(127, 7);
        }

        private byte GetByteFromBitArray(BitArray bitArray)
        {
            var bytes = new byte[1];
            bitArray.CopyTo(bytes, 0);

            return bytes[0];
        }
    }
}
