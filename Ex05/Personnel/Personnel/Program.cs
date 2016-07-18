using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            var P = new HelperClass();
            List<string> listOfDataFromFile = P.ReadFileToListOfStrings(@"Resources\The Notepade File.txt");
            if (listOfDataFromFile != null)
            {
                foreach (var line in listOfDataFromFile)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }

            Console.ReadKey();
        }
    }
}
