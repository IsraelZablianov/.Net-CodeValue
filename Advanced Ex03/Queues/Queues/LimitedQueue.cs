using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        private Queue<T> _myQueue = new Queue<T>();
        private Semaphore _semaphore;

        public int Count
        {
            get
            {
                return _myQueue.Count;
            }
        }

        public LimitedQueue(int size)
        {
            _semaphore = new Semaphore(size, size);
        }


        //I added some UI here even though it's bad.
        //Just to see the effect.
        public void Enqueue(T item)
        {
            Console.WriteLine("enter");
            _semaphore.WaitOne();
            _myQueue.Enqueue(item);
            Console.WriteLine($"Enqueue = {item}");
            Thread.Sleep(2000);
            _semaphore.Release(1);
            Console.WriteLine("releasd");
        }

        public T Dequeue()
        {
            Console.WriteLine("enter");
            _semaphore.WaitOne();
            T item = _myQueue.Dequeue();
            Console.WriteLine("Done");
            Thread.Sleep(1000);
            _semaphore.Release(1);
            Console.WriteLine("releasd");
            return item;
        }

        //"readers wont fail to read if there are concurrent writers".
        public T ElementAt(int i)
        {
            return _myQueue.ElementAt(i);
        }
    }
}
