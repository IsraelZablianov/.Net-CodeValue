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
            this._items = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._shoppingCart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Compare = new System.Windows.Forms.Button();
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
            this._cBox1Chain.SelectedIndexChanged += new System.EventHandler(this.CBox1Chain_SelectedIndexChanged);
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
            this._cBox2Chain.SelectedIndexChanged += new System.EventHandler(this.CBox2Chain_SelectedIndexChanged);
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
            this._cBox3Chain.SelectedIndexChanged += new System.EventHandler(this.CBox3Chain_SelectedIndexChanged);
            // 
            // _items
            // 
            this._items.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._items.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._items.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._items.ForeColor = System.Drawing.SystemColors.InfoText;
            this._items.FormattingEnabled = true;
            this._items.Location = new System.Drawing.Point(12, 222);
            this._items.Name = "_items";
            this._items.Size = new System.Drawing.Size(143, 163);
            this._items.Sorted = true;
            this._items.TabIndex = 6;
            this._items.SelectedIndexChanged += new System.EventHandler(this.Items_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Image = global::PriceCompare.Properties.Resources.רשת_שיווק_364x245;
            this.label1.Location = new System.Drawing.Point(61, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "מוצרים";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _shoppingCart
            // 
            this._shoppingCart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._shoppingCart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._shoppingCart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this._shoppingCart.ForeColor = System.Drawing.SystemColors.InfoText;
            this._shoppingCart.FormattingEnabled = true;
            this._shoppingCart.Location = new System.Drawing.Point(171, 222);
            this._shoppingCart.Name = "_shoppingCart";
            this._shoppingCart.Size = new System.Drawing.Size(143, 163);
            this._shoppingCart.Sorted = true;
            this._shoppingCart.TabIndex = 8;
            this._shoppingCart.SelectedIndexChanged += new System.EventHandler(this.ShoppingCart_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Image = global::PriceCompare.Properties.Resources.רשת_שיווק_364x245;
            this.label2.Location = new System.Drawing.Point(212, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "סל הקניות";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Compare
            // 
            this.Compare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Compare.Location = new System.Drawing.Point(499, 12);
            this.Compare.Name = "Compare";
            this.Compare.Size = new System.Drawing.Size(101, 33);
            this.Compare.TabIndex = 10;
            this.Compare.Text = "Compare";
            this.Compare.UseVisualStyleBackColor = true;
            this.Compare.Click += new System.EventHandler(this.Compare_Click);
            // 
            // PriceCompareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PriceCompare.Properties.Resources.רשת_שיווק_364x245;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(616, 397);
            this.Controls.Add(this.Compare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._shoppingCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._items);
            this.Controls.Add(this._cBox3Chain);
            this.Controls.Add(this._cBoxStores2);
            this.Controls.Add(this._cBoxStores3);
            this.Controls.Add(this._cBox2Chain);
            this.Controls.Add(this._cBoxStores1);
            this.Controls.Add(this._cBox1Chain);
            this.MaximizeBox = false;
            this.Name = "PriceCompareDialog";
            this.Text = "Price Compare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cBox1Chain;
        private System.Windows.Forms.ComboBox _cBoxStores1;
        private System.Windows.Forms.ComboBox _cBox2Chain;
        private System.Windows.Forms.ComboBox _cBoxStores3;
        private System.Windows.Forms.ComboBox _cBoxStores2;
        private System.Windows.Forms.ComboBox _cBox3Chain;
        private System.Windows.Forms.ComboBox _items;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _shoppingCart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Compare;
    }
}

