using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized
{
    public interface ISearchTool : IDisposable
    {
        void PerformSearch();
        List<string> ReadFile();
        List<string> BuildWordRepository(List<string> InputList);
        void WriteFile(List<string> WordsToWrite);
    }
}
