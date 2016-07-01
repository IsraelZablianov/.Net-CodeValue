using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape, IPersist, IComparable
    {
        private int m_width;
        private int m_Height;
        public Rectangle(int i_Width, int i_Height)
            : base()
        {
            m_width = i_Width;
            m_Height = i_Height;
        }

        public Rectangle(int i_Width, int i_Height, ConsoleColor i_Color)
            : base(i_Color)
        {
            m_width = i_Width;
            m_Height = i_Height;
        }

        public int width
        {
            get
            {
                return m_width;
            }
            set
            {
                m_width = value;
            }
        }

        public int Height
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        public override double Area
        {
            get
            {
                return m_width * m_Height;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine(
@"Width: {0}
Height: {1}", m_width, m_Height);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine(string.Format("width = {0}, height = {1}",m_width, m_Height));
        }

        public int CompareTo(object obj)
        {
            Rectangle rectangle = obj as Rectangle;
            if (rectangle == null)
            {
                throw new InvalidCastException();
            }
            else
            {
                int ans = 0;
                if(Area > rectangle.Area)
                {
                    ans = 1;
                }
                else if (Area < rectangle.Area)
                {
                    ans = -1;
                }

                return ans;
            }
        }
    }
}
