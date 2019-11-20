using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Utilities;
using Encoding.Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Huffman.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanHeaderWriterUnitTests
    {
        private HuffmanHeaderWriter huffmanHeaderWriter;
        private Mock<IFileWriter> fileWriterMock;

        [TestInitialize]
        public void Setup()
        {
            fileWriterMock = new Mock<IFileWriter>();
            huffmanHeaderWriter = new HuffmanHeaderWriter();
        }

        [TestMethod]
        public void WriteHeaderToFileCallsFileWriterWriteValueOnBitsExpectedNumberOfTimes()
        {
            var characterStatistics = ConstantsEncodingSystems.TextCharacterStatistics1;

            huffmanHeaderWriter.WriteHeaderToFile(characterStatistics, fileWriterMock.Object);

            var numberOfTimesValueZeroWasWrittenOnTwoBits = 256 - characterStatistics.Count;
            var numberOfTimesValueOneWasWrittenOnTwoBits = characterStatistics.Count(x => x.Apparitions <= byte.MaxValue);
            var numberOfTimesValueTwoWasWrittenOnTwoBits = characterStatistics.Count(x => x.Apparitions > byte.MaxValue && x.Apparitions <= short.MaxValue);
            var numberOfTimesValueThreeWasWrittenOnTwoBits = characterStatistics.Count(x => x.Apparitions > short.MaxValue);

            fileWriterMock.Verify(x => x.WriteValueOnBits(0, 2), Times.Exactly(numberOfTimesValueZeroWasWrittenOnTwoBits));
            fileWriterMock.Verify(x => x.WriteValueOnBits(1, 2), Times.Exactly(numberOfTimesValueOneWasWrittenOnTwoBits));
            fileWriterMock.Verify(x => x.WriteValueOnBits(2, 2), Times.Exactly(numberOfTimesValueTwoWasWrittenOnTwoBits));
            fileWriterMock.Verify(x => x.WriteValueOnBits(3, 2), Times.Exactly(numberOfTimesValueThreeWasWrittenOnTwoBits));

            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), 8), Times.Exactly(numberOfTimesValueOneWasWrittenOnTwoBits));
            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), 16), Times.Exactly(numberOfTimesValueTwoWasWrittenOnTwoBits));
            fileWriterMock.Verify(x => x.WriteValueOnBits(It.IsAny<uint>(), 32), Times.Exactly(numberOfTimesValueThreeWasWrittenOnTwoBits));
        }
    }
}