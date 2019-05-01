using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************* Program Begins **********************");
            try
            {
                ISearchTool searchTool = new SearchTool(ConfigurationManager.AppSettings["InputFilePath"], ConfigurationManager.AppSettings["OutputFilePath"],
                  Convert.ToInt32(ConfigurationManager.AppSettings["WordSize"]), new FileHandler());

                searchTool.PerformSearch();

                searchTool.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.Message);
            }

            finally
            {
                Console.WriteLine("*********************** Program Ends *********************");
            }


            Console.ReadKey();
        }
    }
}
