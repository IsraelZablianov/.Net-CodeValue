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
    public partial class PriceCompareDialog : Form
    {
        private XElement _xDoc1;
        private XElement xDoc2;
        private XElement _xDoc3;
        private List<string> _chainNames = new List<string>();

        public PriceCompareDialog()
        {
            InitializeComponent();
            LoadChainsName();
        }

        private void LoadChainsName()
        {
            FileInfo[] filesInDir = GetStoresFileInfoOfChain(string.Empty);

            foreach (FileInfo foundFile in filesInDir)
            {
                _chainNames.Add(foundFile.Directory.Name);
            }

            _cBox1Chain.Items.AddRange(_chainNames.ToArray<object>());
            _cBox2Chain.Items.AddRange(_chainNames.ToArray<object>());
            _cBox3Chain.Items.AddRange(_chainNames.ToArray<object>());
        }

        private FileInfo[] GetStoresFileInfoOfChain(string chainDirName)
        {
            string partialName = "Store";
            var dirPath = Directory.GetCurrentDirectory();
            dirPath = Path.Combine(dirPath, chainDirName);
            var directoryInWhichToSearch = new DirectoryInfo(dirPath);
            FileInfo[] filesInDir = directoryInWhichToSearch.GetFiles($"*{partialName}*.*", SearchOption.AllDirectories);

            return filesInDir;
        }

        private void LoadStoresName(string path, XElement XElementDoc, ComboBox cBoxStoreNames)
        {
            XElementDoc = XElement.Load(path);
            var storeNames = (from store
                              in XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, "Store",
                               StringComparison.OrdinalIgnoreCase) == 0)
                               select (string)store
                              .Element("StoreName"))
                              .ToArray<object>();

            cBoxStoreNames.Items.Clear();
            cBoxStoreNames.Items.AddRange(storeNames);
        }

        private void _cBox1Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            FileInfo[] filesInDir = GetStoresFileInfoOfChain((string)sendr.SelectedItem);
            LoadStoresName(filesInDir[0].FullName, _xDoc1, _cBoxStores1);
        }

        private void _cBox2Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            FileInfo[] filesInDir = GetStoresFileInfoOfChain((string)sendr.SelectedItem);
            LoadStoresName(filesInDir[0].FullName, xDoc2, _cBoxStores2);
        }

        private void _cBox3Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            FileInfo[] filesInDir = GetStoresFileInfoOfChain((string)sendr.SelectedItem);
            LoadStoresName(filesInDir[0].FullName, _xDoc3, _cBoxStores3);
        }
    }
}
