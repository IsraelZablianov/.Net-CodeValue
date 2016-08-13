namespace PriceCompare
{
    partial class PriceCompareDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cBox1Chain = new System.Windows.Forms.ComboBox();
            this._cBoxStores1 = new System.Windows.Forms.ComboBox();
            this._cBox2Chain = new System.Windows.Forms.ComboBox();
            this._cBoxStores3 = new System.Windows.Forms.ComboBox();
            this._cBoxStores2 = new System.Windows.Forms.ComboBox();
            this._cBox3Chain = new System.Windows.Forms.ComboBox();
            this._products = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _cBox1Chain
            // 
            this._cBox1Chain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBox1Chain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBox1Chain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBox1Chain.FormattingEnabled = true;
            this._cBox1Chain.Location = new System.Drawing.Point(12, 12);
            this._cBox1Chain.Name = "_cBox1Chain";
            this._cBox1Chain.Size = new System.Drawing.Size(143, 85);
            this._cBox1Chain.Sorted = true;
            this._cBox1Chain.TabIndex = 0;
            this._cBox1Chain.SelectedIndexChanged += new System.EventHandler(this._cBox1Chain_SelectedIndexChanged);
            // 
            // _cBoxStores1
            // 
            this._cBoxStores1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBoxStores1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBoxStores1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBoxStores1.FormattingEnabled = true;
            this._cBoxStores1.Location = new System.Drawing.Point(12, 103);
            this._cBoxStores1.Name = "_cBoxStores1";
            this._cBoxStores1.Size = new System.Drawing.Size(143, 85);
            this._cBoxStores1.Sorted = true;
            this._cBoxStores1.TabIndex = 1;
            // 
            // _cBox2Chain
            // 
            this._cBox2Chain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBox2Chain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBox2Chain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBox2Chain.FormattingEnabled = true;
            this._cBox2Chain.Location = new System.Drawing.Point(171, 12);
            this._cBox2Chain.Name = "_cBox2Chain";
            this._cBox2Chain.Size = new System.Drawing.Size(143, 85);
            this._cBox2Chain.Sorted = true;
            this._cBox2Chain.TabIndex = 2;
            this._cBox2Chain.SelectedIndexChanged += new System.EventHandler(this._cBox2Chain_SelectedIndexChanged);
            // 
            // _cBoxStores3
            // 
            this._cBoxStores3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBoxStores3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBoxStores3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBoxStores3.FormattingEnabled = true;
            this._cBoxStores3.Location = new System.Drawing.Point(337, 103);
            this._cBoxStores3.Name = "_cBoxStores3";
            this._cBoxStores3.Size = new System.Drawing.Size(143, 85);
            this._cBoxStores3.Sorted = true;
            this._cBoxStores3.TabIndex = 3;
            // 
            // _cBoxStores2
            // 
            this._cBoxStores2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBoxStores2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBoxStores2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBoxStores2.FormattingEnabled = true;
            this._cBoxStores2.Location = new System.Drawing.Point(171, 103);
            this._cBoxStores2.Name = "_cBoxStores2";
            this._cBoxStores2.Size = new System.Drawing.Size(143, 85);
            this._cBoxStores2.Sorted = true;
            this._cBoxStores2.TabIndex = 4;
            // 
            // _cBox3Chain
            // 
            this._cBox3Chain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._cBox3Chain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cBox3Chain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._cBox3Chain.FormattingEnabled = true;
            this._cBox3Chain.Location = new System.Drawing.Point(337, 12);
            this._cBox3Chain.Name = "_cBox3Chain";
            this._cBox3Chain.Size = new System.Drawing.Size(143, 85);
            this._cBox3Chain.Sorted = true;
            this._cBox3Chain.TabIndex = 5;
            this._cBox3Chain.SelectedIndexChanged += new System.EventHandler(this._cBox3Chain_SelectedIndexChanged);
            // 
            // _products
            // 
            this._products.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._products.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._products.FormattingEnabled = true;
            this._products.Items.AddRange(new object[] {
            "first",
            "five",
            "four",
            "second",
            "six",
            "third"});
            this._products.Location = new System.Drawing.Point(493, 12);
            this._products.Name = "_products";
            this._products.Size = new System.Drawing.Size(128, 176);
            this._products.Sorted = true;
            this._products.TabIndex = 6;
            // 
            // PriceCompareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 397);
            this.Controls.Add(this._products);
            this.Controls.Add(this._cBox3Chain);
            this.Controls.Add(this._cBoxStores2);
            this.Controls.Add(this._cBoxStores3);
            this.Controls.Add(this._cBox2Chain);
            this.Controls.Add(this._cBoxStores1);
            this.Controls.Add(this._cBox1Chain);
            this.Name = "PriceCompareDialog";
            this.Text = "Price Compare";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _cBox1Chain;
        private System.Windows.Forms.ComboBox _cBoxStores1;
        private System.Windows.Forms.ComboBox _cBox2Chain;
        private System.Windows.Forms.ComboBox _cBoxStores3;
        private System.Windows.Forms.ComboBox _cBoxStores2;
        private System.Windows.Forms.ComboBox _cBox3Chain;
        private System.Windows.Forms.ComboBox _products;
    }
}

