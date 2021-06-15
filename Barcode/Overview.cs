using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1BarCode;
using C1.Win.C1InputPanel;

namespace ControlExplorer.Barcode
{
    public partial class Overview : C1DemoForm
    {
        public Overview()
        {
            InitializeComponent();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            BarCodeValue = txtValue.Text;   
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            //add demo properties
            AddProperty("BarHeight", this);
            AddProperty("ShowText", this);
        }

        //gets and sets the Text property for all C1Barcodes inside the C1InputPanel
        public string BarCodeValue
        {
            get { return c1BarcodeHost39.Text; }
            set {
                foreach (InputComponent ic in c1InputPanel1.Items)
                {
                    if (ic.GetType() == typeof(InputPanel.ControlHosts.C1BarcodeHost))
                    {
                        ic.Text = value;
                    }
                }
            }
        }

        //gets and sets the ShowText property for all C1Barcodes inside the C1InputPanel
        public bool ShowText
        {
            get { return c1BarcodeHost39.ShowText; }
            set
            {
                foreach (InputComponent ic in c1InputPanel1.Items)
                {
                    if (ic.GetType() == typeof(InputPanel.ControlHosts.C1BarcodeHost))
                    {
                        InputPanel.ControlHosts.C1BarcodeHost bch = (InputPanel.ControlHosts.C1BarcodeHost)ic;
                        bch.ShowText = value;
                    }
                }
            }
        }

        //gets and sets the BarHeight property for all C1Barcodes inside the C1InputPanel
        public int BarHeight
        {
            get { return c1BarcodeHost39.BarHeight; }
            set
            {
                foreach (InputComponent ic in c1InputPanel1.Items)
                {
                    if (ic.GetType() == typeof(InputPanel.ControlHosts.C1BarcodeHost))
                    {
                        InputPanel.ControlHosts.C1BarcodeHost bch = (InputPanel.ControlHosts.C1BarcodeHost)ic;
                        bch.BarHeight = value;
                    }
                }
            }
        }
    }
}
