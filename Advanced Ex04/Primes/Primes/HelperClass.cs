using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class HelperClass
    {
        public List<int> GetStartEndAndMaxDegree()
        {
            var list = new List<int>();
            string input;
            string[] parts;
            int start = 0, end = 0, maxDegreeOfParallelism = 0;
            bool goodInput = false;
            do
            {
                Console.WriteLine(
@"Please enter three positive numbers, 
in form of (Start 'Tab' End 'Tab' maximum degree of parallelism)
for example : ""5 6 3"".");

                input = Console.ReadLine();
                parts = input.Split(' ');
                goodInput = int.TryParse(parts[0], out start)
                    && int.TryParse(parts[1], out end)
                    && int.TryParse(parts[2], out maxDegreeOfParallelism)
                    && parts.Length == 3
                    && start < end && start >= 1
                    && maxDegreeOfParallelism >= 1;
            }
            while (!goodInput);

            list.Add(start);
            list.Add(end);
            list.Add(maxDegreeOfParallelism);

            return list;
        }

        public string NowDateWithMiliSec()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }
    }
}
