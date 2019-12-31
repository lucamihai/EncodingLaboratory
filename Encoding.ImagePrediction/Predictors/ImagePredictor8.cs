using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor8 : IImagePredictor
    {
        public byte Code { get; } = 8;

        public byte PredictValue(params byte[] values)
        {
            var a = values[0];
            var b = values[1];
            var c = values[2];

            if (c >= Max(a, b))
            {
                return Min(a, b);
            }

            if (c <= Min(a, b))
            {
                return Max(a, b);
            }

            return PredictorCommon.GetAbsoluteByteFromInt(a + b - c);
        }

        private byte Min(byte b1, byte b2)
        {
            return b1 < b2 ? b1 : b2;
        }

        private byte Max(byte b1, byte b2)
        {
            return b1 > b2 ? b1 : b2;
        }
    }
}