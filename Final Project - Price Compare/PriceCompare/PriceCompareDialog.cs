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
        private Dictionary<string, double> _itemsAmount = new Dictionary<string, double>();
        private QuantitySelectionForm _quantitySelection = new QuantitySelectionForm();

        public PriceCompareDialog()
        {
            InitializeComponent();
            var chainNames = GetListOfDirectoriesFromCurrentDirectory();
            _toolTip.SetToolTip(_checkBoxToRemoveItem, "To delete item from the shoping cart check and select the item.");
            _cBox1Chain.Items.AddRange(chainNames.ToArray<object>());
            _cBox2Chain.Items.AddRange(chainNames.ToArray<object>());
            _cBox3Chain.Items.AddRange(chainNames.ToArray<object>());
            //for pilot adding all items of every store of "חצי חינם"
            AddProductItemsToCBox("חצי חינם");
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

        private async void AddProductItemsToCBox(string dirName)
        {
            var items = new Dictionary<string, object>();
            FileInfo[] filesOfFullPrice =  GetFileInfo(dirName, "PriceFull");
            List<string> listOfItems = null;
            await Task.Run(() =>
            {
                foreach (var file in filesOfFullPrice)
                {
                    listOfItems = GetListOfItemsFromXml(file.FullName, "Item", "ItemName");
                    foreach (var item in listOfItems)
                    {
                        if (!items.ContainsKey(item))
                        {
                            items.Add(item, null);
                        }
                    }
                }
            });

            _items.Items.AddRange(items.Keys.ToArray<object>());
        }

        private void CBox1Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                AddStoreNamesToCBox(((string)(sender as ComboBox).SelectedItem), _cBoxStores1);
            }
        }

        private void CBox2Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                AddStoreNamesToCBox(((string)(sender as ComboBox).SelectedItem), _cBoxStores2);
            }
        }

        private void CBox3Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((sender as ComboBox).SelectedItem != null)
            {
                AddStoreNamesToCBox(((string)(sender as ComboBox).SelectedItem), _cBoxStores3);
            }
        }

        private void Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!_shoppingCart.Items.Contains((sender as ComboBox).SelectedItem) && (sender as ComboBox).SelectedItem!= null)
            {
                _shoppingCart.Items.Add((sender as ComboBox).SelectedItem);
                _itemsAmount.Add(((string)(sender as ComboBox).SelectedItem), 1);
            }
        }

        private void ShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelected = (sender as ComboBox).SelectedItem;
            if ((sender as ComboBox).SelectedItem != null)
            {
                if (_checkBoxToRemoveItem.Checked)
                {
                    (sender as ComboBox).Items.Remove(itemSelected);
                    _itemsAmount.Remove(((string)itemSelected));
                }
                else
                {
                    _quantitySelection = new QuantitySelectionForm();
                    _quantitySelection.ShowForm();
                    if (_quantitySelection.IsOkButtonPressed)
                    {
                        _itemsAmount[((string)itemSelected)] = _quantitySelection.Amount;
                    }
                }
            }
        }

        private void Compare_Click(object sender, EventArgs e)
        {
            if (_shoppingCart.Items.Count == 0)
            {
                ShowWarning("Please select items to compare");
            }
            else if (_cBoxStores3.SelectedItem == null && _cBoxStores2.SelectedItem == null && _cBoxStores1.SelectedItem == null)
            {
                ShowWarning("Please select at list 1 store");
            }

            var data1 = new StringBuilder();
            var items1 = GetItemPrices((string)_cBox1Chain.SelectedItem,
                (string)_cBoxStores1.SelectedItem,
                _shoppingCart.Items.Cast<string>().ToList())
                .OrderBy(item => item.Value);


            data1.AppendLine($"{(string)_cBox1Chain.SelectedItem} - {(string)_cBoxStores1.SelectedItem}");

            foreach (var item in items1)
            {
                data1.AppendFormat(@"{1} = {0}{2}",
                    item.Key, item.Value, Environment.NewLine);
            }

            MessageBox.Show(data1.ToString());
        }

        private void ShowWarning(string warningMsg)
        {
            MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void TemporeryCompare()
        {
            var data1 = new StringBuilder();
            var items1 = GetItemPrices((string)_cBox1Chain.SelectedItem,
                (string)_cBoxStores1.SelectedItem,
                _shoppingCart.Items.Cast<string>().ToList());

            data1.AppendLine($"{(string)_cBox1Chain.SelectedItem} - {(string)_cBoxStores1.SelectedItem}");
            foreach (var item in items1)
            {
                data1.AppendFormat(@"{1} = {0}{2}",
                    item.Key, item.Value, Environment.NewLine);
            }

            var data2 = new StringBuilder();
            var items2 = GetItemPrices((string)_cBox2Chain.SelectedItem,
                (string)_cBoxStores2.SelectedItem,
                _shoppingCart.Items.Cast<string>().ToList());

            data2.AppendLine($"{(string)_cBox2Chain.SelectedItem} - {(string)_cBoxStores2.SelectedItem}");
            foreach (var item in items2)
            {
                data2.AppendFormat(@"{1} = {0}{2}",
                    item.Key, item.Value, Environment.NewLine);
            }

            var data3 = new StringBuilder();
            var items3 = GetItemPrices((string)_cBox3Chain.SelectedItem,
                (string)_cBoxStores3.SelectedItem,
                _shoppingCart.Items.Cast<string>().ToList());

            data3.AppendLine($"{(string)_cBox3Chain.SelectedItem} - {(string)_cBoxStores3.SelectedItem}");
            foreach (var item in items3)
            {
                data3.AppendFormat(@"{1} = {0}{2}",
                    item.Key, item.Value, Environment.NewLine);
            }

            data1.AppendLine();
            data1.AppendLine(data2.ToString());
            data1.AppendLine(data3.ToString());
            MessageBox.Show(data1.ToString());
        }
    }
}
