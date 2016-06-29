using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> multiDictionary = new MultiDictionary<int, string>();
            multiDictionary.Add(1, "one");
            multiDictionary.Add(2, "two");
            multiDictionary.Add(3, "three");
            multiDictionary.Add(1, "ich");
            multiDictionary.Add(2, "nee");
            multiDictionary.Add(3, "sun");

            foreach(var item in multiDictionary)
            {
                Console.WriteLine("{0}",item);
            }

            Console.WriteLine("===== remove [3, sun] ====={0}",Environment.NewLine);
            multiDictionary.Remove(3, "sun");

            foreach (var item in multiDictionary)
            {
                Console.WriteLine("{0}", item);
            }

            Console.WriteLine("===== remove all entries of 1 ====={0}", Environment.NewLine);
            multiDictionary.Remove(1);

            foreach (var item in multiDictionary)
            {
                Console.WriteLine("{0}", item);
            }

            Console.WriteLine("===== clear the dictionary and add all over again ====={0}", Environment.NewLine);
            multiDictionary.Clear();
            multiDictionary.Add(1, "one");
            multiDictionary.Add(2, "two");
            multiDictionary.Add(3, "three");
            multiDictionary.Add(1, "ich");
            multiDictionary.Add(2, "nee");
            multiDictionary.Add(3, "sun");

            foreach (var item in multiDictionary)
            {
                Console.WriteLine("{0}", item);
            }

            Console.WriteLine("===== ierating over the keys ====={0}", Environment.NewLine);
            foreach (var item in multiDictionary.Keys)
            {
                Console.WriteLine("{0}", item);
            }

            Console.WriteLine("===== count test ====={0}", Environment.NewLine);
            Console.WriteLine("Count = {0}", multiDictionary.Count);

            Console.WriteLine("Contain{0} - {1}", 1, multiDictionary.ContainsKey(1));
            Console.WriteLine("Contain{0} - {1}", 2, multiDictionary.ContainsKey(2));
            Console.WriteLine("Contain{0} - {1}", 3, multiDictionary.ContainsKey(3));
            Console.WriteLine("Contain{0} - {1}", 4, multiDictionary.ContainsKey(4));
            Console.WriteLine("Contain{0} - {1}", 5, multiDictionary.ContainsKey(5));
            Console.WriteLine("Contain{0} - {1}", 6, multiDictionary.ContainsKey(6));

            Console.WriteLine("===== add [0, null] ====={0}", Environment.NewLine);
            multiDictionary.Add(0,null);
            foreach (var item in multiDictionary)
            {
                Console.WriteLine("{0}", item);
            }
        }
    }
}
