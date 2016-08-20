using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PriceCompare
{
    public partial class PriceCompareDialog : Form, IFolderHendler, IXmlParse
    {
        private ToolTip _toolTip = new ToolTip();
        private Dictionary<string, double> _itemQuantities = new Dictionary<string, double>();

        public PriceCompareDialog()
        {
            InitializeComponent();
            var chainNames = GetListOfDirectoriesFromCurrentDirectory();
            _toolTip.SetToolTip(_checkBoxToRemoveItem, "Check and select the item to change the quantity of the product.");
            _toolTip.SetToolTip(_checkBoxSelectStoresToCompare, "Check and select the branch to add to the  comperison list.");
            _cBoxChain.Items.AddRange(chainNames.ToArray<object>());
        }

        public List<string> GetListOfDirectoriesFromCurrentDirectory()
        {
            FileInfo[] filesInDir = GetFileInfo(string.Empty, "Stores");
            List<string> chainNames = new List<string>();

            foreach (FileInfo foundFile in filesInDir)
            {
                chainNames.Add(foundFile.Directory.Name);
            }

            return chainNames;
        }

        public List<string> GetListOfItemsFromXml(string xmlFullPath, string descendants, string elementName)
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

        public FileInfo[] GetFileInfo(string dirName, string partialFileName)
        {
            var dirPath = Directory.GetCurrentDirectory();
            dirPath = Path.Combine(dirPath, dirName);
            var directoryInWhichToSearch = new DirectoryInfo(dirPath);
            FileInfo[] filesInDir = directoryInWhichToSearch.GetFiles($"*{partialFileName}*.*", SearchOption.AllDirectories);

            return filesInDir;
        }

        public Dictionary<string, double> GetItemPrices(string dirName, string storeName, List<string> items)
        {
            var itemPrices = new Dictionary<string, double>();
            double price = 0;
            var uri = GetStoreFullPath(dirName, storeName);
            XElement XElementDoc = null;

            if (uri != string.Empty)
            {
                XElementDoc = XElement.Load(uri);
            
                foreach (var itemName in items)
                {
                    price = (from element in XElementDoc.Descendants()
                                 .Where(el => string.Compare(el.Name.LocalName, "Item",
                                  StringComparison.OrdinalIgnoreCase) == 0)
                                  where (string)element.Element("ItemName") == itemName
                                  select (double)element.Element("ItemPrice")).FirstOrDefault();
                    itemPrices.Add(itemName, price);
                }
            }

            return itemPrices;
        }

        private string GetStoreFullPath(string dirName, string storeName)
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

            try
            {
                FileInfo[] files = GetFileInfo(dirName, $"Price*Full*-{storeIdInFormOf3Digits}-");
                fileFullPath = files[0].FullName;
            }
            catch (IndexOutOfRangeException ex)
            {
                File.WriteAllText(@"LogFiles\LoadingNamesFromFilesLog.txt",
                    $"StackTrace = {ex.StackTrace}, Message = { ex.Message} didnt find the file price of store");
            }

            return fileFullPath;
        }

        private void AddStoreNamesToCBox(string dirName, ComboBox cBoxStoreNames)
        {
            FileInfo[] filesInDir = GetFileInfo(dirName, "Stores");
            var storesFilePath = filesInDir[0].FullName;
            var storeNames = GetListOfItemsFromXml(storesFilePath, "Store", "StoreName");
            cBoxStoreNames.Items.Clear();

            try
            {
                cBoxStoreNames.Items.AddRange(storeNames.ToArray<object>());
            }
            catch (ArgumentNullException ex)
            {
                File.WriteAllText(@"LogFiles\LoadingNamesFromFilesLog.txt",
                    $"StackTrace = {ex.StackTrace}, Message = { ex.Message} apperntly there is no element as StoreName");
            }
        }

        private async void AddProductItemsToCBox(string dirName, string storeName)
        {
            var items = new Dictionary<string, object>();
            var fileName = GetStoreFullPath(dirName, storeName);
            _items.Items.Clear();

            await Task.Run(() =>
            {
                var listOfItems = GetListOfItemsFromXml(fileName, "Item", "ItemName");
                foreach (var item in listOfItems)
                {
                    if (!items.ContainsKey(item))
                    {
                        items.Add(item, null);
                    }
                }
            });

            _items.Items.AddRange(items.Keys.ToArray<object>());
        }

        private void CBoxChains_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                AddStoreNamesToCBox(((string)(sender as ComboBox).SelectedItem), _cBoxStores);
            }
        }

        private void Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!_shoppingCart.Items.Contains((sender as ComboBox).SelectedItem) && (sender as ComboBox).SelectedItem!= null)
            {
                _shoppingCart.Items.Add((sender as ComboBox).SelectedItem);
                _itemQuantities.Add(((string)(sender as ComboBox).SelectedItem), 1);
            }
        }

        private void ShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (sender as ComboBox).SelectedItem;
            if ((sender as ComboBox).SelectedItem != null)
            {
                if (_checkBoxToRemoveItem.Checked)
                {
                    var quantitySelection = new QuantitySelectionForm();
                    quantitySelection.ShowForm();
                    if (quantitySelection.IsOkButtonPressed)
                    {
                        _itemQuantities[((string)itemSelected)] = quantitySelection.Amount;
                    }
                }
                else
                {
                    (sender as ComboBox).Items.Remove(itemSelected);
                    _itemQuantities.Remove(((string)itemSelected));
                }
            }
        }

        private void CBoxStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((string)(_cBoxChain.SelectedItem) != null && (string)(sender as ComboBox).SelectedItem != null)
            {
                AddProductItemsToCBox((string)(_cBoxChain.SelectedItem), (string)(sender as ComboBox).SelectedItem);
                var selectedBranch = $"{(string)(_cBoxChain.SelectedItem)}-{(string)(sender as ComboBox).SelectedItem}";
                if (_checkBoxSelectStoresToCompare.Checked && !_cBoxStoresToCompare.Items.Contains(selectedBranch))
                {
                    _cBoxStoresToCompare.Items.Add(selectedBranch);
                }
            }
            else
            {
                ShowWarning("Please select 1 chain and 1 branch");
            }
        }

        private void CBoxStoresToCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((sender as ComboBox).SelectedItem != null)
            {
                _cBoxStoresToCompare.Items.Remove((string)(sender as ComboBox).SelectedItem);
            }
        }

        private void Compare_Click(object sender, EventArgs e)
        {
            if (_shoppingCart.Items.Count == 0)
            {
                ShowWarning("Please select items to compare");
            }
            else if (_cBoxStores.SelectedItem == null || _cBoxChain.SelectedItem == null)
            {
                ShowWarning("Please select at list 1 chain and 1 branch");
            }
            else
            {
                var report = new Dictionary<string, string>();
                foreach (string chainAndBranchName in _cBoxStoresToCompare.Items)
                {
                    string[] chainAndBranch = chainAndBranchName.Split('-');
                    var itemAndPrices = GetItemPrices(chainAndBranch[0],
                    chainAndBranch[1],
                    _shoppingCart.Items.Cast<string>().ToList())
                    .OrderBy(item => item.Value);

                    report.Add($"{chainAndBranch[0]}-{chainAndBranch[1]}", 
                        FullReport(itemAndPrices.ToDictionary(pair => pair.Key, pair => pair.Value),
                        _itemQuantities));
                }

                var reportForm = new Report(report);
                reportForm.Show();
                //reportForm.ShowDialog();
            }
        }

        private string FullReport(Dictionary<string, double> itemsAndPrices, 
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

        private void ShowWarning(string warningMsg)
        {
            MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
