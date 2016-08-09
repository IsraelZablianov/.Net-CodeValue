using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Part A
            var job = new Job();
            job.AddProcessToJob(Process.Start("Notepad"));
            job.AddProcessToJob(Process.Start("Calc"));
            Console.ReadLine();
            job.Kill();

            //Part B => After runnig you will see
            //GC has disposed some of the object
            //due to memory presure I geuss
            for (int i = 0; i < 20; i++)
            {
                var jobObject = new Job();
            }

            Console.ReadLine();
        }
    }
}
