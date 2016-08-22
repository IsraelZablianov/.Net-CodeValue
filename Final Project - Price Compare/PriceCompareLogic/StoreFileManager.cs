﻿using System;
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
        public string FullReport(DatabaseOfItem databaseOfItem)
        {
            var report = new StringBuilder();
            double sum = 0;

            foreach (var item in databaseOfItem.ItemsAndPrices)
            {
                report.AppendFormat(@"{0} = {1} x{2}{3}",
                    item.Value * databaseOfItem.ItemsAndQuantities[item.Key], item.Key,
                    databaseOfItem.ItemsAndQuantities[item.Key], 
                    Environment.NewLine);
                sum += item.Value * databaseOfItem.ItemsAndQuantities[item.Key];
            }

            report.Insert(0, $"Total = {sum}{Environment.NewLine}{Environment.NewLine}");
            return report.ToString();
        }

        public FileInfo[] GetFileInfo(FileIdentifiers fileIdentifiers)
        {
            var directoryInWhichToSearch = new DirectoryInfo(fileIdentifiers.DirName);
            FileInfo[] filesInDir = directoryInWhichToSearch.GetFiles($"*{fileIdentifiers.PartialFileName}*.*", SearchOption.AllDirectories);

            return filesInDir;
        }

        public List<string> GetDirectories()
        {
            List<string> chainNames = new List<string>();
            var fileIdentifiers = new FileIdentifiers(){
                DirName = Directory.GetCurrentDirectory(),
                PartialFileName = "Stores"};
            FileInfo[] filesInDir = GetFileInfo(fileIdentifiers);
            foreach (FileInfo foundFile in filesInDir)
            {
                chainNames.Add(foundFile.Directory.Name);
            }

            return chainNames;
        }

        public List<string> GetListOfElementsFromXml(XmlElementId xmlElementId)
        {
            var XElementDoc = XElement.Load(xmlElementId.XmlFullPath);
            var listOfElements = (from element
                              in XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, xmlElementId.DescendantFrom,
                               StringComparison.OrdinalIgnoreCase) == 0)
                                  select (string)element
                                 .Element(xmlElementId.ElementName))
                              .ToList();

            return listOfElements;
        }

        public string GetStoreFullPath(FileIdentifiers fileIdentifiers)
        {
            var storeFileIdentifier = new FileIdentifiers() {
                DirName = fileIdentifiers.DirName,
                PartialFileName = "Stores"};
            FileInfo[] fileInfo = GetFileInfo(storeFileIdentifier);
            var XElementDoc = XElement.Load(fileInfo[0].FullName);
            string fileFullPath = string.Empty;
            var storeId = (from element in (XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, "Store",
                               StringComparison.OrdinalIgnoreCase) == 0))
                           where (string)element.Element("StoreName") == fileIdentifiers.PartialFileName
                           select (string)element.Element("StoreId"))
                              .ToList().First();
            var storeIdInFormOf3Digits = string.Format("{0:000}", int.Parse(storeId));

            storeFileIdentifier.PartialFileName = $"Price*Full*-{storeIdInFormOf3Digits}-";
            FileInfo[] files = GetFileInfo(storeFileIdentifier);
            fileFullPath = files[0].FullName;

            return fileFullPath;
        }

        public Dictionary<string, double> GetItemsPrice(FileIdentifiers fileIdentifiers, List<string> items)
        {
            var itemsNameAndPrice = new Dictionary<string, double>();
            double price = 0;
            var uri = GetStoreFullPath(fileIdentifiers);

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
