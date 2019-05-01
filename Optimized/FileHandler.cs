using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized
{
    public class FileHandler : IFileHandler
    {
        #region Methods
        public List<string> ReadFile(string InputFilePath, int MaxSize)
        {
            List<string> wordList = new List<string>();

            // read data //
            if (File.Exists(InputFilePath))
            {
                // Read line by line a text file //  
                foreach (string line in File.ReadAllLines(InputFilePath))
                {
                    if (line.Length < MaxSize)
                    {
                        wordList.Add(line);
                    }
                }
            }

            return wordList;
        }

        public void WriteFile(string OutputFilePath, List<string> WordsToWrite)
        {
            // write to file //
            using (TextWriter writer = new StreamWriter(OutputFilePath, false))
            {
                WordsToWrite.ForEach(w =>
                {
                    writer.WriteLine(w);
                });
            }
        }

        public void Dispose() { }

        #endregion
    }
}
