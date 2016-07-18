using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Xml xml = new Xml();
            foreach (var str in xml.ListOfTypesWithNoProp())
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(
                $"Amount of methods not inherited = {xml.AmountOfMethodsNotInherited()}");
            Console.WriteLine($"Amount of properties = {xml.PropertiesAmount()}");
            Console.WriteLine($"Common parameter { xml.CommonParameter()}");

            foreach (var str in xml.NumberOfMethodsAndProperties())
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}
