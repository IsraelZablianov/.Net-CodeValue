using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primes
{
    class PrimesForm : Form
    {
        private TextBox _outputFileTextBox;
        private TextBox _endTextBox;
        private TextBox _startTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button _calculate;
        private Button _cancel;
        private Label label4;
        private Label _amountOfPrimeNumbersLabel;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public PrimesForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._outputFileTextBox = new System.Windows.Forms.TextBox();
            this._endTextBox = new System.Windows.Forms.TextBox();
            this._startTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._calculate = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._amountOfPrimeNumbersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _outputFileTextBox
            // 
            this._outputFileTextBox.Location = new System.Drawing.Point(91, 135);
            this._outputFileTextBox.Name = "_outputFileTextBox";
            this._outputFileTextBox.Size = new System.Drawing.Size(154, 20);
            this._outputFileTextBox.TabIndex = 0;
            // 
            // _endTextBox
            // 
            this._endTextBox.Location = new System.Drawing.Point(91, 94);
            this._endTextBox.Name = "_endTextBox";
            this._endTextBox.Size = new System.Drawing.Size(154, 20);
            this._endTextBox.TabIndex = 1;
            this._endTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndTextBox_KeyPress);
            // 
            // _startTextBox
            // 
            this._startTextBox.Location = new System.Drawing.Point(91, 59);
            this._startTextBox.Name = "_startTextBox";
            this._startTextBox.Size = new System.Drawing.Size(154, 20);
            this._startTextBox.TabIndex = 2;
            this._startTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output File";
            // 
            // _calculate
            // 
            this._calculate.Location = new System.Drawing.Point(27, 188);
            this._calculate.Name = "_calculate";
            this._calculate.Size = new System.Drawing.Size(96, 32);
            this._calculate.TabIndex = 6;
            this._calculate.Text = "Calculate";
            this._calculate.UseVisualStyleBackColor = true;
            this._calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // _cancel
            // 
            this._cancel.Location = new System.Drawing.Point(149, 188);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(96, 32);
            this._cancel.TabIndex = 7;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount of prime numbers :";
            // 
            // _amountOfPrimeNumbersLabel
            // 
            this._amountOfPrimeNumbersLabel.AutoSize = true;
            this._amountOfPrimeNumbersLabel.Location = new System.Drawing.Point(163, 252);
            this._amountOfPrimeNumbersLabel.Name = "_amountOfPrimeNumbersLabel";
            this._amountOfPrimeNumbersLabel.Size = new System.Drawing.Size(0, 13);
            this._amountOfPrimeNumbersLabel.TabIndex = 9;
            // 
            // PrimesForm
            // 
            this.ClientSize = new System.Drawing.Size(285, 365);
            this.Controls.Add(this._amountOfPrimeNumbersLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._calculate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._startTextBox);
            this.Controls.Add(this._endTextBox);
            this.Controls.Add(this._outputFileTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrimesForm";
            this.Text = "Primes Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void StartTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void EndTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private async void Calculate_Click(object sender, EventArgs e)
        {
            var taskResult = await CalcPrimesAsync();
            File.WriteAllText(
                _outputFileTextBox.Text, taskResult.ToString());
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private async Task<int> CalcPrimesAsync()
        {
            int amountOfPrimes = 0;
            int startIndex, endIndex;
            var cancel = _cancellationTokenSource.Token;

            if (int.TryParse(_startTextBox.Text, out startIndex)
                && int.TryParse(_endTextBox.Text, out endIndex))
            {
                await Task.Run(() =>
                {
                    bool prime;
                    var list = new List<int>();
                    for (int i = startIndex; i < endIndex && !cancel.IsCancellationRequested; i++)
                    {
                        prime = true;
                        for (int j = 2; j <= Math.Sqrt(i) && prime; j++)
                        {
                            if (((double)i / j) == (i / j))
                            {
                                prime = false;
                            }
                        }

                        if (prime && i >= 2)
                        {
                            amountOfPrimes++;
                        }
                    }

                    return amountOfPrimes;
                }, cancel);
            }

            _amountOfPrimeNumbersLabel.Text = amountOfPrimes.ToString();
            return amountOfPrimes;
        }
    }
}
