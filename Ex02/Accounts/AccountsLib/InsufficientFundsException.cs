using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
        : base("Error - Insufficient Funds.")
            {}
    }
}
