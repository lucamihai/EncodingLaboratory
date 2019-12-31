using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor0 : IImagePredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return 128;
        }
    }
}