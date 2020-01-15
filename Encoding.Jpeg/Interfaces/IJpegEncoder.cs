using Encoding.FileOperations.Interfaces;

namespace Encoding.Jpeg.Interfaces
{
    public interface IJpegEncoder
    {
        void EncodeImage(IFileReader fileReader, IFileWriter fileWriter);
    }
}