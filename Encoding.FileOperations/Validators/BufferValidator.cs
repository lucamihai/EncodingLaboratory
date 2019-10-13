using System;
using Encoding.FileOperations.Interfaces;

namespace Encoding.FileOperations.Validators
{
    public class BufferValidator
    {
        public void ValidateAndThrow(IBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
