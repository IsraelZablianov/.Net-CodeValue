using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What’s your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}",userName);
            string userNumberStr;
            int amountOfLoopIteration = 0;
            bool goodInput = false;
            while(!goodInput && (amountOfLoopIteration > 10 || amountOfLoopIteration < 1))
            {
                Console.Write("Please enter a number bitween 1-10: ");
                userNumberStr = Console.ReadLine();
                goodInput = int.TryParse(userNumberStr, out amountOfLoopIteration);
            }

            StringBuilder userNameshifted = new StringBuilder();
            for (int i = 0; i < amountOfLoopIteration; i++)
            {
                userNameshifted.Append(' ', i);
                userNameshifted.Append(userName);
                Console.WriteLine(userNameshifted.ToString());
                userNameshifted.Clear();
            }
            //Of course it can be done with an internal loop.

            Console.Read();
        }
    }
}
