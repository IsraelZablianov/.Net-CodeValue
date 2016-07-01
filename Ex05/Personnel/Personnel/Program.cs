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
            Program P = new Program();
            //Reading from command line
            List<string> listOfDataFromFile = P.ReadFileToListOfStrings(args[0]);
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

        private List<string> ReadFileToListOfStrings(string name)
        {
            List<string> fileData = null;
            if(File.Exists(name))
            {
                fileData = new List<string>();
                FileStream fileStream = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                while(streamReader.EndOfStream == false)
                {
                    fileData.Add(streamReader.ReadLine());
                }
                fileStream.Close();
                streamReader.Close();
            }

            return fileData;
        }
    }
}
