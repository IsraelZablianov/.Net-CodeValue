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
using PriceCompareLogic;

namespace PriceCompare
{
    public partial class PriceCompareForm : Form
    {
        private ToolTip _toolTip = new ToolTip();
        private Dictionary<string, double> _itemQuantities = new Dictionary<string, double>();
        private StoreFileManager _storeFileManager = new StoreFileManager();

        public PriceCompareForm()
        {
            InitializeComponent();
            var chainNames = _storeFileManager.GetDirectories();
            _toolTip.SetToolTip(_checkBoxToRemoveItem, "Check and select the item to change the quantity of the product.");
            _toolTip.SetToolTip(_checkBoxSelectStoresToCompare, "Check and select the branch to add to the  comperison list.");
            _cBoxChain.Items.AddRange(chainNames.ToArray<object>());
        }

        private void AddStoreNamesToCBox(FileIdentifiers fileIdentifiers, ComboBox cBoxStoreNames)
        {
            FileInfo[] filesInDir = _storeFileManager.GetFileInfo(fileIdentifiers);
            var xmlElementId = new XmlElementId() {
                DescendantFrom = "Store",
                ElementName = "StoreName",
                XmlFullPath = Path.Combine(fileIdentifiers.DirName, filesInDir[0].Name)};
             
            var storeNames = _storeFileManager.GetListOfElementsFromXml(xmlElementId);
            cBoxStoreNames.Items.Clear();
            cBoxStoreNames.Items.AddRange(storeNames.ToArray<object>());
        }

        private async void AddProductItemsToCBox(FileIdentifiers fileIdentifiers)
        {
            var items = new Dictionary<string, object>();
            var xmlElementId = new XmlElementId() {
                XmlFullPath = _storeFileManager.GetStoreFullPath(fileIdentifiers),
                DescendantFrom = "Item",
                ElementName = "ItemName"};

            _items.Items.Clear();

            await Task.Run(() =>
            {
                var listOfItems = _storeFileManager.GetListOfElementsFromXml(xmlElementId);
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
                var fileIdentifiers = new FileIdentifiers() {
                DirName = (string)(sender as ComboBox).SelectedItem,
                PartialFileName = "Stores"};
                AddStoreNamesToCBox(fileIdentifiers, _cBoxStores);
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
                var fileIdentifiers = new FileIdentifiers(){
                    DirName = (string)(_cBoxChain.SelectedItem),
                    PartialFileName = (string)(sender as ComboBox).SelectedItem};
                AddProductItemsToCBox(fileIdentifiers);
                var selectedBranch = $"{fileIdentifiers.DirName}-{fileIdentifiers.PartialFileName}";

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
                    var fileIdentifiers = new FileIdentifiers() {
                        DirName = chainAndBranch[0],
                        PartialFileName = chainAndBranch[1]};
                    var itemAndPrices = _storeFileManager.GetItemsPrice(
                    fileIdentifiers,
                    _shoppingCart.Items.Cast<string>().ToList())
                    .OrderBy(item => item.Value);

                    var databaseOfItem = new DatabaseOfItem(){
                        ItemsAndPrices = itemAndPrices.ToDictionary(pair => pair.Key, pair => pair.Value),
                        ItemsAndQuantities = _itemQuantities};

                    report.Add($"{chainAndBranch[0]}-{chainAndBranch[1]}",
                        _storeFileManager.FullReport(databaseOfItem));
                }

                var reportForm = new Report(report);
                reportForm.Show();
            }
        }

        private void ShowWarning(string warningMsg)
        {
            MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
