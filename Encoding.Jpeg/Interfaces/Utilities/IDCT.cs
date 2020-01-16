using System.Drawing;

namespace Encoding.Jpeg.Interfaces.Utilities
{
    public interface IDCT
    {
        double[,] GetDiscreteCosineTransform(double[,] matrix);
        double[,] GetIDiscreteCosineTransform(double[,] matrix);
    }
}