using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCompare
{
    public interface IChainHendler
    {
        List<string> GetListOfChains();
        List<string> GetListOfStores(string chainDirName);
        FileInfo[] GetFileInfo(string chainDirName, string partialFileName);
    }
}
