using Encoding.FileOperations.Interfaces;
using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Interfaces
{
    public interface IImagePredictionEncoder
    {
        void EncodeImage(IFileReader fileReader, IFileWriter fileWriter, IImagePredictor imagePredictor);
    }
}