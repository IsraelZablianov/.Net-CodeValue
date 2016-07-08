using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            Console.WriteLine(InvokeHello(a, "Israel"));
            Console.WriteLine(InvokeHello(b, "Israel"));
            Console.WriteLine(InvokeHello(c, "Israel"));

            Console.ReadKey();
        }

        public static string InvokeHello(object arg, String msg)
        {
            string returnedString = string.Empty;
            if(arg != null && msg != null)
            {
                Type typeOfArg = arg.GetType();
                MethodInfo[] methods = typeOfArg.GetMethods();
                foreach (var method in methods)
                {
                    if (method.Name == "Hello")
                    {
                        returnedString = (string)method.Invoke(arg, new object[] { msg });
                    }
                }
            } 
            else
            {
                returnedString = "Wrong Input!!!!!!";
            }

            return returnedString;
        }
    }
}
