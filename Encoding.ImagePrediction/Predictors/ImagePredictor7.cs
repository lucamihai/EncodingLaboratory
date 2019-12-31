using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor7 : IImagePredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return (byte)((values[0] + values[1]) / 2);
        }
    }
}