using System;
using System.Diagnostics.CodeAnalysis;
using Encoding.FileOperations;
using Encoding.ImagePrediction.Utilities;
using Encoding.Tests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.ImagePrediction.IntegrationTests.UtilitiesIntegrationTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ErrorMatrixWriterPlusErrorMatrixReaderIntegrationTests
    {
        private ErrorMatrixWriter errorMatrixWriter;
        private ErrorMatrixReader errorMatrixReader;
        private string filePathErrorMatrix;

        [TestInitialize]
        public void Setup()
        {
            errorMatrixWriter = new ErrorMatrixWriter();
            errorMatrixReader = new ErrorMatrixReader();
            filePathErrorMatrix = $"{Environment.CurrentDirectory}\\temp.txt";
        }

        [TestMethod]
        public void ErrorMatrixIsCorrectlyWrittenAndRead()
        {
            var originalErrorMatrix = GetRandomErrorMatrix();
            int[,] readErrorMatrix;

            using (var fileWriter = new FileWriter(filePathErrorMatrix, new FileOperations.Buffer()))
            {
                errorMatrixWriter.WriteErrorMatrix(originalErrorMatrix, fileWriter);
                fileWriter.Flush();
            }

            using (var fileReader = new FileReader(filePathErrorMatrix, new FileOperations.Buffer()))
            {
                readErrorMatrix = errorMatrixReader.ReadErrorMatrix(fileReader);
            }

            var comparer = new CompareLogic();
            Assert.IsTrue(comparer.Compare(originalErrorMatrix, readErrorMatrix).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            TestMethods.DeleteFileIfExists(filePathErrorMatrix);
        }

        private int[,] GetRandomErrorMatrix()
        {
            var errorMatrix = new int[256, 256];
            var rng = new Random();

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    errorMatrix[i, j] = rng.Next(-255, 255);
                }
            }

            return errorMatrix;
        }
    }
}