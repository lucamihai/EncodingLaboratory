namespace Encoding.Jpeg.Interfaces.Utilities
{
    public interface IDownSampler
    {
        double[,] GetDownSampledMatrix(double[,] matrix);
    }
}