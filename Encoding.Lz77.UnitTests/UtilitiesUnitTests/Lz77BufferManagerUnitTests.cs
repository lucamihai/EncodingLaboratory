using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Lz77.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Lz77BufferManagerUnitTests
    {
        private Lz77BufferManager lz77BufferManager;
        private Lz77Buffer lz77Buffer;
        private Lz77Token lz77Token;
        private Mock<IFileReader> fileReaderMock;

        [TestInitialize]
        public void Setup()
        {
            lz77BufferManager = new Lz77BufferManager();
            lz77Buffer = Constants.GetLz77Buffer1();
            lz77Token = Constants.ExpectedTokenForLz77Buffer1();
            fileReaderMock = new Mock<IFileReader>();

            SetupFileReaderMock();
        }

        private void SetupFileReaderMock()
        {
            fileReaderMock
                .Setup(x => x.ReadBits(8))
                .Returns(12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryToFillLookAheadBufferThrowsArgumentNullExceptionForNullLz77Buffer()
        {
            lz77BufferManager.TryToFillLookAheadBuffer(null, fileReaderMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryToFillLookAheadBufferThrowsArgumentNullExceptionForNullFileReader()
        {
            lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, null);
        }

        [TestMethod]
        public void TryToFillLookAheadBufferCallsFileReaderReadBitsExpectedNumberOfTimesIfFileReaderDidNotReachEndOfFile()
        {
            var expectedNumberOfCalls = lz77Buffer.LookAheadBuffer.Capacity - lz77Buffer.LookAheadBuffer.Count;

            lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(8), Times.Exactly(expectedNumberOfCalls));
        }

        [TestMethod]
        public void TryToFillLookAheadBufferMakesLookAheadBufferFullIfFileReaderDidNotReachEndOfFile()
        {
            lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, fileReaderMock.Object);

            Assert.AreEqual(lz77Buffer.LookAheadBuffer.Capacity, lz77Buffer.LookAheadBuffer.Count);
        }

        [TestMethod]
        public void TryToFillLookAheadBufferWillNotAddBytesInLookAheadBufferIfFileReaderReachedEndOfFile()
        {
            fileReaderMock
                .Setup(x => x.ReachedEndOfFile)
                .Returns(true);
            var initialCount = lz77Buffer.LookAheadBuffer.Count;

            lz77BufferManager.TryToFillLookAheadBuffer(lz77Buffer, fileReaderMock.Object);

            Assert.AreEqual(initialCount, lz77Buffer.LookAheadBuffer.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyLookAheadBufferBasedOnLz77TokenThrowsArgumentNullExceptionForNullLz77Buffer()
        {
            lz77BufferManager.EmptyLookAheadBufferBasedOnLz77Token(null, lz77Token);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyLookAheadBufferBasedOnLz77TokenThrowsArgumentNullExceptionForNullLz77Token()
        {
            lz77BufferManager.EmptyLookAheadBufferBasedOnLz77Token(lz77Buffer, null);
        }

        [TestMethod]
        public void EmptyLookAheadBufferBasedOnLz77TokenRemovesExpectedFirstNumberOfElementsFromLookAheadBuffer()
        {
            var lookAheadBufferCountBeforeCall = lz77Buffer.LookAheadBuffer.Count;

            lz77BufferManager.EmptyLookAheadBufferBasedOnLz77Token(lz77Buffer, lz77Token);

            Assert.IsTrue(lz77Buffer.LookAheadBuffer.Count == lookAheadBufferCountBeforeCall - 1 - lz77Token.Length);
        }
    }
}