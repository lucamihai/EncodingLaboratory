using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Lz77.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77EncoderUnitTests
    {
        private int offset;
        private int length;
        private int numberOfIterations;

        private Lz77Buffer lz77Buffer;
        private Mock<ILz77TokenExtractor> lz77TokenExtractorMock;
        private Mock<ILz77BufferManager> lz77BufferManagerMock;
        private Mock<ILz77TokenWriter> lz77TokenWriterMock;
        private Lz77Encoder lz77Encoder;

        private Mock<IFileReader> fileReaderMock;
        private Mock<IFileWriter> fileWriterMock;

        private Lz77Token lz77TokenReturnedByLz77TokenExtractor;

        [TestInitialize]
        public void Setup()
        {
            InitializeLz77Buffer();

            lz77TokenExtractorMock = new Mock<ILz77TokenExtractor>();
            lz77BufferManagerMock = new Mock<ILz77BufferManager>();
            lz77TokenWriterMock = new Mock<ILz77TokenWriter>();
            lz77Encoder = new Lz77Encoder(lz77Buffer, lz77TokenExtractorMock.Object, lz77BufferManagerMock.Object, lz77TokenWriterMock.Object);

            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();

            InitializeLz77TokenExtractorMock();
            InitializeLz77BufferManagerMock();
        }

        private void InitializeLz77Buffer()
        {
            offset = 2;
            length = 2;

            lz77Buffer = new Lz77Buffer(offset, length);
        }

        private void InitializeLz77TokenExtractorMock()
        {
            lz77TokenReturnedByLz77TokenExtractor = new Lz77Token();

            lz77TokenExtractorMock
                .Setup(x => x.GetLz77TokenFromLz77Buffer(lz77Buffer))
                .Returns(lz77TokenReturnedByLz77TokenExtractor);
        }

        private void InitializeLz77BufferManagerMock()
        {
            var bytesRemovedFromLookAheadBufferPerIteration = 1;

            lz77BufferManagerMock
                .Setup(x => x.ChangeLz77BufferContentsBasedOnToken(It.IsAny<Lz77Buffer>(), It.IsAny<Lz77Token>(), It.IsAny<IFileReader>()))
                .Callback(() => lz77Buffer.LookAheadBuffer.RemoveRange(0, bytesRemovedFromLookAheadBufferPerIteration));

            numberOfIterations = lz77Buffer.LookAheadBuffer.Capacity / bytesRemovedFromLookAheadBufferPerIteration;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeFileThrowsArgumentNullExceptionForNullFileReader()
        {
            lz77Encoder.EncodeFile(null, fileWriterMock.Object, 4 ,4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, null, 4, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForBitsForOffsetSmallerThan3()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForBitsForOffsetBiggerThan15()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 16, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForBitsForLengthSmallerThan2()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForBitsForLengthBiggerThan7()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 8);
        }

        [TestMethod]
        public void EncodeFileCallsFileReaderReadBitsExpectedNumberOfTimes()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            fileReaderMock.Verify(x => x.ReadBits(8), Times.Exactly(lz77Buffer.LookAheadBuffer.Capacity));
        }

        [TestMethod]
        public void EncodeFileCallsLz77TokenExtractorGetLz77TokenFromLz77BufferOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77TokenExtractorMock.Verify(x => x.GetLz77TokenFromLz77Buffer(lz77Buffer), Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsLz77BufferManagerChangeLz77BufferContentsBasedOnTokenOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77BufferManagerMock
                .Verify(x => x.ChangeLz77BufferContentsBasedOnToken(lz77Buffer, lz77TokenReturnedByLz77TokenExtractor, fileReaderMock.Object)
                    , Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsLz77TokenWriterWriteTokenOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77TokenWriterMock.Verify(x => x.WriteToken(lz77TokenReturnedByLz77TokenExtractor, fileWriterMock.Object, 4, 4), Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsFileWriterFlushOnce()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            fileWriterMock.Verify(x => x.Flush(), Times.Once);
        }
    }
}