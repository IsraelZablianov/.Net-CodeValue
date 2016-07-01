using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        private int m_Radius1;
        private int m_Radius2;
        private const double k_Pai = 3.14;

        public Ellipse(int i_Radius1, int i_Radius2)
            : base()
        {
            m_Radius1 = i_Radius1;
            m_Radius2 = i_Radius2;
        }

        public Ellipse(int i_Radius1, int i_Radius2, ConsoleColor i_Color)
            : base(i_Color)
        {
            m_Radius1 = i_Radius1;
            m_Radius2 = i_Radius2;
        }

        public int Radius1
        {
            get
            {
                return m_Radius1;
            }
            set
            {
                m_Radius1 = value;
            }
        }

        public int Radius2
        {
            get
            {
                return m_Radius2;
            }
            set
            {
                m_Radius2 = value;
            }
        }

        public override double Area
        {
            get
            {
                return k_Pai * m_Radius1 * m_Radius2;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine(
@"Radius 1: {0}
Radius 2: {1}", m_Radius1, m_Radius2);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(string.Format("Radius 1 = {0}, Radius 2 = {1}", m_Radius1, m_Radius2));
        }

        public int CompareTo(object obj)
        {
            Ellipse ellipse = obj as Ellipse;
            if (ellipse == null)
            {
                throw new InvalidCastException();
            }
            else
            {
                int ans = 0;
                if (Area > ellipse.Area)
                {
                    ans = 1;
                }
                else if (Area < ellipse.Area)
                {
                    ans = -1;
                }

                return ans;
            }
        }
    }
}
