using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(int i_Radius)
            : base(i_Radius, i_Radius)
        { }

        public Circle(int i_Radius, ConsoleColor i_Color)
            : base(i_Radius, i_Radius, i_Color)
        { }

        public override void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(
@"Radius: {0}", Radius1);
        }
    }
}
