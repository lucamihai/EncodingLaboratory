namespace Encoding.ImagePrediction.Interfaces.Predictors
{
    public interface IImagePredictor
    {
        byte Code { get; }

        byte PredictValue(params byte[] values);
    }
}