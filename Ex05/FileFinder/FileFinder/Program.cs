using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
            //2 - methods, same output. 
            p.SearchPaternRecursive(args[0], args[1]);
            Console.WriteLine("============================");
            p.SearchPaternUsingDirectoryInfo(args);

            Console.ReadKey();
        }

        private void SearchPaternUsingDirectoryInfo(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(args[0]);
            if (directoryInfo.Exists)
            {
                foreach (var file in (directoryInfo.GetFiles(string.Format("*{0}*", args[1]), SearchOption.AllDirectories)))
                {
                    Console.WriteLine(
    @"Name: {0}
Length: {1}{2}", file.Name, file.Length, Environment.NewLine);
                }
            }
        }

        private void SearchPaternRecursive(string path, string searchPatern)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (string p in Directory.GetDirectories(path))
                {
                    SearchPaternRecursive(p, searchPatern);
                }

                foreach (var file in (directoryInfo.GetFiles(string.Format("*{0}*", searchPatern))))
                {
                    Console.WriteLine(
    @"Name: {0}
Length: {1}{2}", file.Name, file.Length, Environment.NewLine);
                }
            }
        }
    }
}
