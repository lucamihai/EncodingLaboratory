namespace Encoding.FileOperations.Interfaces
{
    public interface IFileWriter
    {
        void WriteBit(bool bitValue);
        void WriteValueOnBits(uint value, byte numberOfBits);
        void Flush();
    }
}