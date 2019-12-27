using System.Diagnostics.CodeAnalysis;

namespace Encoding.Rsa.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class RsaComputer
    {
        public static uint GetRsa(uint value, uint power, uint modulo)
        {
            ulong result = 1;

            while (power >= 1)
            {
                if (power % 2 == 1)
                {
                    result *= value;
                    result %= modulo;
                }

                value *= value;
                value %= modulo;
                power /= 2;
            }

            return (uint)result;
        }
    }
}