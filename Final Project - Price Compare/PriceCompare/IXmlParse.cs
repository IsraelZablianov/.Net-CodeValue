using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare
{
    public interface IXmlParse
    {
        List<string> GetListOfItemsFromXml(string xmlFullPath, string descendants, string elementName);
    }
}
