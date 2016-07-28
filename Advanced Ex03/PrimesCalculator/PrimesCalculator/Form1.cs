using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class PrimesForm : Form
    {
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private ManualResetEvent _cancel = new ManualResetEvent(false);

        public PrimesForm()
        {
            InitializeComponent();
        }

        private void StartRangeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void EndRangeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var current = SynchronizationContext.Current;
            var cancell = _cancellationTokenSource.Token;
            int startIndex = 0, endIndex = 0;
            if(int.TryParse(_startRange.Text, out startIndex)
                && int.TryParse(_endRange.Text, out endIndex))
            {
                Task<List<int>>.Run(() =>
                {
                    bool prime;
                    var list = new List<int>();
                    for (int i = startIndex;i < endIndex && !cancell.IsCancellationRequested; i++)
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
                            list.Add(i);
                        }
                    }

                    return list;
                }, cancell).ContinueWith(prevTask =>{
                    current.Send(_=>{
                        _primesListBox.DataSource = prevTask.Result;
                    },null);});
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var current = SynchronizationContext.Current;
            int startIndex = 0, endIndex = 0;
            if (int.TryParse(_startRange.Text, out startIndex)
                && int.TryParse(_endRange.Text, out endIndex))
            {
                Task<List<int>>.Run(() =>
                {
                    bool prime;
                    var list = new List<int>();
                    for (int i = startIndex; i < endIndex && !_cancel.WaitOne(0); i++)
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
                            list.Add(i);
                        }
                    }

                    return list;
                }).ContinueWith(prevTask => {
                    current.Send(_ => {
                        _primesListBox.DataSource = prevTask.Result;
                    }, null);
                });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _cancel.Set();
        }
    }
}
