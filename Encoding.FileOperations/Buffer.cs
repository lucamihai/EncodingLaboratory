using System;

namespace Encoding.FileOperations
{
    public class Buffer
    {
        public byte Value { get; }
        private byte previousCurrentBit;
        private byte currentBit;

        public byte CurrentBit
        {
            get => currentBit;
            set
            {
                previousCurrentBit = currentBit;
                currentBit = value;

                if (currentBit <= previousCurrentBit)
                {
                    OnCurrentBitReset(Value);
                }
            }
        }


        public delegate void CurrentBitReset(byte valueFromBuffer);
        public CurrentBitReset OnCurrentBitReset { get; set; } = valueFromBuffer => { };

        public void AddValueStartingFromCurrentBit(byte value)
        {
            throw new NotImplementedException();
        }

        public bool GetValueStartingFromCurrentBit(byte numberOfBitsToRead)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }
    }
}
