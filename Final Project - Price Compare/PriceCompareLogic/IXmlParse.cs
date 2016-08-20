using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareLogic
{
    interface IXmlParse
    {
        List<string> GetListOfElementsFromXml(string xmlFullPath, string descendants, string elementName);
    }
}
