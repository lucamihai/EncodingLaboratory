using Encoding.FileOperations.Interfaces;

namespace Encoding.Rsa.Interfaces
{
    public interface IRsaDecrypter
    {
        void DecryptFile(IFileReader fileReader, IFileWriter fileWriter, uint d);
    }
}