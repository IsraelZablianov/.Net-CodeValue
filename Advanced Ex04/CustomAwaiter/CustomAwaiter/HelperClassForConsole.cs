using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class HelperClassForConsole
    {
        public async void AwaitIntAsync(int delay)
        {
            int x = delay;
            await x;
            Console.WriteLine("Done");
        }

        public async void AwaitProcessAsync(Process pr)
        {
            await pr;
            Console.WriteLine("done");
        }
    }
}
