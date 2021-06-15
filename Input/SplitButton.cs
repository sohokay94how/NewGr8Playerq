using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ControlExplorer.Input
{
    using C1.Win.C1Input;

    public partial class SplitButton : C1DemoForm
    {

        VisualStyle _visualStyle = VisualStyle.Custom;
        DropDownItem _lastVisualStyleItem;

        public SplitButton()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitVisualStyles();
            richTextBox1.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "Resources\\sample.rtf");
            c1SplitButtonSpell.DefaultItem = c1SplitButtonSpell.Items[0];
        }

        public VisualStyle VisualStyle
        {
            get
            {
                return _visualStyle;
            }
            set
            {
                if (_visualStyle != value)
                {
                    _visualStyle = value;
                    OnVisualStyleChanged();
                }
            }
        }

        void OnVisualStyleChanged()
        {
            this.c1SplitButtonSpell.VisualStyle = this.VisualStyle;
            this.c1SplitButtonVisualStyle.VisualStyle = this.VisualStyle;
            // set form's background
            Color color;
            switch (this.VisualStyle)
            {
                case C1.Win.C1Input.VisualStyle.Office2007Blue:
                    color = Color.FromArgb(255, 164, 195, 235);
                    break;
                case C1.Win.C1Input.VisualStyle.Office2007Black:
                    color = Color.FromArgb(255, 70, 70, 70);
                    break;
                case C1.Win.C1Input.VisualStyle.Office2007Silver:
                    color = Color.FromArgb(255, 170, 174, 181);
                    break;
                case C1.Win.C1Input.VisualStyle.Office2010Black:
                    color = Color.FromArgb(255, 139, 139, 139);
                    break;
                case C1.Win.C1Input.VisualStyle.Office2010Blue:
                    color = Color.FromArgb(255, 207, 221, 238);
                    break;
                case C1.Win.C1Input.VisualStyle.Office2010Silver:
                    color = Color.FromArgb(255, 233, 237, 241);
                    break;
                default:
                    color = SystemColors.Control;
                    break;
            }
            this.BackColor = color;
            c1SplitButtonVisualStyle.Text = Enum.GetName(typeof(VisualStyle), this.VisualStyle);
        }

        void InitVisualStyles()
        {
            this.VisualStyle = VisualStyle.Office2007Blue;
            var styles = Enum.GetValues(typeof(VisualStyle));
            foreach (VisualStyle style in styles)
            {
                if (style != VisualStyle.Custom)
                {
                    var item = new DropDownItem();
                    item.Text = Enum.GetName(typeof(VisualStyle), style);
                    item.Tag = style;
                    item.CheckOnClick = true;
                    if (this.VisualStyle == style)
                    {
                        _lastVisualStyleItem = item;
                        item.Checked = true;
                    }
                    c1SplitButtonVisualStyle.Items.Add(item);
                }
            }
        }

        private void c1SplitButtonVisualStyle_DropDownItemClicked(object sender, C1.Win.C1Input.DropDownItemClickedEventArgs e)
        {
            if (_lastVisualStyleItem != null)
            {
                _lastVisualStyleItem.Checked = false;
            }
            this.VisualStyle = (VisualStyle)e.ClickedItem.Tag;
            _lastVisualStyleItem = e.ClickedItem;
        }

        private void c1SplitButtonSpell_DropDownItemClicked(object sender, DropDownItemClickedEventArgs e)
        {
            if (e.ClickedItem.Items.Count == 0)
                MessageBox.Show(this, string.Format("Checking the document with the {0} dictionary.", e.ClickedItem.Text));
        }
    }
}
