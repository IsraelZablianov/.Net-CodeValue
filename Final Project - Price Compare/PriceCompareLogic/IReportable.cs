using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareLogic
{
    interface IReportable
    {
        string FullReport(DatabaseOfItem databaseOfItem);
    }
}
