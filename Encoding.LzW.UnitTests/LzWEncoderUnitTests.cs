using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.LzW.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.LzW.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWEncoderUnitTests
    {
        private LzWEncoder lzWEncoder;
        private Mock<IFileReader> fileReaderMock;
        private Mock<IFileWriter> fileWriterMock;
        private OnFullDictionaryOption onFullDictionaryOption;
        private int numberOfBitsForIndex;

        [TestInitialize]
        public void Setup()
        {
            lzWEncoder = new LzWEncoder();

            fileReaderMock = new Mock<IFileReader>();
            fileWriterMock = new Mock<IFileWriter>();

            onFullDictionaryOption = OnFullDictionaryOption.Empty;
            numberOfBitsForIndex = 12;
        }

        [TestMethod]
        public void IndexesFromLastRunIsEmptyOnInitialization()
        {
            Assert.AreEqual(0, lzWEncoder.IndexesFromLastRun.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeFileThrowsArgumentNullExceptionForFileReader()
        {
            lzWEncoder.EncodeFile(null, fileWriterMock.Object, onFullDictionaryOption, numberOfBitsForIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeFileThrowsArgumentNullExceptionForFileWriter()
        {
            lzWEncoder.EncodeFile(fileReaderMock.Object, null, onFullDictionaryOption, numberOfBitsForIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForNumberOfBitsForIndexSmallerThan9()
        {
            lzWEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, onFullDictionaryOption, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeFileThrowsArgumentExceptionForNumberOfBitsForIndexBiggerThan15()
        {
            lzWEncoder.EncodeFile(fileReaderMock.Object, fileWriterMock.Object, onFullDictionaryOption, 16);
        }
    }
}