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
    public class Lz77TokenWriterUnitTests
    {
        private Lz77TokenWriter lz77TokenWriter;
        private Lz77Token lz77Token;
        private Mock<IFileWriter> fileWriterMock;

        [TestInitialize]
        public void Setup()
        {
            lz77TokenWriter = new Lz77TokenWriter();
            lz77Token = new Lz77Token { Position = 4, Length = 5, Byte = 31};
            fileWriterMock = new Mock<IFileWriter>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTokenThrowsArgumentNullExceptionForNullLz77Token()
        {
            lz77TokenWriter.WriteToken(null, fileWriterMock.Object, 4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTokenThrowsArgumentNullExceptionForNullFileWriter()
        {
            lz77TokenWriter.WriteToken(lz77Token, null, 4, 5);
        }

        [TestMethod]
        public void WriteTokenMakesExpectedCallsOnFileWriterWriteValueOnBits()
        {
            const int bitsForOffset = 4;
            const int bitsForLength = 5;

            lz77TokenWriter.WriteToken(lz77Token, fileWriterMock.Object, bitsForOffset, bitsForLength);

            fileWriterMock.Verify(x => x.WriteValueOnBits((uint)lz77Token.Position, bitsForOffset));
            fileWriterMock.Verify(x => x.WriteValueOnBits((uint)lz77Token.Length, bitsForLength));
            fileWriterMock.Verify(x => x.WriteValueOnBits(lz77Token.Byte, 8));
        }
    }
}