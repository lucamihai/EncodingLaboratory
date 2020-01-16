using Encoding.FileOperations.Interfaces;
using Encoding.Jpeg.Enums;
using Encoding.Jpeg.Interfaces.Utilities;

namespace Encoding.Jpeg.Interfaces
{
    public interface IJpegEncoder
    {
        void EncodeImage(IFileReader fileReader, IFileWriter fileWriter, IDownSampler downSampler);
        void DecodeImage(QuantizeMethod quantizeMethod, int quantizeParameter);
    }
}