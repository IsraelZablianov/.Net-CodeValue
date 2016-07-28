using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class HelperClass
    {
        private static Mutex SyncFileMutex = new Mutex(false);

        public void Write(string path)
        {

            SyncFileMutex.WaitOne();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write))
            {
                StreamWriter sr = new StreamWriter(fs);

                for (int i = 0; i < 10000; i++)
                {
                    sr.Write($"Id = {System.Diagnostics.Process.GetCurrentProcess().Id} {Environment.NewLine}");
                }

                sr.Close();
            }

            SyncFileMutex.ReleaseMutex();
        }
    }
}
