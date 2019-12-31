using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor4 : IImagePredictor
    {
        public byte Code { get; } = 4;

        public byte PredictValue(params byte[] values)
        {
            return PredictorCommon.GetAbsoluteByteFromInt(values[0] + values[1] - values[2]);
        }
    }
}