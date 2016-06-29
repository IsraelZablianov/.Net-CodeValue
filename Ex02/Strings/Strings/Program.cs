using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString();
            do
            {
                //Console.Clear();
                Console.Write("Please enter a new string: ");
                myString.String = Console.ReadLine();
                Console.WriteLine("Amount of words in the string = {0} ", myString.NumberOfWords);
                myString.ReverseString();
                Console.WriteLine("Reversed string = {0} ", myString.ArrayOfWords);
                myString.SortString();
                Console.WriteLine("Sorted string = {0} ", myString.ArrayOfWords);
            }
            while (myString.String != string.Empty);
        }
    }
}
