using System;
using System.IO;

namespace Encoding.FileOperations.Validators
{
    public class FilePathValidator
    {
        public void ValidateAndThrow(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File '{filePath}' does not exist");
            }
        }
    }
}
