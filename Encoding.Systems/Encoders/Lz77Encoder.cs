using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Encoders
{
    public class Lz77Encoder
    {
        private readonly Lz77Buffer lz77Buffer;
        private readonly ILz77HeaderWriter lz77HeaderWriter;
        private readonly ILz77TokenExtractor lz77TokenExtractor;
        private readonly ILz77BufferManager lz77BufferManager;

        public Lz77Encoder(Lz77Buffer lz77Buffer, ILz77HeaderWriter lz77HeaderWriter, ILz77TokenExtractor lz77TokenExtractor, ILz77BufferManager lz77BufferManager)
        {
            this.lz77Buffer = lz77Buffer;
            this.lz77HeaderWriter = lz77HeaderWriter;
            this.lz77TokenExtractor = lz77TokenExtractor;
            this.lz77BufferManager = lz77BufferManager;
        }
    }
}