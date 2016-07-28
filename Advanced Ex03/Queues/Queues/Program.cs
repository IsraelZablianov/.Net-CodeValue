using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new LimitedQueue<int>(3);

            for (int i = 1; i <= 50;)
            {
                Thread thread = new Thread(_ =>
                {
                    queue.Enqueue(i++);
                });

                thread.Start();
            }

            for (int i = 1; i <= 50; i++)
            {
                Thread thread = new Thread(_ =>
                {
                    Console.WriteLine($"Thread {i} dequeue = {(queue.Count > 0 ? queue.Dequeue() : 0)}");
                });

                thread.Start();
            }
        }
    }
}
