using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetCallingAssembly();
            Assembly mscorlib = typeof(string).Assembly;

            Type[] types  = mscorlib.GetTypes();
            var query = from type in types
                        where type.IsInterface
                        orderby type.Name
                        select new
                        {
                            Name = type.Name,
                            numOfMethods = type.GetMethods().GetLength(0)
                        };

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.numOfMethods);
            }

            //b
            var query2 = from p in Process.GetProcesses()
                         where p.Threads.Count < 5 
                         orderby p.Id
                         select new
                         {
                             Name = p.ProcessName,
                             ID = p.Id,
                             StartTime = p.MyStartTime(),
                             BasePriority = p.BasePriority
                         };

            Console.WriteLine("========================================================");
            foreach (var p in query2)
            {
                Console.WriteLine(
@"Name = {0}, Id = {1}, Start Time= {2}",p.Name, p.ID, p.StartTime);
            }

            //c
            var query3 = from p in query2
                         group p by p.BasePriority;

            int numberOfProccesses = (from p in Process.GetProcesses()
                                      select p.Threads.Count).Sum();
            Console.WriteLine("========================================================");
            Console.WriteLine(numberOfProccesses);

            Man man = new Man();
            man.Name = "Israel";

            Man man2 = new Man();
            man2.Name = "Dan";

            man2.CopyTo(man);
            Console.WriteLine(man.Name);

            Console.ReadLine();
        }
    }

    public static class MyExtension
    {
        public static DateTime MyStartTime(this Process p)
        {
            try
            {
                return p.StartTime;
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static void CopyTo(this object copyFrom, object copyTo)
        {
            var properties = copyFrom.GetType().GetProperties();
            var query = from prop in properties
                        where prop.CanRead
                        select prop;

            foreach (var prop in query)
            {
                if (copyTo.GetType().GetProperty(prop.Name) != null)
                {
                    if(copyTo.GetType().GetProperty(prop.Name).CanWrite)
                    {
                        copyTo.GetType().GetProperty(prop.Name).SetValue(
                            copyTo, prop.GetValue(copyFrom));
                    }
                }
            }
        }
    }
}
