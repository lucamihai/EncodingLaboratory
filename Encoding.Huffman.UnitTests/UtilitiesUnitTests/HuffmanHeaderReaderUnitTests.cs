using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Interfaces;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Utilities;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Huffman.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HuffmanHeaderReaderUnitTests
    {
        private HuffmanHeaderReader huffmanHeaderReader;
        private Mock<IFileReader> fileReaderMock;

        private int charactersNotCoded;
        private int charactersCodedInOneBit;
        private int charactersCodedInTwoBits;
        private int charactersCodedInThreeBits;

        private List<ByteStatistics> expectedCharacterStatistics;

        [TestInitialize]
        public void Setup()
        {
            fileReaderMock = new Mock<IFileReader>();
            huffmanHeaderReader = new HuffmanHeaderReader();

            SetupFileReaderMock();
            SetupExpectedCharacterStatistics();
        }

        private void SetupFileReaderMock()
        {
            charactersCodedInOneBit = 2;
            charactersCodedInTwoBits = 0;
            charactersCodedInThreeBits = 2;
            charactersNotCoded = 256 - charactersCodedInOneBit - charactersCodedInTwoBits - charactersCodedInThreeBits;

            var setupSequenceForFileReaderReadBits = fileReaderMock
                .SetupSequence(x => x.ReadBits(2));

            for (int i = 0; i < charactersCodedInOneBit; i++)
            {
                setupSequenceForFileReaderReadBits.Returns(1);
            }
            for (int i = 0; i < charactersCodedInTwoBits; i++)
            {
                setupSequenceForFileReaderReadBits.Returns(2);
            }
            for (int i = 0; i < charactersCodedInThreeBits; i++)
            {
                setupSequenceForFileReaderReadBits.Returns(3);
            }
            for (int i = 0; i < charactersNotCoded; i++)
            {
                setupSequenceForFileReaderReadBits.Returns(0);
            }

            fileReaderMock.Setup(x => x.ReadBits(1 * 8))
                .Returns(1);

            fileReaderMock.Setup(x => x.ReadBits(2 * 8))
                .Returns(2);

            fileReaderMock.Setup(x => x.ReadBits(4 * 8))
                .Returns(3);
        }

        private void SetupExpectedCharacterStatistics()
        {
            expectedCharacterStatistics = new List<ByteStatistics>();

            for (int i = 0; i < charactersCodedInOneBit; i++)
            {
                expectedCharacterStatistics.Add(new ByteStatistics { Apparitions = 1, Byte = (byte)i});
            }
            for (int i = charactersCodedInOneBit; i < charactersCodedInOneBit + charactersCodedInTwoBits; i++)
            {
                expectedCharacterStatistics.Add(new ByteStatistics { Apparitions = 2, Byte = (byte)i });
            }
            for (int i = charactersCodedInOneBit + charactersCodedInTwoBits; i < charactersCodedInOneBit + charactersCodedInTwoBits + charactersCodedInThreeBits; i++)
            {
                expectedCharacterStatistics.Add(new ByteStatistics { Apparitions = 3, Byte = (byte)i });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadByteStatisticsThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanHeaderReader.ReadByteStatistics(null);
        }

        [TestMethod]
        public void ReadByteStatisticsCallsFileReaderReadBitsWithParameterEqualToTwo256Times()
        {
            huffmanHeaderReader.ReadByteStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(2), Times.Exactly(256 + charactersCodedInTwoBits));
        }

        [TestMethod]
        public void ReadByteStatisticsCallsFileReaderReadBitsWithParameterEqualToOneByeExpectedNumberOfTimes()
        {
            huffmanHeaderReader.ReadByteStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(1 * 8), Times.Exactly(charactersCodedInOneBit));
        }

        [TestMethod]
        public void ReadByteStatisticsCallsFileReaderReadBitsWithParameterEqualToTwoBytesExpectedNumberOfTimes()
        {
            huffmanHeaderReader.ReadByteStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(2 * 8), Times.Exactly(charactersCodedInTwoBits));
        }

        [TestMethod]
        public void ReadByteStatisticsCallsFileReaderReadBitsWithParameterEqualToThreeBytesExpectedNumberOfTimes()
        {
            huffmanHeaderReader.ReadByteStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(4 * 8), Times.Exactly(charactersCodedInThreeBits));
        }

        [TestMethod]
        public void ReadByteStatisticsReturnsExpectedList()
        {
            var returnedCharacterStatistics = huffmanHeaderReader.ReadByteStatistics(fileReaderMock.Object);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(expectedCharacterStatistics, returnedCharacterStatistics).AreEqual);
        }
    }
}