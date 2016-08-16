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
        private ListBox PriceInfoLB1;
        private ListBox PriceInfoLB2;
        private ListBox PriceInfoLB3;
        private TextBox StoreName1;
        private TextBox StoreName2;
        private TextBox StoreName3;

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

        public void SetReportInfoOfStore1(string storeName, string priceInfo)
        {
            LoadReportInfo(storeName, priceInfo, StoreName1, PriceInfoLB1);
        }

        public void SetReportInfoOfStore2(string storeName, string priceInfo)
        {
            LoadReportInfo(storeName, priceInfo, StoreName2, PriceInfoLB2);
        }

        public void SetReportInfoOfStore3(string storeName, string priceInfo)
        {
            LoadReportInfo(storeName, priceInfo, StoreName3, PriceInfoLB3);
        }

        private void InitializeComponent()
        {
            this.PriceInfoLB1 = new System.Windows.Forms.ListBox();
            this.PriceInfoLB2 = new System.Windows.Forms.ListBox();
            this.PriceInfoLB3 = new System.Windows.Forms.ListBox();
            this.StoreName1 = new System.Windows.Forms.TextBox();
            this.StoreName2 = new System.Windows.Forms.TextBox();
            this.StoreName3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReportStore1
            // 
            this.PriceInfoLB1.FormattingEnabled = true;
            this.PriceInfoLB1.Location = new System.Drawing.Point(25, 35);
            this.PriceInfoLB1.Name = "ReportStore1";
            this.PriceInfoLB1.Size = new System.Drawing.Size(144, 121);
            this.PriceInfoLB1.TabIndex = 0;
            // 
            // ReportStore2
            // 
            this.PriceInfoLB2.FormattingEnabled = true;
            this.PriceInfoLB2.Location = new System.Drawing.Point(200, 35);
            this.PriceInfoLB2.Name = "ReportStore2";
            this.PriceInfoLB2.Size = new System.Drawing.Size(144, 121);
            this.PriceInfoLB2.TabIndex = 1;
            this.PriceInfoLB2.Visible = false;
            // 
            // ReportStore3
            // 
            this.PriceInfoLB3.FormattingEnabled = true;
            this.PriceInfoLB3.Location = new System.Drawing.Point(372, 35);
            this.PriceInfoLB3.Name = "ReportStore3";
            this.PriceInfoLB3.Size = new System.Drawing.Size(144, 121);
            this.PriceInfoLB3.TabIndex = 2;
            this.PriceInfoLB3.Visible = false;
            // 
            // StoreName1
            // 
            this.StoreName1.Location = new System.Drawing.Point(25, 12);
            this.StoreName1.Name = "StoreName1";
            this.StoreName1.Size = new System.Drawing.Size(144, 20);
            this.StoreName1.TabIndex = 3;
            // 
            // StoreName2
            // 
            this.StoreName2.Location = new System.Drawing.Point(200, 9);
            this.StoreName2.Name = "StoreName2";
            this.StoreName2.Size = new System.Drawing.Size(144, 20);
            this.StoreName2.TabIndex = 4;
            this.StoreName2.Visible = false;
            // 
            // StoreName3
            // 
            this.StoreName3.Location = new System.Drawing.Point(372, 9);
            this.StoreName3.Name = "StoreName3";
            this.StoreName3.Size = new System.Drawing.Size(144, 20);
            this.StoreName3.TabIndex = 5;
            this.StoreName3.Visible = false;
            // 
            // Report
            // 
            this.BackgroundImage = global::PriceCompare.Properties.Resources.products;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 348);
            this.Controls.Add(this.StoreName3);
            this.Controls.Add(this.StoreName2);
            this.Controls.Add(this.StoreName1);
            this.Controls.Add(this.PriceInfoLB3);
            this.Controls.Add(this.PriceInfoLB2);
            this.Controls.Add(this.PriceInfoLB1);
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
