using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Interfaces
{
    public interface IImagePredictionDecoder
    {
        void DecodeImage(IFileReader fileReader, IFileWriter fileWriter);
    }
}