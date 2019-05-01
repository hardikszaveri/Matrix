using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformSearch();
        }


        public static void PerformSearch()
        {
            int maxSize = 6;
            string inputFilePath = @"C:\Temp\dictionary.txt";
            string outputFilePath = @"C:\Temp\output.txt";
            List<string> wordList = new List<string>();

            // read data //
            if (File.Exists(inputFilePath))
            {
                // Read line by line a text file //  
                foreach (string line in File.ReadAllLines(inputFilePath))
                {
                    if(line.Length < maxSize)
                    {
                        wordList.Add(line);
                    }
                }
                    //Console.WriteLine(line);
            }

            // build list //
            List<string> matchList = new List<string>();
            for (int index = 3; index < maxSize; index++)
            {
                List<string> word1List = wordList.Where(x => x.Length == index).ToList();
                List<string> word2List = wordList.Where(x => x.Length == (maxSize - index)).ToList();

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

            // write to file //
            using (TextWriter writer = new StreamWriter(outputFilePath,false))
            {
                matchList.ForEach(w =>
                {
                    writer.WriteLine(w);
                });
            }

            Console.ReadKey();
        }
    }
}
