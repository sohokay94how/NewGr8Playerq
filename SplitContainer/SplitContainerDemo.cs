using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlExplorer.SplitContainer
{
    public partial class SplitContainerDemo : C1DemoForm
    {
        public SplitContainerDemo()
        {
            InitializeComponent();

            //AddProperty("VisualStyle", c1SplitContainer1);
            AddProperty("LineBelowHeader", c1SplitContainer1);
            AddProperty("RightToLeft", c1SplitContainer1);
        }
    }
}
