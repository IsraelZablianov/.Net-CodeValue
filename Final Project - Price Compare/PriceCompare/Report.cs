using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCompare
{
    public class Report : Form
    {
        private ListBox _reportInformation;
        private Label label4;
        private Label label1;
        private ListBox _listOfStores;

        public Report()
        {
            InitializeComponent();
        }

        private void LoadReportInfo(string storeName, string priceInfo, TextBox storeNameTB, ListBox priceInfoLB)
        {
            storeNameTB.Visible = true;
            priceInfoLB.Visible = true;

            storeNameTB.Text = storeName;
            priceInfoLB.Text = priceInfo;
        }

        //public void SetReportInfoOfStore1(string storeName, string priceInfo)
        //{
        //    LoadReportInfo(storeName, priceInfo, StoreName1, _listOfStores);
        //}


        private void InitializeComponent()
        {
            this._listOfStores = new System.Windows.Forms.ListBox();
            this._reportInformation = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _listOfStores
            // 
            this._listOfStores.FormattingEnabled = true;
            this._listOfStores.Location = new System.Drawing.Point(25, 35);
            this._listOfStores.Name = "_listOfStores";
            this._listOfStores.Size = new System.Drawing.Size(144, 212);
            this._listOfStores.TabIndex = 0;
            // 
            // _reportInformation
            // 
            this._reportInformation.FormattingEnabled = true;
            this._reportInformation.Location = new System.Drawing.Point(189, 35);
            this._reportInformation.Name = "_reportInformation";
            this._reportInformation.Size = new System.Drawing.Size(144, 212);
            this._reportInformation.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(22, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "סניפים נבחרים להשוואה";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(233, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "מחירים";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Report
            // 
            this.BackgroundImage = global::PriceCompare.Properties.Resources.products;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 348);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._reportInformation);
            this.Controls.Add(this._listOfStores);
            this.ForeColor = System.Drawing.Color.DeepPink;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
