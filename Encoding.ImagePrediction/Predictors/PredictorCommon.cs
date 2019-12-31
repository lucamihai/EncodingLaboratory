using System;

namespace Encoding.ImagePrediction.Predictors
{
    internal static class PredictorCommon
    {
        public static byte GetAbsoluteByteFromInt(int value)
        {
            return (byte) Math.Abs(value);
        }
    }
}