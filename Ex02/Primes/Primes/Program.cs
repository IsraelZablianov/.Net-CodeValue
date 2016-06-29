using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfPrimeNumbers;
            string range;
            string[] parts;
            int start = 0, end = 0;
            bool goodInput = false;
            do
            {
                Console.WriteLine(
@"Please enter two positive numbers, 
in form of (Start 'Tab' End)
for example : 5 6.");

                range = Console.ReadLine();
                parts = range.Split(' ');
                goodInput = int.TryParse(parts[0], out start) && int.TryParse(parts[1], out end) && parts.Length == 2 && start < end && start >= 1;
            }
            while (!goodInput);

            arrayOfPrimeNumbers = CalcPrimes(start, end);
            Console.Write("[");
            foreach (var item in arrayOfPrimeNumbers)
            {
                Console.Write(" {0} ",item.ToString());
            }

            Console.WriteLine("]");
        }

        static int[] CalcPrimes(int i_Start, int i_End)
        {
            bool prime;
            int[] returnedArray = null;
            ArrayList list = new ArrayList();
            for (int i = i_Start; i < i_End; i++)
            {
                prime = true;
                for (int j = 2; j <= Math.Sqrt(i) && prime; j++)
                {
                    if(((double)i / j) == (i / j))
                    {
                        prime = false;
                    }
                }

                if(prime)
                {
                    list.Add(i);
                }
            }

            returnedArray = new int[list.Count];
            list.CopyTo(returnedArray);
            return returnedArray;
        }
    }
}
