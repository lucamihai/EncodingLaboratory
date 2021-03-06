﻿using System;
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
            lz77TokenExtractorMock = new Mock<ILz77TokenExtractor>();
            lz77BufferManagerMock = new Mock<ILz77BufferManager>();
            lz77TokenWriterMock = new Mock<ILz77TokenWriter>();
            lz77Encoder = new Lz77Encoder(lz77TokenExtractorMock.Object, lz77BufferManagerMock.Object, lz77TokenWriterMock.Object);

            InitializeLz77Buffer();

            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();

            InitializeLz77TokenExtractorMock();
            InitializeLz77BufferManagerMock();
        }

        private void InitializeLz77Buffer()
        {
            offset = 4;
            length = 4;

            lz77Encoder.Lz77Buffer.SetOffsetAndLimit(offset, length);

            lz77Encoder.Lz77Buffer.LookAheadBuffer.Add(3);
            lz77Encoder.Lz77Buffer.LookAheadBuffer.Add(3);
            lz77Encoder.Lz77Buffer.LookAheadBuffer.Add(3);
        }

        private void InitializeLz77TokenExtractorMock()
        {
            lz77TokenReturnedByLz77TokenExtractor = new Lz77Token();

            lz77TokenExtractorMock
                .Setup(x => x.GetLz77TokenFromLz77Buffer(lz77Encoder.Lz77Buffer))
                .Returns(lz77TokenReturnedByLz77TokenExtractor);
        }

        private void InitializeLz77BufferManagerMock()
        {
            var bytesRemovedFromLookAheadBufferPerIteration = 1;

            lz77BufferManagerMock
                .Setup(x => x.EmptyLookAheadBufferBasedOnLz77Token(It.IsAny<Lz77Buffer>(), It.IsAny<Lz77Token>()))
                .Callback(() => lz77Encoder.Lz77Buffer.LookAheadBuffer.RemoveRange(0, bytesRemovedFromLookAheadBufferPerIteration));

            numberOfIterations = lz77Encoder.Lz77Buffer.LookAheadBuffer.Count / bytesRemovedFromLookAheadBufferPerIteration;
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
        public void EncodeFileMakesExpectedCallsToFileWriter()
        {
            const int bitsForOffset = 8;
            const int bitsForLength = 6;

            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, bitsForOffset, bitsForLength);

            fileWriterMock.Verify(x => x.WriteValueOnBits(bitsForOffset, 4));
            fileWriterMock.Verify(x => x.WriteValueOnBits(bitsForLength, 3));
        }

        [TestMethod]
        public void EncodeFileCallsLz77TokenExtractorGetLz77TokenFromLz77BufferOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77TokenExtractorMock.Verify(x => x.GetLz77TokenFromLz77Buffer(lz77Encoder.Lz77Buffer), Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsLz77BufferManagerTryToFillSearchBufferBasedOnLz77TokenOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77BufferManagerMock
                .Verify(x => x.TryToFillSearchBufferBasedOnLz77Token(lz77Encoder.Lz77Buffer, lz77TokenReturnedByLz77TokenExtractor)
                    , Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsLz77BufferManagerEmptyLookAheadBufferBasedOnLz77TokenOnceForEachIteration()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77BufferManagerMock
                .Verify(x => x.EmptyLookAheadBufferBasedOnLz77Token(lz77Encoder.Lz77Buffer, lz77TokenReturnedByLz77TokenExtractor)
                    , Times.Exactly(numberOfIterations));
        }

        [TestMethod]
        public void EncodeFileCallsBufferManagerTryToFillLookAheadBufferOnceForEachIterationPlusOne()
        {
            lz77Encoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, 4, 4);

            lz77BufferManagerMock.Verify(x => x.TryToFillLookAheadBuffer(lz77Encoder.Lz77Buffer, fileReaderMock.Object), Times.Exactly(numberOfIterations + 1));
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