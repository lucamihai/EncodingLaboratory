using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor5 : IImagePredictor
    {
        public byte Code { get; } = 5;

        public byte PredictValue(params byte[] values)
        {
            return PredictorCommon.GetAbsoluteByteFromInt(values[0] + (values[1] - values[2] / 2));
        }
    }
}