using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        public static void Main(string []args)
        {
            Rational Rational1 = new Rational(56, 64);
            Rational Rational3 = new Rational(12, 4);
            Rational Rational4 = new Rational(1, 4);

            Rational rationalAnswer = Rational3 + Rational4;
            Console.WriteLine(
@"the sum of {0} + {1} = {2}"
    , Rational3.ToString(), Rational4.ToString(), rationalAnswer.ToString());

            rationalAnswer = Rational3 * Rational4;
            Console.WriteLine(
@"the Mul of {0} * {1} = {2}"
, Rational3.ToString(), Rational4.ToString(), rationalAnswer.ToString());

            rationalAnswer = Rational3 / Rational4;
            Console.WriteLine(
@"the division of {0} * {1} = {2}"
, Rational3.ToString(), Rational4.ToString(), rationalAnswer.ToString());

            rationalAnswer = Rational3 - Rational4;
            Console.WriteLine(
@"the Subtraction of {0} * {1} = {2}"
, Rational3.ToString(), Rational4.ToString(), rationalAnswer.ToString());

            rationalAnswer = 15;
            Console.WriteLine(
@"The code is: rationalAnswer = 15;
and the result of it is: rationalAnswer = {0}"
, rationalAnswer.RationalAsDouble);

            double rational = (double)rationalAnswer;
            Console.WriteLine(
@"The code is: double rational = (double)rationalAnswer;
and the result of it is: rational = {0}"
, rational);

            Console.ReadKey();
        }
    }
}
