using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Optimized.Tests
{
    [TestClass]
    public class SearchToolUnitTest
    {
        [TestMethod]
        public void ReadfileTest()
        {
            int maxSize = 6;
            string inputFilePath = @"C:\Temp\dictionary.txt";
            string outputFilePath = @"C:\Temp\output.txt";
            List<string> wordList = new List<string>();

            Mock<IFileHandler> handler = new Mock<IFileHandler>();

            handler.Setup(x => x.ReadFile(inputFilePath, maxSize)).Returns(new List<string>() { "test", "12", "saskatoon" });

            ISearchTool searchTool = new SearchTool(inputFilePath, outputFilePath, maxSize, handler.Object);

            wordList = searchTool.ReadFile();

            Assert.IsTrue(wordList.Count == 3);

        }

        [TestMethod]
        public void BuildRepositoryTest()
        {
            int maxSize = 6;
            string inputFilePath = @"C:\Temp\dictionary.txt";
            string outputFilePath = @"C:\Temp\output.txt";
            List<string> wordList = new List<string>();

            Mock<IFileHandler> handler = new Mock<IFileHandler>();

            handler.Setup(x => x.ReadFile(inputFilePath, maxSize)).Returns(new List<string>() { "test12", "word", "12", "reg", "ina" });

            ISearchTool searchTool = new SearchTool(inputFilePath, outputFilePath, maxSize, handler.Object);

            wordList = searchTool.ReadFile();

            List<string> matchList = searchTool.BuildWordRepository(wordList);

            Assert.IsTrue(matchList.Count == 3);
        }
    }
}
