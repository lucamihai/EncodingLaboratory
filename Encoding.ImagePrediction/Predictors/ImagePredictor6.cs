using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor6 : IImagePredictor
    {
        public byte Code { get; } = 6;

        public byte PredictValue(params byte[] values)
        {
            return PredictorCommon.GetAbsoluteByteFromInt(values[1] + (values[0] - values[2] / 2));
        }
    }
}