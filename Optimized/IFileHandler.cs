using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized
{
    public interface IFileHandler : IDisposable
    {
        List<string> ReadFile(string InputFilePath, int MaxSize);
        void WriteFile(string OutputFilePath, List<string> WordsToWrite);
    }
}
