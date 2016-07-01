using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = 0, secondNumber = 0, CalculationAnswer = 0;
            string choosenOperator;
            bool goodInpt = false;
            do
            {
                Console.Write("Please enter First number: ");
                goodInpt = double.TryParse(Console.ReadLine(), out firstNumber);
            }
            while (!goodInpt);

            do
            {
                Console.Write("Please enter second number: ");
                goodInpt = double.TryParse(Console.ReadLine(), out secondNumber);
            }
            while (!goodInpt);

            do
            {
                goodInpt = true;
                Console.Write("Please choose operator (+,-,* or /): ");
                choosenOperator = Console.ReadLine();
                switch(choosenOperator)
                {
                    case "+":
                        CalculationAnswer = firstNumber + secondNumber;
                        break;
                    case "-":
                        CalculationAnswer = firstNumber - secondNumber;
                        break;
                    case "*":
                        CalculationAnswer = firstNumber * secondNumber;
                        break;
                    case "/":
                        CalculationAnswer = firstNumber / secondNumber;
                        break;
                    default:
                        Console.WriteLine("Wrong operator");
                        goodInpt = false;
                        break;
                }
            }
            while (!goodInpt);

            Console.WriteLine("The result = {0}", CalculationAnswer);
            Console.Read();
        }
    }
}
