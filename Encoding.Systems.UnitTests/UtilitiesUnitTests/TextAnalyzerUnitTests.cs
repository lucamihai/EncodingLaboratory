using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.Systems.Utilities;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Systems.UnitTests.UtilitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TextAnalyzerUnitTests
    {
        private TextAnalyzer textAnalyzer;

        [TestInitialize]
        public void Setup()
        {
            textAnalyzer = new TextAnalyzer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCharacterStatisticsFromTextThrowsArgumentNullExceptionForNullText()
        {
            textAnalyzer.GetCharacterStatisticsFromText(null);
        }

        [TestMethod]
        public void GetCharacterStatisticsFromTextReturnsEmptyListForEmptyText()
        {
            var list = textAnalyzer.GetCharacterStatisticsFromText(string.Empty);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void GetCharacterStatisticsFromTextReturnsExpectedList()
        {
            var characterStatistics = textAnalyzer.GetCharacterStatisticsFromText(Constants.Text1);

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(Constants.TextCharacterStatistics1, characterStatistics).AreEqual);
        }
    }
}
