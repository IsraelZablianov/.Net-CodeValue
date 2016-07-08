using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Analayze analayze = new Analayze();

            try
            {
                Console.WriteLine($"All approved? {analayze.AnalayzeAssembly(Assembly.GetExecutingAssembly())}");
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MissingExpectedAttribute e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine($"All approved? {analayze.AnalayzeAssembly(Assembly.GetAssembly(typeof(DateTime)))}");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Do not forget null!!");
            }
            catch (MissingExpectedAttribute e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
