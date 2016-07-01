using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = -1, b = 0, c = 0, delta;
            bool goodInput = false;
            bool fromCommandLine = args.Length != 0;
            string coefficients, resultAnswer;
            string Erroressage = string.Empty;
            string[] parts;
            if (!fromCommandLine)
            {
                Console.WriteLine(
@"Please enter three coefficients
as in the quadratic equation a*x^2 + b*x + c = 0.
seperated by the space key.");
            }
            do
            {
                if (!fromCommandLine)
                {
                    coefficients = Console.ReadLine();
                    parts = coefficients.Split(' ');
                }
                else
                {
                    parts = args;
                }

                goodInput = double.TryParse(parts[0], out a)
                    && double.TryParse(parts[1], out b)
                    && double.TryParse(parts[2], out c);
                if (!goodInput)
                {
                    Erroressage = "Wrong Input!!";
                }
                else if (a == 0)
                {
                    Erroressage = "That is not quadratic equation";
                }
                else if(parts.Length != 3)
                {
                    goodInput = false;
                    Erroressage = "Wrong quantity of arguments!!";
                }
                else
                {
                    goodInput = true;
                }

                if (!goodInput)
                {
                    Console.WriteLine("{0}, please try again..", Erroressage);
                }
            }
            while (!goodInput && !fromCommandLine);
            if (goodInput)
            {
                delta = (b * b) - (4 * a * c);
                if (delta == 0)
                {
                    resultAnswer = string.Format("There is only one answer: {0}.", (-b / (2 * a)));
                }
                else if (delta > 0)
                {
                    resultAnswer = string.Format(
    @"There are two possible answers : 
1. {0}. 
2. {1}.",
    ((-b - Math.Sqrt(delta)) / (2 * a)).ToString("F"), ((-b + Math.Sqrt(delta)) / (2 * a)).ToString("F"));
                }
                else
                {
                    resultAnswer = string.Format("No solution!!!");
                }

                Console.WriteLine(resultAnswer);
            }
        }
    }
}
