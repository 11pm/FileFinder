using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LineCounter
{
    class Program
    {
        /* EXAMPLE USAGE */
        static void Main(string[] args)
        {
            FileFinder filefinder = new FileFinder("C:/xampp/htdocs/bobo_gru/public/js", new List<string> { ".js" }, true);

            foreach (string item in filefinder.files)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        
    }
    
}
