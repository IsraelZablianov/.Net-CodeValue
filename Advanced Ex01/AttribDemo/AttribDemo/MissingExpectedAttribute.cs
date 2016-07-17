using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public class MissingExpectedAttributeException : Exception
    {
        public MissingExpectedAttributeException()
            : base("Missing expected attribute")
        { }
    }
}
