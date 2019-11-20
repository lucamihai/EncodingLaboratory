namespace Encoding.FileOperations.Interfaces
{
    public interface IFileReader
    {
        bool ReadBit();
        uint ReadBits(byte numberOfBits);

        bool ReachedEndOfFile { get; }
    }
}