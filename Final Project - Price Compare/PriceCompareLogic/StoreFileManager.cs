using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriceCompareLogic
{
    public class StoreFileManager : IReportable, IDirectoryHendler, IXmlParse
    {
        public string FullReport(Dictionary<string, double> itemsAndPrices,
    Dictionary<string, double> itemsAndQuantities)
        {
            var report = new StringBuilder();
            double sum = 0;

            foreach (var item in itemsAndPrices)
            {
                report.AppendFormat(@"{0} = {1} x{2}{3}",
                    item.Value * itemsAndQuantities[item.Key], item.Key,
                    itemsAndQuantities[item.Key], Environment.NewLine);
                sum += item.Value * itemsAndQuantities[item.Key];
            }

            report.Insert(0, $"Total = {sum}{Environment.NewLine}{Environment.NewLine}");
            return report.ToString();
        }

        public FileInfo[] GetFileInfo(string dirPath, string partialFileName)
        {
            var directoryInWhichToSearch = new DirectoryInfo(dirPath);
            FileInfo[] filesInDir = directoryInWhichToSearch.GetFiles($"*{partialFileName}*.*", SearchOption.AllDirectories);

            return filesInDir;
        }

        public List<string> GetListOfDirectoriesFromCurrentDirectory()
        {
            List<string> chainNames = new List<string>();
            FileInfo[] filesInDir = GetFileInfo(Directory.GetCurrentDirectory(), "Stores");
            foreach (FileInfo foundFile in filesInDir)
            {
                chainNames.Add(foundFile.Directory.Name);
            }

            return chainNames;
        }

        public List<string> GetListOfElementsFromXml(string xmlFullPath, string descendants, string elementName)
        {
            var XElementDoc = XElement.Load(xmlFullPath);
            var listOfElements = (from element
                              in XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, descendants,
                               StringComparison.OrdinalIgnoreCase) == 0)
                                  select (string)element
                                 .Element(elementName))
                              .ToList();

            return listOfElements;
        }

        public string GetStoreFullPath(string dirName, string storeName)
        {
            FileInfo[] fileInfo = GetFileInfo(dirName, "Stores");
            var XElementDoc = XElement.Load(fileInfo[0].FullName);
            string fileFullPath = string.Empty;
            var storeId = (from element in (XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, "Store",
                               StringComparison.OrdinalIgnoreCase) == 0))
                           where (string)element.Element("StoreName") == storeName
                           select (string)element.Element("StoreId"))
                              .ToList().First();
            var storeIdInFormOf3Digits = string.Format("{0:000}", int.Parse(storeId));


            FileInfo[] files = GetFileInfo(dirName, $"Price*Full*-{storeIdInFormOf3Digits}-");
            fileFullPath = files[0].FullName;

            return fileFullPath;
        }

        public Dictionary<string, double> GetItemsPrice(string dirName, string storeName, List<string> items)
        {
            var itemsNameAndPrice = new Dictionary<string, double>();
            double price = 0;
            var uri = GetStoreFullPath(dirName, storeName);

            if (uri != string.Empty)
            {
                var XElementDoc = XElement.Load(uri);
                foreach (var itemName in items)
                {
                    price = (from element in XElementDoc.Descendants()
                                 .Where(el => string.Compare(el.Name.LocalName, "Item",
                                  StringComparison.OrdinalIgnoreCase) == 0)
                             where (string)element.Element("ItemName") == itemName
                             select (double)element.Element("ItemPrice")).FirstOrDefault();
                    itemsNameAndPrice.Add(itemName, price);
                }
            }

            return itemsNameAndPrice;
        }
    }
}
