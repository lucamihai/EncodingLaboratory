using Encoding.FileOperations.Interfaces;

namespace Encoding.ImagePrediction.Interfaces.Utilities
{
    public interface IErrorMatrixReader
    {
        int[,] ReadErrorMatrix(IFileReader fileReader);
    }
}