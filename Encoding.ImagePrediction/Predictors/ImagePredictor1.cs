using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor1 : IImagePredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return values[0];
        }
    }
}