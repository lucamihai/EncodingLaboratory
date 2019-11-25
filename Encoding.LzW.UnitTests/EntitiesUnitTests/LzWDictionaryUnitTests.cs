using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.LzW.Entities;
using Encoding.LzW.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.LzW.UnitTests.EntitiesUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class LzWDictionaryUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorThrowsArgumentExceptionForLimitSmallerThan256()
        {
            var lzWDictionary = new LzWDictionary(200, OnFullDictionaryOption.Empty);
        }

        [TestMethod]
        public void ConstructorSetsPublicPropertiesAsExpected()
        {
            const int limit = 300;
            const OnFullDictionaryOption onFullDictionaryOption = OnFullDictionaryOption.Empty;

            var lzWDictionary = new LzWDictionary(limit, onFullDictionaryOption);

            Assert.AreEqual(limit, lzWDictionary.Limit);
            Assert.AreEqual(onFullDictionaryOption, lzWDictionary.OnFullDictionaryOption);
        }

        [TestMethod]
        public void ContainsStringReturnsTrueForStringsComposedOfASingleCharacter()
        {
            var allAreContained = true;
            var lzWDictionary = new LzWDictionary(258, OnFullDictionaryOption.Empty);

            for (int i = 0; i < 256; i++)
            {
                var str = ((char) ((byte) i)).ToString();

                if (!lzWDictionary.ContainsString(str))
                {
                    allAreContained = false;
                    break;
                }
            }

            Assert.IsTrue(allAreContained);
        }

        [TestMethod]
        public void ContainsIndexReturnsTrueForValuesFrom0To255()
        {
            var allAreContained = true;
            var lzWDictionary = new LzWDictionary(258, OnFullDictionaryOption.Empty);

            for (uint i = 0; i < 256; i++)
            {
                if (!lzWDictionary.ContainsIndex(i))
                {
                    allAreContained = false;
                    break;
                }
            }

            Assert.IsTrue(allAreContained);
        }
    }
}