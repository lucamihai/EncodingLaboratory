﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;
using Encoding.FileOperations.Interfaces;
using Encoding.Systems.Utilities;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Encoding.Systems.UnitTests.UtilitiesUnitTests
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

        private List<CharacterStatistics> expectedCharacterStatistics;

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

            fileReaderMock.Setup(x => x.ReadBits(1))
                .Returns(1);

            fileReaderMock.Setup(x => x.ReadBits(3))
                .Returns(3);
        }

        private void SetupExpectedCharacterStatistics()
        {
            expectedCharacterStatistics = new List<CharacterStatistics>();

            for (int i = 0; i < charactersCodedInOneBit; i++)
            {
                expectedCharacterStatistics.Add(new CharacterStatistics { Apparitions = 1, Character = (char) i});
            }
            for (int i = charactersCodedInOneBit; i < charactersCodedInOneBit + charactersCodedInTwoBits; i++)
            {
                expectedCharacterStatistics.Add(new CharacterStatistics { Apparitions = 2, Character = (char)i });
            }
            for (int i = charactersCodedInOneBit + charactersCodedInTwoBits; i < charactersCodedInOneBit + charactersCodedInTwoBits + charactersCodedInThreeBits; i++)
            {
                expectedCharacterStatistics.Add(new CharacterStatistics { Apparitions = 3, Character = (char)i });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadCharacterStatisticsThrowsArgumentNullExceptionForNullFileReader()
        {
            huffmanHeaderReader.ReadCharacterStatistics(null);
        }

        [TestMethod]
        public void ReadCharacterStatisticsCallsFileReaderReadBitsWithParameterEqualToTwo256TimesPlusCharactersCodedInTwoBits()
        {
            huffmanHeaderReader.ReadCharacterStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(2), Times.Exactly(256 + charactersCodedInTwoBits));
        }

        [TestMethod]
        public void ReadCharacterStatisticsCallsFileReaderReadBitsWithParameterEqualToOneExpectedNumberOfTimes()
        {
            huffmanHeaderReader.ReadCharacterStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(1), Times.Exactly(charactersCodedInOneBit));
        }

        [TestMethod]
        public void ReadCharacterStatisticsCallsFileReaderReadBitsWithParameterEqualToThreeExpectedNumberOfTimes()
        {
            huffmanHeaderReader.ReadCharacterStatistics(fileReaderMock.Object);

            fileReaderMock.Verify(x => x.ReadBits(3), Times.Exactly(charactersCodedInThreeBits));
        }

        [TestMethod]
        public void ReadCharacterStatisticsReturnsExpectedList()
        {
            var returnedCharacterStatistics = huffmanHeaderReader.ReadCharacterStatistics(fileReaderMock.Object);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(expectedCharacterStatistics, returnedCharacterStatistics).AreEqual);
        }
    }
}