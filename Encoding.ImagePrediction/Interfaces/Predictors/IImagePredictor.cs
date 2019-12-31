namespace Encoding.ImagePrediction.Interfaces.Predictors
{
    public interface IImagePredictor
    {
        byte PredictValue(params byte[] values);
    }
}