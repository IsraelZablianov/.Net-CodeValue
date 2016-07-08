using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    public sealed class CodeReviewAttribute : Attribute
    {
        public CodeReviewAttribute(string name, string date, bool approved)
        {
            Name = name;
            Date = date;
            Approved = approved;
        }

        public string Name { get; set; }
        public string Date { get; set; }
        public bool Approved { get; set; }
    }
}
