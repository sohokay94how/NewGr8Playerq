using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using C1.Win.C1Command;
using C1.Win.C1Ribbon;

namespace ControlExplorer
{
    public partial class MainForm : C1RibbonForm
    {
        private C1DemoViewer viewer = null;
        private C1DemoForm activeForm;
        //Create an XmlReader to begin parsing our xml
        
        int pageIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            viewer = new C1DemoViewer();
            Form = this;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region ReadControlXML

            XmlReader xr = XmlReader.Create("C1Controls.xml");
            //int _tcount = 0;
            //int _trow = 1;
            //int _tleft = 1;
            int indexgp = 0;

            //set text for Main heading Tile
            c1TileControl2.Groups[0].Tiles[0].Text1 = "ComponentOne Studio® for WinForms 包含超过65个.NET的控件，其中，还有一些是 WinForms所独有的。\n\n它拥有敏捷的设计器，超强的内置功能，可以超越开箱体验，超强的灵活性且保证这些控件可以经受时间的考验。";
            
            while (xr.Read())
            {
                if (xr.NodeType == XmlNodeType.Element)
                {
                    switch (xr.Name)
                    {
                        case "control":
                            string name = xr.GetAttribute("name");
                            string _gname = name;

                            //adding tile control for the home page    
                            C1.Win.C1Tile.Tile t1 = new C1.Win.C1Tile.Tile();
                            t1.Text = name;

                            //Highlight new controls and samples using a different tile image
                            if (xr.GetAttribute("status") == "new")
                            {
                                t1.Template = template2;
                                t1.ImageIndex = pageIndex;
                                t1.Image1 = ControlExplorer.Properties.Resources.New2014;
                            }
                            else
                            {
                                t1.ImageIndex = pageIndex;
                            }
                            c1TileControl1.Groups[0].Tiles.Add(t1);
                            
                            //create group for second tile
                            C1.Win.C1Tile.Group controlGrp = new C1.Win.C1Tile.Group();
                            controlGrp.Visible = false;
                            controlGrp.Name = name;
                            c1TileControl2.Groups.Add(controlGrp);
                            indexgp = controlGrp.Index;

                            ////reconfiguring how the tiles are arranged
                            //foreach (C1.Win.C1Tile.Tile _tSub in c1TileControl1.Groups[0].Tiles)
                            //{
                            //    if (_tleft >= 8)
                            //    {
                            //        _tleft = 1;
                            //        _trow = _trow + 1;
                            //    }
                            //    if (c1TileControl1.Groups[0].Tiles[_tcount] == _tSub)
                            //    {
                            //        _tSub.TopCell = _trow;
                            //        _tSub.LeftCell = _tleft;
                            //        _tleft = _tleft + 1;
                            //        _tcount = _tcount + 1;
                            //    }

                            //}
                            pageIndex++;
                            break;
                        case "sample":

                            //all the groups for individual controls are created one time, and individual sample tiles are added on form load.
                            //On subsequent clicks the groups for controls are hidden and shown, inorder to better performance.
                            C1.Win.C1Tile.Tile tsample = new C1.Win.C1Tile.Tile();
                            if(xr.GetAttribute("status")=="new")
                            {
                                tsample.Template = template4;
                                tsample.Image = ControlExplorer.Properties.Resources.c1new2;
                            }
                            tsample.Name = xr.GetAttribute("name");
                            tsample.Text = xr.GetAttribute("name");
                            tsample.Text1 = xr.GetAttribute("short");
                            tsample.Tag = new DemoForm(xr.GetAttribute("form"), xr.GetAttribute("description"));
                            c1TileControl2.Groups[indexgp].Tiles.Add(tsample);
                            break;
                    }
                }
            }

            #endregion

            LoadWelcomePage();
            comboVisualStyles.SelectedIndex = 6;
            _backBtn.Enabled = false;
            c1TileControl1.Select();
            
        }

        #region Internal Methods
        private void AddOrRemove(Control.ControlCollection collection, Control control)
        {
            if (control == null)
            {
                collection.Clear();
                return;
            }

            if (!collection.Contains(control))
            {
                collection.Clear();
                collection.Add(control);
                control.Dock = DockStyle.Fill;
                control.Visible = true;
            }
        }

        public void Attach(Control viewer)
        {
            AddOrRemove(panel1.Controls, viewer);
        }

        public void Detach()
        {
            Attach(null);
        }

        void ResetViewer()
        {
            viewer.Close();
        }

        private void LoadWelcomePage()
        {
            //for the tile version this is loaded blank - super label on homepage is populated with no text.
            activeForm = viewer.Run(typeof(Main.HomePage).ToString(), "ComponentOne Studio for WinForms", "");
            this.Attach(viewer);
        }

        // This method is used to refresh the control explorer home page, when the picture box on top us clicked.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadWelcomePage();
            refreshhomepage();
        }

        public void LoadPage(string formName, string title, string desc)
        {
            this.Cursor = Cursors.AppStarting;
            activeForm = viewer.Run(formName, title, desc);
            this.Attach(viewer);
            this.Cursor = Cursors.Default;
        }
        #endregion

        // handle setting the visual style
        #region visualStyles

        private void comboVisualStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVisualStyles.SelectedOption.Text.Equals("Office 2007 Blue"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Blue;
                
                //Tile area and header backcolors
                c1TileControl1.BackColor = c1TileControl2.BackColor = pictureBox1.BackColor = c1InputPanel1.BackColor = Color.FromArgb(227, 239, 255);
                
                //Caption area backcolor
                pictureBox2.BackColor = label1.BackColor = label3.BackColor = Color.FromArgb(101, 147, 207);
                label2.ForeColor = Color.Black;
                
                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = pictureBox3.BackColor = _backBtn.BackColor = vsLabel.ForeColor =  Color.FromArgb(21, 66, 139);
            }
            else if (comboVisualStyles.SelectedOption.Text.Equals("Office 2007 Silver"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Silver;

                //Tile area and header backcolors
                c1TileControl1.BackColor = c1TileControl2.BackColor = pictureBox1.BackColor = c1InputPanel1.BackColor = Color.FromArgb(203, 206, 215);

                //Caption area backcolor
                pictureBox2.BackColor = label1.BackColor = label3.BackColor = Color.FromArgb(180, 180, 193);
                label2.ForeColor = Color.Black;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = pictureBox3.BackColor = _backBtn.BackColor = Color.FromArgb(144, 144, 158);
                vsLabel.ForeColor = Color.Black;
            }
            else if (comboVisualStyles.SelectedOption.Text.Equals("Office 2007 Black"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2007Black;

                //Tile area and header backcolors
                c1TileControl1.BackColor = c1TileControl2.BackColor = pictureBox1.BackColor = c1InputPanel1.BackColor = Color.FromArgb(83, 83, 83);

                //Caption area backcolor
                pictureBox2.BackColor = label1.BackColor = label3.BackColor = Color.FromArgb(149, 154, 160);
                label2.ForeColor = Color.White;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = pictureBox3.BackColor = _backBtn.BackColor = Color.FromArgb(10, 10, 10);
                vsLabel.ForeColor = Color.White;
            }
            else if (comboVisualStyles.SelectedOption.Text.Equals("Office 2010 Blue"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Blue;

                //Tile area and header backcolors
                c1TileControl1.BackColor = Color.FromArgb(206, 221, 238);
                c1TileControl2.BackColor = Color.FromArgb(206, 221, 238);
                pictureBox1.BackColor = Color.FromArgb(206, 221, 238);
                c1InputPanel1.BackColor = Color.FromArgb(206, 221, 238);

                //Caption area backcolor
                pictureBox2.BackColor = Color.FromArgb(141, 174, 217);
                label1.BackColor = Color.FromArgb(141, 174, 217);
                label3.BackColor = Color.FromArgb(141, 174, 217);
                label2.ForeColor = Color.Black;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = Color.FromArgb(30, 57, 91);
                pictureBox3.BackColor = Color.FromArgb(30, 57, 91);
                _backBtn.BackColor = Color.FromArgb(30, 57, 91);
                vsLabel.ForeColor = Color.FromArgb(30, 57, 91);
            }
            else if (comboVisualStyles.SelectedOption.Text.Equals("Office 2010 Silver"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Silver;

                //Tile area and header backcolors
                c1TileControl1.BackColor = Color.FromArgb(232, 236, 240);
                c1TileControl2.BackColor = Color.FromArgb(232, 236, 240);
                pictureBox1.BackColor = Color.FromArgb(232, 236, 240);
                c1InputPanel1.BackColor = Color.FromArgb(232, 236, 240);

                //Caption area backcolor
                pictureBox2.BackColor = Color.FromArgb(192, 200, 209);
                label1.BackColor = Color.FromArgb(192, 200, 209);
                label3.BackColor = Color.FromArgb(192, 200, 209);
                label2.ForeColor = Color.Black;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = Color.FromArgb(165, 172, 181);
                pictureBox3.BackColor = Color.FromArgb(165, 172, 181);
                _backBtn.BackColor = Color.FromArgb(165, 172, 181);
                vsLabel.ForeColor = Color.Black;
            }
            else if (comboVisualStyles.SelectedOption.Text.Equals("Office 2010 Black"))
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Black;

                //Tile area and header backcolors
                c1TileControl1.BackColor = c1TileControl2.BackColor = pictureBox1.BackColor = c1InputPanel1.BackColor = Color.FromArgb(139, 139, 139);

                //Caption area backcolor
                pictureBox2.BackColor = Color.FromArgb(163, 163, 163);
                label1.BackColor = Color.FromArgb(163, 163, 163);
                label3.BackColor = Color.FromArgb(163, 163, 163);
                label2.ForeColor = Color.White;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = Color.FromArgb(48, 48, 48);
                pictureBox3.BackColor = Color.FromArgb(48, 48, 48);
                _backBtn.BackColor = Color.FromArgb(48, 48, 48);
                vsLabel.ForeColor = Color.White;
            }
            else
            {
                ControlExplorer.Properties.Settings.Default.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Windows7;

                //Tile area and header backcolors
                c1TileControl1.BackColor = Color.FromArgb(242, 242, 242);
                if (panel1.Visible)
                {
                    c1TileControl2.BackColor = Color.FromArgb(216, 225, 238);
                }
                else
                {
                    c1TileControl2.BackColor = Color.FromArgb(242, 242, 242);
                }
                pictureBox1.BackColor = Color.FromArgb(242, 242, 242);
                c1InputPanel1.BackColor = Color.FromArgb(242, 242, 242);

                //Caption area backcolor
                pictureBox2.BackColor = Color.FromArgb(54, 150, 0);
                label1.BackColor = Color.FromArgb(54, 150, 0);
                label3.BackColor = Color.FromArgb(54, 150, 0);
                label2.ForeColor = Color.Black;

                //Tiles backcolor to same as button bar backcolor
                c1TileControl1.TileBackColor = Color.FromArgb(64, 64, 64);
                pictureBox3.BackColor = Color.FromArgb(64, 64, 64);
                _backBtn.BackColor = Color.FromArgb(64, 64, 64);
                vsLabel.ForeColor = Color.FromArgb(64, 64, 64);
            }
            UpdateVisualStyle();
        }

        #endregion

        public static MainForm Form
        {
            get;
            set;
        }
        internal void UpdateVisualStyle()
        {
            if (activeForm != null) // ControlExplorerVisualStyle can be removed if all controls can catch ambient VisualStyle from this.VisualStyle value
            {
                activeForm.ControlExplorerVisualStyle = ControlExplorer.Properties.Settings.Default.VisualStyle;
            }
            this.VisualStyle = ControlExplorer.Properties.Settings.Default.VisualStyle;
            OnVisualStyleChanged(EventArgs.Empty); // force updating ambient VisualStyle property in all child controls
        }

        #region Events and Methods
        //Click event when any home page tile is clicked
        private void c1TileControl1_TileClicked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            //update view of homepage
            c1TileControl1.Visible = false;
            panel1.Visible = true;
            label1.Visible = false;
            label3.Text = e.Tile.Text.ToLower();
            label3.Visible = true;
            pictureBox2.Image = controlIcons.Images[e.Tile.ImageIndex];
            _backBtn.Visible = true;
            _backBtn.Enabled = true;

            //Load the first sample for control here
            loadFirstSample(e.Tile.Text);

            //Load tile group for samples list
            foreach (C1.Win.C1Tile.Group gp in c1TileControl2.Groups)
            {
                if (gp.Name == e.Tile.Text)
                    gp.Visible = true;
                else
                    gp.Visible = false;
            }
            if (comboVisualStyles.SelectedIndex == 6)
                c1TileControl2.BackColor = this.BackgroundColor;
        }

        //Load sample of the selected control
        private void loadFirstSample(string name)
        {
            foreach (C1.Win.C1Tile.Group gp in c1TileControl2.Groups)
            {
                if (gp.Name == name)
                {
                    C1.Win.C1Tile.Tile tsent = gp.Tiles[0];
                    loadandshow(tsent.Tag, tsent.Text,tsent.Text1);
                }
            }
        }
        //change visible properties of various container controls on the page
        private void refreshhomepage()
        {
            foreach (C1.Win.C1Tile.Group gp in c1TileControl2.Groups)
            {
                if (gp.Index != 0)
                    gp.Visible = false;
                else
                    gp.Visible = true;
            }
            c1TileControl1.Visible = true;
            panel1.Visible = false;
            label1.Visible = true;
            label3.Visible = false;
            label2.Text = "";
            pictureBox2.Image = null;
            _backBtn.Visible = false;
            _backBtn.Enabled = false;
            c1TileControl2.BackColor = c1TileControl1.BackColor;
            c1TileControl1.Select();
        }

        private void _backBtn_Click(object sender, EventArgs e)
        {
            LoadWelcomePage();
            refreshhomepage();
        }
        
        //Secod tile control click event, to launch the samples
        private void c1TileControl2_TileClicked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            if (e.Tile.Group.Index != 0)
            {
                _backBtn.Enabled = false;
               
                foreach (C1.Win.C1Tile.Tile tcol in e.Tile.Group.Tiles)
                {
                    tcol.BackColor = Color.White;
                }
                e.Tile.BackColor = Color.DarkGray;
                loadandshow(e.Tile.Tag, e.Tile.Text, e.Tile.Text1);
                
                //code changed for loading samples after each tile click
                //DemoForm d = (DemoForm)e.Tile.Tag;
                //this.Cursor = Cursors.AppStarting;
                //activeForm = viewer.Run(d.FormName, e.Tile.Text, d.Description);
                //this.Attach(viewer);
                //this.Cursor = Cursors.Default;
                //label2.Text = e.Tile.Text1;
                //System.Threading.Thread.Sleep(3000);
                _backBtn.Enabled = true;
            }
        }

        //method to load samples and launch them in demoviewer
        private void loadandshow(object tag, string text, string text1)
        {
            DemoForm d = (DemoForm)tag;
            this.Cursor = Cursors.AppStarting;
            activeForm = viewer.Run(d.FormName, text, d.Description);
            this.Attach(viewer);
            this.Cursor = Cursors.Default;
            label2.Text = text1;
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class DemoForm
    {
        string _form;
        string _desc;
        string _name;

        public DemoForm(string form, string desc)
        {
            _form = form;
            _desc = desc;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FormName
        {
            get { return _form; }
            set { _form = value; }
        }

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

    }
}
