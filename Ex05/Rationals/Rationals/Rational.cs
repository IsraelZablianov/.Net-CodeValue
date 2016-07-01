using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public struct Rational
    {
        private int _Denominator;
        private int _Numerator;

        public Rational(int numerator, int denominator)
        {
            _Denominator = denominator;
            _Numerator = numerator;
            CheckDenominatorForZero(denominator);
        }

        private void CheckDenominatorForZero(int valueOfDenominator)
        {
            if (valueOfDenominator == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public Rational(int numerator)
        {
            _Denominator = 1;
            _Numerator = numerator;
        }

        public int Numerator
        {
            get
            {
                return _Numerator;
            }
            set
            {
                _Numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return _Denominator;
            }
            set
            {
                _Denominator = value;
                CheckDenominatorForZero(_Denominator);
            }
        }

        public double RationalAsDouble
        {
            get
            {
                return ((double)_Numerator / _Denominator);
            }
        }

        public Rational Add(Rational rational)
        {
            int denominator = (_Denominator * rational.Denominator);
            int numerator = (_Numerator * rational.Denominator) + (rational.Numerator * _Denominator);

            return new Rational(numerator, denominator);
        }

        public Rational Mul(Rational i_Rational)
        {
            int denominator = (_Denominator * i_Rational.Denominator);
            int numerator = (_Numerator * i_Rational.Numerator);

            return new Rational(numerator, denominator);
        }

        //finding the gcd
        //finally => gcd = first.
        //divide numerator and denumerator in first.
        public void Reduce()
        {
            int first = _Numerator;
            int second = _Denominator;
            int temp = 0;

            do
            {
                temp = first % second;
                first = second;
                second = temp;
            }
            while (temp != 0 && RationalAsDouble != 0);

            _Numerator /= first;
            _Denominator /= first;
        }

        public static Rational operator +(Rational first, Rational second)
        {
            return first.Add(second);
        }

        public static Rational operator *(Rational first, Rational second)
        {
            return first.Mul(second);
        }

        public static Rational operator /(Rational first, Rational second)
        {
            Rational r = new Rational(second.Denominator, second.Numerator);
            return first.Mul(r);
        }

        public static Rational operator -(Rational first, Rational second)
        {
            Rational firstRational = new Rational(first.Numerator * second.Denominator, first.Denominator * second.Denominator);
            Rational secondRational = new Rational(second.Numerator * first.Denominator, second.Denominator * first.Denominator);
            firstRational.Numerator -= secondRational.Numerator;

            return firstRational;
        }

        public static explicit operator double (Rational r)
        {
            return r.RationalAsDouble;
        }

        public static implicit operator Rational(int numerator)
        {
            Rational r = new Rational(numerator); 
            return r;
        }

        public override string ToString()
        {
            string toString;
            Reduce();
            if(_Numerator < 0 || _Denominator < 0)
            {
                toString = string.Format("{0}/{1}", Math.Abs(_Numerator) * (-1), Math.Abs(_Denominator));
            }
            else
            {
                toString = string.Format("{0}/{1}", _Numerator, _Denominator);
            }

            return toString;
        }

        public override bool Equals(object obj)
        {
            bool answer = false;
            if (obj is Rational)
            {
                answer = ((Rational)obj).RationalAsDouble == RationalAsDouble;
            }

            return answer;
        }

        public override int GetHashCode()
        {
            string hashCode = RationalAsDouble.ToString();
            return hashCode.GetHashCode();
        }
    }
}
