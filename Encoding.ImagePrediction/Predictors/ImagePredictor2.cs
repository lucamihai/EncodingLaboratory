using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor2 : IImagePredictor
    {
        public byte Code { get; } = 2;

        public byte PredictValue(params byte[] values)
        {
            return values[1];
        }
    }
}