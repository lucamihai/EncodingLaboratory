using Encoding.FileOperations.Interfaces;
using Encoding.Jpeg.Enums;
using Encoding.Jpeg.Interfaces.Utilities;

namespace Encoding.Jpeg.Interfaces
{
    public interface IJpegEncoder
    {
        void EncodeImage(IFileReader fileReader, IDownSampler downSampler);
        void DecodeImage(IDownSampler downSampler, QuantizeMethod quantizeMethod, int quantizeParameter);
    }
}