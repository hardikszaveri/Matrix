using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized
{
    public class SearchTool : ISearchTool
    {
        #region Members & Constructor
        private IFileHandler handler;
        private int maxSize;
        private string inputFilePath;
        private string outputFilePath;
        public SearchTool(string InputFilePath, string OutputFilePath, int MaxSize, IFileHandler Handler)
        {
            inputFilePath = InputFilePath;
            outputFilePath = OutputFilePath;
            maxSize = MaxSize;
            handler = Handler;
        }
        #endregion

        #region Methods
        public void PerformSearch()
        {
            WriteFile(BuildWordRepository(ReadFile()));
        }

        public List<string> ReadFile()
        {
            Console.WriteLine("Reading file");
            return handler.ReadFile(inputFilePath, maxSize);
        }

        public List<string> BuildWordRepository(List<string> InputList)
        {
            // build list //
            List<string> matchList = new List<string>();
            for (int index = 3; index < maxSize; index++)
            {
                List<string> word1List = InputList.Where(x => x.Length == index).ToList();
                List<string> word2List = InputList.Where(x => x.Length == (maxSize - index)).ToList();

                if (word1List != null && word2List != null)
                {
                    word1List.ForEach(x =>
                    {
                        word2List.Where(y => y != x).ToList().ForEach(w =>
                        {
                            matchList.Add(x + w);
                            Console.WriteLine(matchList[matchList.Count - 1]);
                        });
                    });
                }
            }

            Console.WriteLine("Total words found => " + matchList.Count);

            return matchList;
        }

        public void WriteFile(List<string> WordsToWrite)
        {
            handler.WriteFile(outputFilePath, WordsToWrite);

            Console.WriteLine("Match words written to Output file");
        }

        public void Dispose()
        {
            handler.Dispose();
        }
        #endregion
    }
}
