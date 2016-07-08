using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Analayze
    {
        public bool AnalayzeAssembly(Assembly assembly)
        {
            bool allReviewd = true;
            bool hasAtLeastOneCodeReviewAttribute = false;
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                Attribute[] attributes = Attribute.GetCustomAttributes(type, typeof(CodeReviewAttribute));
                foreach (var attribute in attributes)
                {
                    CodeReviewAttribute custumAttribute = attribute as CodeReviewAttribute;
                    if (custumAttribute != null)
                    {
                        hasAtLeastOneCodeReviewAttribute = true;
                        Console.WriteLine($"Name: {custumAttribute.Name}");
                        Console.WriteLine($"Date: {custumAttribute.Date}");
                        Console.WriteLine($"Approved: {custumAttribute.Approved}");
                        if (custumAttribute.Approved == false)
                        {
                            allReviewd = false;
                        }
                    }
                }
            }

            if(!hasAtLeastOneCodeReviewAttribute)
            {
                throw new MissingExpectedAttribute();
            }

            return allReviewd;
        }
    }
}
