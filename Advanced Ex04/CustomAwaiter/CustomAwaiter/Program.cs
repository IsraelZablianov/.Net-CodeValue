using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new HelperClassForConsole();
            //helper.AwaitIntAsync(3000);
            Process myProcess;
            myProcess = Process.Start("Notepad.exe");
            myProcess.EnableRaisingEvents = true;
            helper.AwaitProcessAsync(myProcess);
            Console.ReadLine();
        }
    }
}
