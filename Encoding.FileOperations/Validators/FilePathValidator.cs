using System;
using System.IO;

namespace Encoding.FileOperations.Validators
{
    public class FilePathValidator
    {
        public void ValidateAndThrow(string filePath, bool checkIfExists = true)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException();
            }

            if (checkIfExists && !File.Exists(filePath))
            {
                throw new ArgumentException($"File '{filePath}' does not exist");
            }
        }
    }
}
