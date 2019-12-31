using Encoding.FileOperations.Interfaces;

namespace Encoding.ImagePrediction.Interfaces.Utilities
{
    public interface IErrorMatrixWriter
    {
        void WriteErrorMatrix(int[,] errorMatrix, IFileWriter fileWriter);
    }
}