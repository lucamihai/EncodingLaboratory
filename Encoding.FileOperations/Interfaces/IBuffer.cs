namespace Encoding.FileOperations.Interfaces
{
    public interface IBuffer
    {
        byte Value { get; set; }
        byte CurrentBit { get; set; }

        Buffer.CurrentBitReset OnCurrentBitReset { get; set; }

        void AddValueStartingFromCurrentBit(byte value, byte numberOfBitsToWrite);
        byte GetValueStartingFromCurrentBit(byte numberOfBitsToRead);
        void Flush();
    }
}
