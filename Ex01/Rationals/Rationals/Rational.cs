using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public struct Rational
    {
        private int m_Denominator;//מכנה
        private int m_Numerator;//מונה

        public Rational(int i_Numerator, int i_Denominator)
        {
            m_Denominator = i_Denominator;
            m_Numerator = i_Numerator;
        }

        public Rational(int i_Numerator)
        {
            m_Denominator = 1;
            m_Numerator = i_Numerator;
        }

        public int Numerator
        {
            get
            {
                return m_Numerator;
            }
            set
            {
                m_Numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return m_Denominator;
            }
            set
            {
                m_Denominator = value;
            }
        }

        public double RationalAsDouble
        {
            get
            {
                return ((double)m_Numerator / m_Denominator);
            }
        }

        public Rational Add(Rational i_Rational)
        {
            int Denominator = (m_Denominator * i_Rational.Denominator);
            int Numerator = (m_Numerator * i_Rational.Denominator) + (i_Rational.Numerator * m_Denominator);

            return new Rational(Numerator, Denominator);
        }

        public Rational mul(Rational i_Rational)
        {
            int Denominator = (m_Denominator * i_Rational.Denominator);
            int Numerator = (m_Numerator * i_Rational.Numerator);

            return new Rational(Numerator, Denominator);
        }

        //finding the gcd
        //in the end ,gcd = first
        //divide numerator and denumerator in first
        public void Reduce()
        {
            int first = m_Numerator;
            int second = m_Denominator;
            int temp = 0;

            do
            {
                temp = first % second;
                first = second;
                second = temp;
            }
            while (temp != 0 && RationalAsDouble != 0);

            m_Numerator /= first;
            m_Denominator /= first;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", m_Numerator, m_Denominator);
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
    }
}
