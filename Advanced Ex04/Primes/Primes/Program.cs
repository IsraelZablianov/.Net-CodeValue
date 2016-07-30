using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new HelperClass();
            var inputParameters = helper.GetStartEndAndMaxDegree();
            Console.WriteLine(helper.NowDateWithMiliSec());
            var primesList1 = CalcPrimes(inputParameters[0], inputParameters[1], inputParameters[2]);
            Console.WriteLine(helper.NowDateWithMiliSec());

            var inputParameters2 = helper.GetStartEndAndMaxDegree();
            Console.WriteLine(helper.NowDateWithMiliSec());
            var primesList2 = CalcPrimes(inputParameters2[0], inputParameters2[1], inputParameters2[2]);
            Console.WriteLine(helper.NowDateWithMiliSec());

            Console.WriteLine($"are they equal = {primesList1.OrderBy(a => a).SequenceEqual(primesList2.OrderBy(a => a))}");
            Console.WriteLine("======================-Ex-2-======================");
            //the next operation will take 2 minutes.
            var list1 = CalcPrimes(1, 30000000);
            Console.WriteLine($"amount of primes before stop or end = {list1.Count}");
            Console.ReadLine();
        }
        
        //Exercise 1
        static List<int> CalcPrimes(int first, int last, int maxDegreeOfParallelism)
        {
            var listOfPrimes = new List<int>();
            var lockObj = new object();
            Parallel.For(first, last, new ParallelOptions()
            { MaxDegreeOfParallelism = maxDegreeOfParallelism },
                i =>
                {
                    bool prime = true;
                    for (int j = 2; j <= Math.Sqrt(i) && prime; j++)
                    {
                        if (((double)i / j) == (i / j))
                        {
                            prime = false;
                        }
                    }

                    if (prime && i >= 1)
                    {
                        lock (lockObj)
                        {
                            listOfPrimes.Add(i);
                        }
                    }
                });

            return listOfPrimes;
        }

        //Exercise 2
        static List<int> CalcPrimes(int first, int last)
        {
            var listOfPrimes = new List<int>();
            var lockObj = new object();

            Parallel.For(first, last,
                (i, loopState) =>
                {
                    var rndInt = new Random().Next(10000000);
                    if(rndInt == 0)
                    {
                        loopState.Stop();
                    }
                    bool prime = true;
                    for (int j = 2; j <= Math.Sqrt(i) && prime; j++)
                    {
                        if (((double)i / j) == (i / j))
                        {
                            prime = false;
                        }
                    }

                    if (prime && i >= 1)
                    {
                        lock (lockObj)
                        {
                            listOfPrimes.Add(i);
                        }
                    }
                });

            return listOfPrimes;
        }
    }
}
