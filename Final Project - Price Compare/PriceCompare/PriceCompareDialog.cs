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
    public partial class PriceCompareDialog : Form, IFoldersHendler, IXmlParse
    {
        private ToolTip _toolTip = new ToolTip();

        public PriceCompareDialog()
        {
            InitializeComponent();
            var chainNames = GetListOfDirectoriesFromCurrentDirectory();
            _toolTip.SetToolTip(_shoppingCart, "Select item to delete");
            _cBox1Chain.Items.AddRange(chainNames.ToArray<object>());
            _cBox2Chain.Items.AddRange(chainNames.ToArray<object>());
            _cBox3Chain.Items.AddRange(chainNames.ToArray<object>());
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

        private void _cBox1Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            AddStoreNamesToCBox((string)sendr.SelectedItem, _cBoxStores1);
        }

        private void _cBox2Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            AddStoreNamesToCBox((string)sendr.SelectedItem, _cBoxStores2);
        }

        private void _cBox3Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            AddStoreNamesToCBox((string)sendr.SelectedItem, _cBoxStores3);
        }

        private void _items_SelectedIndexChanged(object sender, EventArgs e)
        {
            _shoppingCart.Items.Add((sender as ComboBox).SelectedItem);
        }

        private void _shoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            (sender as ComboBox).Items.Remove((sender as ComboBox).SelectedItem);
        }
    }
}
