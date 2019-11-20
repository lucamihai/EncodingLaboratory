using System;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;

namespace Encoding.Lz77
{
    public class Lz77Encoder
    {
        private readonly Lz77Buffer lz77Buffer;
        private readonly ILz77TokenExtractor lz77TokenExtractor;
        private readonly ILz77BufferManager lz77BufferManager;
        private readonly ILz77TokenWriter lz77TokenWriter;

        public Lz77Encoder(Lz77Buffer lz77Buffer, ILz77TokenExtractor lz77TokenExtractor, ILz77BufferManager lz77BufferManager, ILz77TokenWriter lz77TokenWriter)
        {
            this.lz77Buffer = lz77Buffer;
            this.lz77TokenExtractor = lz77TokenExtractor;
            this.lz77BufferManager = lz77BufferManager;
            this.lz77TokenWriter = lz77TokenWriter;
        }

        public void EncodeFile(IFileReader fileReaderForFileToEncode, IFileWriter fileWriterForDestinationFile)
        {
            if (fileReaderForFileToEncode == null)
            {
                throw new ArgumentNullException(nameof(fileReaderForFileToEncode));
            }

            if (fileWriterForDestinationFile == null)
            {
                throw new ArgumentNullException(nameof(fileWriterForDestinationFile));
            }

            InitializeLz77BufferContents(fileReaderForFileToEncode);

            while (lz77Buffer.LookAheadBuffer.Count > 0)
            {
                var token = lz77TokenExtractor.GetLz77TokenFromLz77Buffer(lz77Buffer);
                lz77BufferManager.ChangeLz77BufferContentsBasedOnToken(lz77Buffer, token, fileReaderForFileToEncode);
                lz77TokenWriter.WriteToken(token, fileWriterForDestinationFile);
            }

            fileWriterForDestinationFile.Flush();
        }

        private void InitializeLz77BufferContents(IFileReader fileReaderForFileToEncode)
        {
            var lookAheadBufferBytesLimit = lz77Buffer.LookAheadBuffer.Capacity;
            var bytesRead = 0;

            while (bytesRead < lookAheadBufferBytesLimit)
            {
                if (fileReaderForFileToEncode.ReachedEndOfFile)
                {
                    break;
                }

                lz77Buffer.LookAheadBuffer.Add((byte)fileReaderForFileToEncode.ReadBits(8));
                bytesRead++;
            }
        }
    }
}