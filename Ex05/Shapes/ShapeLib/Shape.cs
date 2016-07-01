using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{

    public abstract class Shape
    {
        private ConsoleColor m_Color;
        private double m_Area;
        public Shape()
        {
            m_Color = ConsoleColor.White;
        }

        public Shape(ConsoleColor i_Color)
        {
            m_Color = i_Color;
        }

        public ConsoleColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }        

        public abstract double Area
        {
            get;
        }

        public virtual void Display()
        {
            Console.ForegroundColor = m_Color;
        }
    }
}
