using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Ellipse ell1 = new Ellipse(2, 4, ConsoleColor.Blue);
            Ellipse ell2 = new Ellipse(2, 18);
            Ellipse ell3 = new Ellipse(2, 29);
            Circle circle = new Circle(2, ConsoleColor.Red);
            Rectangle rectangle = new Rectangle(2, 4, ConsoleColor.Yellow);
            ShapeManager shapeManager = new ShapeManager();
            shapeManager.Add(ell1);
            shapeManager.Add(circle);
            shapeManager.Add(ell2);
            shapeManager.Add(rectangle);
            shapeManager.Add(ell3);
            Console.WriteLine("count = {0}", shapeManager.Count);
            Console.WriteLine("======= index 3 ====== ");
            shapeManager[2].Display();
            Console.WriteLine("======================");
            shapeManager.DisplayAll();

            Console.WriteLine(Environment.NewLine);
            StringBuilder file = new StringBuilder();
            shapeManager.Save(file);
            Console.WriteLine(file.ToString());

            try
            {
                Console.WriteLine(Environment.NewLine);
                ell1.Display();
                ell2.Display();
                if (ell1.CompareTo(ell2) > 0)
                {
                    Console.WriteLine("ellipse 1 Bigger than ellipse 2");
                }
                else
                {
                    Console.WriteLine("ellipse 2 Bigger than ellipse 1");
                }
            }
            catch
            {
                Console.WriteLine("Can not compare!!!!!!!");
            }

            try
            {
                Console.WriteLine(Environment.NewLine);
                ell1.Display();
                rectangle.Display();
                if (ell1.CompareTo(rectangle) > 0)
                {
                    Console.WriteLine("ellipse 1 Bigger than rectangle");
                }
                else
                {
                    Console.WriteLine("rectangle Bigger than ellipse 1");
                }
            }
            catch
            {
                Console.WriteLine("Can not compare!!!!!!!");
            }

            Console.ReadKey();
        }
    }
}
