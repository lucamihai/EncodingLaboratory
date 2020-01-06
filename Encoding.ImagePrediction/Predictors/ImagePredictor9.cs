using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor9 : IImagePredictor
    {
        public byte Code { get; } = 9;
        public byte PredictValue(params byte[] values)
        {
            return PredictorCommon.GetAbsoluteByteFromInt(values[0] * values[1] - values[2]);
        }
    }
}