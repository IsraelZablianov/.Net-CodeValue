using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareLogic
{
    interface IDirectoryHendler
    {
        List<string> GetListOfDirectoriesFromCurrentDirectory();
        FileInfo[] GetFileInfo(string dirName, string partialFileName);
    }
}
