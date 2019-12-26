using Encoding.FileOperations.Interfaces;

namespace Encoding.Rsa.Interfaces
{
    public interface IRsaEncrypter
    {
        void EncryptFile(IFileReader fileReader, IFileWriter fileWriter, uint n, uint e);
    }
}