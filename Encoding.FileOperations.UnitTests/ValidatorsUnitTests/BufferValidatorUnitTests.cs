using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.FileOperations.UnitTests.ValidatorsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BufferValidatorUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateAndThrowThrowsArgumentNullExceptionForNullBuffer()
        {
            var bufferValidator = new BufferValidator();

            bufferValidator.ValidateAndThrow(null);
        }

        [TestMethod]
        public void ValidateAndThrowDoesNotThrowAnyExceptionForValidBuffer()
        {
            var bufferValidator = new BufferValidator();

            var validBuffer = Entities.GetValidBuffer();
            bufferValidator.ValidateAndThrow(validBuffer);
        }
    }
}
