using System;
using Encoding.ImagePrediction.Interfaces.Predictors;

namespace Encoding.ImagePrediction.Predictors
{
    public class ImagePredictor4 : IImagePredictor
    {
        public byte PredictValue(params byte[] values)
        {
            return (byte)Math.Abs(values[0] + values[1] - values[2]);
        }
    }
}