using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            int userDecimalNumber, amountOfOne = 0, binary = 0;
            bool goodInput;
            do
            {
                Console.Write("Please enter an integer number: ");
                goodInput = int.TryParse(Console.ReadLine(), out userDecimalNumber);
            }
            while (!goodInput);

            
            int remainder, movesTheNextNumberToLeftByMultIn10 = 1;
            int decimalNumber = userDecimalNumber;
            //I assume you didn't mean that I will use that function
            //string binary = Convert.ToString(decimalNumber, 2);
            while (decimalNumber != 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                binary += remainder * movesTheNextNumberToLeftByMultIn10;
                movesTheNextNumberToLeftByMultIn10 *= 10;
            }

            while(userDecimalNumber != 0)
            {
                if((userDecimalNumber & 1) != 0)
                {
                    amountOfOne++;
                }

                userDecimalNumber = userDecimalNumber >> 1;
            }

            Console.WriteLine(
@"The number in binary is: {0} 
The number contains {1} “1”s",
                binary, amountOfOne);

            Console.Read();
        }
    }
}
