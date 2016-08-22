using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareLogic
{
    public class DatabaseOfItem
    {
        public Dictionary<string, double> ItemsAndPrices
        {
            get;
            set;
        }

        public Dictionary<string, double> ItemsAndQuantities
        {
            get;
            set;
        }
    }
}
