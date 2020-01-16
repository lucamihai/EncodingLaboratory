using System.Drawing;
using Encoding.Jpeg.Entities;
using Encoding.Jpeg.Interfaces.Mappers;

namespace Encoding.Jpeg.Mappers
{
    public class PixelMapper : IPixelMapper
    {
        public YCbCrPixel GetYCbCrPixelFromRgb(Color rgb)
        {
            //var y = (byte)(0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B);
            //var cb = (byte)(-0.172 * rgb.R - 0.339 * rgb.G + 0.511 * rgb.B + 128);
            //var cr = (byte)(0.511 * rgb.R - 0.428 * rgb.G - 0.083 * rgb.B + 128);

            var y = (byte)(0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B);
            var cb = (byte)(128 - 0.168736 * rgb.R - 0.331264 * rgb.G + 0.5      * rgb.B);
            var cr = (byte)(128 + 0.5      * rgb.R - 0.418688 * rgb.G - 0.081312 * rgb.B);

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
            //var red = yCbCrPixel.Y + 0.000 * (yCbCrPixel.Cb - 128) + 1.371 * (yCbCrPixel.Cr - 128);
            //var green = yCbCrPixel.Y - 0.336 * (yCbCrPixel.Cb - 128) - 0.698 * (yCbCrPixel.Cr - 128);
            //var blue = yCbCrPixel.Y + 1.732 * (yCbCrPixel.Cb - 128) + 0.000 * (yCbCrPixel.Cr - 128);

            var red = yCbCrPixel.Y + 1.402 * (yCbCrPixel.Cr - 128);
            var green = yCbCrPixel.Y - 0.344136 * (yCbCrPixel.Cb - 128) - 0.714136 * (yCbCrPixel.Cr - 128);
            var blue = yCbCrPixel.Y + 1.772 * (yCbCrPixel.Cb - 128);

            var normalizedRed = Normalize(red, 0, 255);
            var normalizedGreen = Normalize(green, 0, 255);
            var normalizedBlue = Normalize(blue, 0, 255);

            return Color.FromArgb(normalizedRed, normalizedGreen, normalizedBlue);
        }

        private static byte Normalize(double value, byte minValue, byte maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }

            if (value > maxValue)
            {
                return maxValue;
            }

            return (byte)value;
        }

        private static byte Normalize(byte value, byte minValue, byte maxValue)
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