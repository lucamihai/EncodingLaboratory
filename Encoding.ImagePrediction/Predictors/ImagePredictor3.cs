using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor3 : IImagePredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return values[2];
        }
    }
}