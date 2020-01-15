using System.Drawing;
using Encoding.Jpeg.Entities;
using Encoding.Jpeg.Interfaces.Mappers;

namespace Encoding.Jpeg.Mappers
{
    public class PixelMapper : IPixelMapper
    {
        public YCbCrPixel GetYCbCrPixelFromRgb(Color rgb)
        {
            var y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B + 128;
            var cb = -0.172 * rgb.R - 0.339 * rgb.G + 0.511 * rgb.B;
            var cr = 0.511 * rgb.R - 0.428 * rgb.G - 0.083 * rgb.B + 128;

            y = Normalize(y, 0, 255);
            cb = Normalize(cb, 0, 255);
            cr = Normalize(cr, 0, 255);

            return new YCbCrPixel
            {
                Y = y,
                Cb = cb,
                Cr = cr
            };
        }

        public Color GetRgbFromYCbCrPixel(YCbCrPixel yCbCrPixel)
        {
            var red = yCbCrPixel.Y + 0.000 * (yCbCrPixel.Cb - 128) + 1.371 * (yCbCrPixel.Cr - 128);
            var green = yCbCrPixel.Y - 0.336 * (yCbCrPixel.Cb - 128) - 0.698 * (yCbCrPixel.Cr - 128);
            var blue = yCbCrPixel.Y + 1.732 * (yCbCrPixel.Cb - 128) + 0.000 * (yCbCrPixel.Cr - 128);

            var normalizedRed = (byte)Normalize(red, 0, 255);
            var normalizedGreen = (byte)Normalize(green, 0, 255);
            var normalizedBlue = (byte)Normalize(blue, 0, 255);

            return Color.FromArgb(normalizedRed, normalizedGreen, normalizedBlue);
        }

        private static double Normalize(double value, double minValue, double maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }

            if (value > maxValue)
            {
                return maxValue;
            }

            return value;
        }
    }
}