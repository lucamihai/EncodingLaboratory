namespace Encoding.FileOperations.Interfaces
{
    public interface IFileReader
    {
        void Reset();

        bool ReadBit();
        uint ReadBits(byte numberOfBits);

        bool ReachedEndOfFile { get; }
        long BitsLeft { get; }
    }
}