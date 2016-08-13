using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCompare
{
    public interface IFoldersHendler
    {
        List<string> GetListOfDirectoriesFromCurrentDirectory();
        FileInfo[] GetFileInfo(string dirName, string partialFileName);
    }
}
