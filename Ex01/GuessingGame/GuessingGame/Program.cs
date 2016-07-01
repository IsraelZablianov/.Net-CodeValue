using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGueeses = 0;
            const int numberOfGuessesAllowed = 7;
            bool GuessedRight = false;
            int numberGueesed, secret = new Random().Next(1, 100);
            bool goodInput = false;
            while (!GuessedRight && numberOfGueeses < numberOfGuessesAllowed)
            {              
                Console.Write("Guess the number: ");
                goodInput = int.TryParse(Console.ReadLine(), out numberGueesed);                
                while (!goodInput)
                {
                    Console.Write("Error try again and Guess the number: ");
                    goodInput = int.TryParse(Console.ReadLine(), out numberGueesed);
                }

                if (numberGueesed < secret)
                {
                    Console.WriteLine("Too small.");
                }
                else if (numberGueesed > secret)
                {
                    Console.WriteLine("Too big.");
                }
                else if (numberGueesed == secret)
                {
                    GuessedRight = true;
                }

                numberOfGueeses++;
            }

            if (GuessedRight)
            {
                Console.WriteLine("Correct, it took you only {0} guesses.", numberOfGueeses);
            }
            else
            {
                Console.WriteLine("You failed the correct number is {0}...", secret);
            }
        }
    }
}

