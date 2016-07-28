using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = Directory.CreateDirectory(@"c:\temp");
            var path = Path.Combine(dir.FullName, "data.txt");
            var task1 = Task.Run(() =>
            {
                new HelperClass().Write(path);
            });

            var task2 = Task.Run(() =>
            {
                new HelperClass().Write(path);
            });

            Task.WaitAll(task1, task2);
        }
    }
}
