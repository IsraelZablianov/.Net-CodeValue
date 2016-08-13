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
        private List<string> _chainNames = new List<string>();

        public PriceCompareDialog()
        {
            InitializeComponent();
            LoadChainNames();
        }

        private void LoadChainNames()
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

        private void LoadStoreNamesOfChain(string chainDirName, ComboBox cBoxStoreNames)
        {
            FileInfo[] filesInDir = GetStoresFileInfoOfChain(chainDirName);
            var storesFilePath = filesInDir[0].FullName;
            var XElementDoc = XElement.Load(storesFilePath);
            var storeNames = (from store
                              in XElementDoc.Descendants()
                              .Where(el => string.Compare(el.Name.LocalName, "Store",
                               StringComparison.OrdinalIgnoreCase) == 0)
                               select (string)store
                              .Element("StoreName"))
                              .ToArray<object>();

            cBoxStoreNames.Items.Clear();

            try
            {
                cBoxStoreNames.Items.AddRange(storeNames);
            }
            catch (ArgumentNullException ex)
            {
                File.WriteAllText(@"LogFiles\LoadingNamesFromFilesLog.txt",
                    $"StackTrace = {ex.StackTrace}, Message = { ex.Message} apperntly there is no element as StoreName");
            }
        }

        private void _cBox1Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            LoadStoreNamesOfChain((string)sendr.SelectedItem, _cBoxStores1);
        }

        private void _cBox2Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            LoadStoreNamesOfChain((string)sendr.SelectedItem, _cBoxStores2);
        }

        private void _cBox3Chain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sendr = sender as ComboBox;
            LoadStoreNamesOfChain((string)sendr.SelectedItem, _cBoxStores3);
        }
    }
}
