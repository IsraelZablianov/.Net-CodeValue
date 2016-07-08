using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class MissingExpectedAttribute : Exception
    {
        public MissingExpectedAttribute()
            : base("Missing expected attribute")
        { }
    }
}
