namespace Encoding.Entities
{
    public class Lz77Buffer
    {
        public byte[] SearchBuffer { get; }
        public byte[] LookAheadBuffer { get; }

        public Lz77Buffer(int searchBufferSize, int lookAheadBufferSize)
        {
            SearchBuffer = new byte[searchBufferSize];
            LookAheadBuffer = new byte[lookAheadBufferSize];
        }
    }
}