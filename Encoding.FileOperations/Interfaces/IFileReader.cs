namespace Encoding.FileOperations.Interfaces
{
    public interface IFileReader
    {
        void Open();
        void Close();
        void Reset();

        bool ReadBit();
        uint ReadBits(byte numberOfBits);

        string FilePath { get; }
        bool ReachedEndOfFile { get; }
        long BitsLeft { get; }
    }
}