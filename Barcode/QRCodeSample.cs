using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1BarCode;

namespace ControlExplorer.Barcode
{
    public partial class QRCodeSample : C1DemoForm
    {
        public QRCodeSample()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c1QRCode1.Text = textBox1.Text;
        }

        private void QRCodeSample_Load(object sender, EventArgs e)
        {
            //add demo properties
            AddProperty("Encoding", c1QRCode1);
            AddProperty("SymbolSize", c1QRCode1); 
        }
    }
}
