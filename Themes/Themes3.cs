using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlExplorer.Themes
{
    public partial class Themes3 : C1DemoForm
    {
        public Themes3()
        {
            InitializeComponent();
           
            // populate combobox with all available themes
            var themes = C1.Win.C1Themes.C1ThemeController.GetThemes();
        
                
        }

    }
}
