using System.Drawing;
using Encoding.Jpeg.Entities;

namespace Encoding.Jpeg.Interfaces.Mappers
{
    public interface IPixelMapper
    {
        YCbCrPixel GetYCbCrPixelFromRgb(Color rgb);
        Color GetRgbFromYCbCrPixel(YCbCrPixel yCbCrPixel);
    }
}