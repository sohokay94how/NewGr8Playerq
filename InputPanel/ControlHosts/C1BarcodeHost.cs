using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using C1.Win.C1InputPanel;
using C1.Win.C1BarCode;

namespace ControlExplorer.InputPanel.ControlHosts
{
    class C1BarcodeHost : InputControlHost
    {
        /// <summary>
        /// Creates the C1Barcode control and its host element.
        /// </summary>
        public C1BarcodeHost()
            : base(new C1BarCode())
        {
        }

        /// <summary>
        /// Gets the hosted C1BarCode control.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public C1BarCode BarCode
        {
            get { return (C1BarCode)Control; }
        }

        /// <summary>
        /// Gets or sets the Code Type that the C1BarCode displays.
        /// </summary>
        [Category("Appearance")]
        [Description("Gets or sets the Code Type that the C1BarCode displays.")]
        public CodeTypeEnum CodeType
        {
            get { return BarCode.CodeType; }
            set { BarCode.CodeType = value; }
        }

        /// <summary>
        /// Gets or sets the Size Mode that the C1BarCode displays.
        /// </summary>
        [Category("Appearance")]
        [Description("Gets or sets the Size Mode that the C1BarCode displays.")]
        public PictureBoxSizeMode SizeMode
        {
            get { return BarCode.SizeMode; }
            set { BarCode.SizeMode = value; }
        }

        [Category("Appearance")]
        [Description("Gets or sets whether Text is displayed ontop of the barcode.")]
        public bool ShowText
        {
            get { return BarCode.ShowText; }
            set { BarCode.ShowText = value; }
        }

        [Category("Appearance")]
        [Description("Gets or sets the height of the bars.")]
        public int BarHeight
        {
            get { return BarCode.BarHeight; }
            set { BarCode.BarHeight = value; }
        }
    }
}
