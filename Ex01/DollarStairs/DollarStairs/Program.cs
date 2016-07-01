using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfDollarsStairs;
            bool goodInput;
            do
            {
                Console.Write("Please enter an integer number: ");
                goodInput = int.TryParse(Console.ReadLine(), out sizeOfDollarsStairs);
            }
            while (!goodInput);

            StringBuilder DollarsStairs = new StringBuilder();
            for (int i = 0; i < sizeOfDollarsStairs; i++)
            {
                DollarsStairs.Append('$');
                Console.WriteLine(DollarsStairs.ToString());
            }
        }
    }
}
