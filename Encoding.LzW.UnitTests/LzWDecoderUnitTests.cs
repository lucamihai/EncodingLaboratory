using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.LzW.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWDecoderUnitTests
    {
        private LzWDecoder lzWDecoder;
        private Mock<IFileReader> fileReaderMock;
        private Mock<IFileWriter> fileWriterMock;

        [TestInitialize]
        public void Setup()
        {
            lzWDecoder = new LzWDecoder();

            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeFileThrowsArgumentNullExceptionForNullFileReader()
        {
            lzWDecoder.DecodeFile(null, fileWriterMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeFileThrowsArgumentNullExceptionForNullFileWriter()
        {
            lzWDecoder.DecodeFile(fileReaderMock.Object, null);
        }
    }
}