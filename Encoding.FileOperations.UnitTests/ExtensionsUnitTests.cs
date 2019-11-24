using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.FileOperations.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ExtensionsUnitTests
    {
        private Mock<IFileWriter> fileWriterMock;

        [TestInitialize]
        public void Setup()
        {
            fileWriterMock = new Mock<IFileWriter>();
        }

        [TestMethod]
        public void WriteToFileCallsFileWriteWriteValueOnBitsWithNumberOfBitsSetTo8OnceForEachCharacterInString()
        {
            const string s = "Hello world";

            s.WriteToFile(fileWriterMock.Object);

            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), 8), Times.Exactly(s.Length));
        }

        [TestMethod]
        public void WriteToFileCallsFileWriterWriteValueOnBitsWithExpectedValues()
        {
            const string s = "ABC";

            s.WriteToFile(fileWriterMock.Object);

            fileWriterMock.Verify(x => x.WriteValueOnBits(65, 8), Times.Once);
            fileWriterMock.Verify(x => x.WriteValueOnBits(66, 8), Times.Once);
            fileWriterMock.Verify(x => x.WriteValueOnBits(67, 8), Times.Once);
        }
    }
}