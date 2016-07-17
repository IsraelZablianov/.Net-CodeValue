using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class HelperClass
    {
        public List<string> ReadFileToListOfStrings(string name)
        {
            List<string> fileData = null;
            if (File.Exists(name))
            {
                fileData = new List<string>();
                FileStream fileStream = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                while (streamReader.EndOfStream == false)
                {
                    fileData.Add(streamReader.ReadLine());
                }
                fileStream.Close();
                streamReader.Close();
            }

            return fileData;
        }

    }
}
