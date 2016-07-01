using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational Rational_1 = new Rational(56, 64);
            Rational Rational_3 = new Rational(12, 4);
            Rational Rational_4 = new Rational(1, 4);

            Rational rationalAnswer = Rational_3.Add(Rational_4);
            Console.WriteLine(
@"the sum of {0} + {1} = {2}"
, Rational_3.ToString(), Rational_4.ToString(), rationalAnswer.ToString());

            rationalAnswer = Rational_3.mul(Rational_4);
            Console.WriteLine(
@"the mul of {0} * {1} = {2}"
, Rational_3.ToString(), Rational_4.ToString(), rationalAnswer.ToString());

            Console.WriteLine("Some rational number before reducing = {0}",Rational_1.ToString());
            Rational_1.Reduce();
            Console.WriteLine("After reducing = {0}", Rational_1.ToString());
        }
    }
}
