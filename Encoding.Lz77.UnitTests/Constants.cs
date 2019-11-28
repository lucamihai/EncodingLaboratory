using System.Diagnostics.CodeAnalysis;
using Encoding.Lz77.Entities;

namespace Encoding.Lz77.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static Lz77Buffer GetLz77Buffer1()
        {
            var lz77Buffer = new Lz77Buffer(2, 2);

            lz77Buffer.LookAheadBuffer.Add(20);
            lz77Buffer.LookAheadBuffer.Add(21);

            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer1()
        {
            return new Lz77Token
            {
                Byte = 20,
                Length = 0,
                Position = 0
            };
        }

        public static Lz77Buffer GetLz77Buffer2()
        {
            var lz77Buffer = new Lz77Buffer(2, 2);

            lz77Buffer.LookAheadBuffer.Add(20);
            lz77Buffer.LookAheadBuffer.Add(21);
            lz77Buffer.SearchBuffer.Add(20);

            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer2()
        {
            return new Lz77Token
            {
                Byte = 21,
                Length = 1,
                Position = 0
            };
        }


        public static Lz77Buffer GetLz77Buffer3()
        {
            var lz77Buffer = new Lz77Buffer(3, 3);

            lz77Buffer.LookAheadBuffer.Add(20);
            lz77Buffer.LookAheadBuffer.Add(21);
            lz77Buffer.LookAheadBuffer.Add(22);
            lz77Buffer.SearchBuffer.Add(19);
            lz77Buffer.SearchBuffer.Add(20);
            lz77Buffer.SearchBuffer.Add(21);

            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer3()
        {
            return new Lz77Token
            {
                Byte = 22,
                Length = 2,
                Position = 1
            };
        }


        public static Lz77Buffer GetLz77Buffer4()
        {
            var lz77Buffer = new Lz77Buffer(4, 4);

            lz77Buffer.LookAheadBuffer.Add(20);
            lz77Buffer.LookAheadBuffer.Add(21);
            lz77Buffer.LookAheadBuffer.Add(22);
            lz77Buffer.LookAheadBuffer.Add(31);
            lz77Buffer.SearchBuffer.Add(20);
            lz77Buffer.SearchBuffer.Add(21);
            lz77Buffer.SearchBuffer.Add(20);
            lz77Buffer.SearchBuffer.Add(21);
            lz77Buffer.SearchBuffer.Add(22);


            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer4()
        {
            return new Lz77Token
            {
                Byte = 31,
                Length = 3,
                Position = 2
            };
        }


        public static Lz77Buffer GetLz77Buffer5()
        {
            var lz77Buffer = new Lz77Buffer(4, 4);

            lz77Buffer.LookAheadBuffer.Add(20);
            lz77Buffer.LookAheadBuffer.Add(21);
            lz77Buffer.LookAheadBuffer.Add(22);
            lz77Buffer.LookAheadBuffer.Add(23);
            lz77Buffer.LookAheadBuffer.Add(24);
            lz77Buffer.SearchBuffer.Add(20);
            lz77Buffer.SearchBuffer.Add(21);
            lz77Buffer.SearchBuffer.Add(22);
            lz77Buffer.SearchBuffer.Add(23);

            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer5()
        {
            return new Lz77Token
            {
                Byte = 24,
                Length = 4,
                Position = 3
            };
        }


        public static Lz77Buffer GetLz77Buffer6()
        {
            var lz77Buffer = new Lz77Buffer(4, 4);

            lz77Buffer.LookAheadBuffer.Add(21);
            lz77Buffer.LookAheadBuffer.Add(22);
            lz77Buffer.LookAheadBuffer.Add(23);
            lz77Buffer.LookAheadBuffer.Add(24);
            lz77Buffer.LookAheadBuffer.Add(25);
            lz77Buffer.LookAheadBuffer.Add(26);
            lz77Buffer.LookAheadBuffer.Add(27);
            lz77Buffer.LookAheadBuffer.Add(28);
            lz77Buffer.LookAheadBuffer.Add(31);
            lz77Buffer.SearchBuffer.Add(20);
            lz77Buffer.SearchBuffer.Add(21);
            lz77Buffer.SearchBuffer.Add(22);
            lz77Buffer.SearchBuffer.Add(23);
            lz77Buffer.SearchBuffer.Add(24);
            lz77Buffer.SearchBuffer.Add(25);
            lz77Buffer.SearchBuffer.Add(26);
            lz77Buffer.SearchBuffer.Add(27);
            lz77Buffer.SearchBuffer.Add(28);

            return lz77Buffer;
        }

        public static Lz77Token ExpectedTokenForLz77Buffer6()
        {
            return new Lz77Token
            {
                Byte = 31,
                Length = 8,
                Position = 7
            };
        }
    }
}