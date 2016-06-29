using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

/// <summary>
/// I will use genercis collection 
/// as Stas.s told us to.
/// </summary>
namespace ShapesApp
{
    class ShapeManager
    {
        private List<Shape> m_Shapes;
        public ShapeManager()
        {
            m_Shapes = new List<Shape>();
        }

        public void Add(Shape i_Shape)
        {
            m_Shapes.Add(i_Shape);
        }

        public void DisplayAll()
        {
            foreach (var shape in m_Shapes)
            {
                if (shape != null)
                {
                    shape.Display();
                    Console.Write("Area: {0}{1}", shape.Area, Environment.NewLine);
                }
            }
        }

        public Shape this[int i]
        {
            get
            {
                return m_Shapes[i];
            }
        }

        public int Count
        {
            get
            {
                return m_Shapes.Count;
            }
        }

        public void Save(StringBuilder i_FileDemo)
        {
            foreach (var shape in m_Shapes)
            {
                if (shape is IPersist)
                {
                    ((IPersist)shape).Write(i_FileDemo);
                }
            }
        }
    }
}
