using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using C1.Win.C1FlexGrid;

namespace ControlExplorer.FlexGrid
{
    public partial class ColumnCellTypes : C1DemoForm
    {
        public ColumnCellTypes()
        {
            InitializeComponent();
        }

        //Store column indexes for easy rearrangement
        private int _imageCol = 1;
        private int _textCol = 2;
        private int _checkboxCol = 3;
        private int _numericCol = 4;
        private int _comboCol = 5;
        private int _checkListCol = 6;
        private int _multiComboCol = 7;
        private int _dateCol = 8;
        private int _editMaskCol = 9;
        private int _largeTextCol = 10;
        private int _progressBarCol = 11;
        private int _hyperlinkCol = 12;
        
        //Total column count
        private int _colCount = 13;  

        //The FlexGrid in this demo is completely unbound. All of the column properties and data are added manually below
        private void ColumnCellTypes_Load(object sender, EventArgs e)
        {
            c1FlexGrid1.Cols.Count = _colCount;

            //Image column
            Column imageCol = c1FlexGrid1.Cols[_imageCol];
            imageCol.Caption = "图片";
            imageCol.DataType = typeof(Image);
            imageCol.ImageAlign = ImageAlignEnum.CenterCenter;
            //imageCol.Editor = new ImagePicker();
            imageCol.Width = 75;

            //Text column
            Column textCol = c1FlexGrid1.Cols[_textCol];
            textCol.Caption = "文本";

            //Checkbox column
            Column checkboxCol = c1FlexGrid1.Cols[_checkboxCol];
            checkboxCol.DataType = typeof(Boolean);
            checkboxCol.Caption = "复选框";
            checkboxCol.Width = 75;

            //Numeric column
            Column numericCol = c1FlexGrid1.Cols[_numericCol];
            //numericCol.Caption = "Numeric";
            numericCol.Caption = "数字";
            numericCol.DataType = typeof(double);
            numericCol.Editor = c1NumericEdit1;
            numericCol.Format = "c";

            //Combo column
            Column comboCol = c1FlexGrid1.Cols[_comboCol];
            comboCol.ComboList = "|共和制|联邦共和制|君主立宪制|君主国会制";
            //comboCol.Caption = "Editable Combobox";
            comboCol.Caption = "可编辑组合框";
            comboCol.Width = 150;

            //Date column
            Column dateCol = c1FlexGrid1.Cols[_dateCol];
            dateCol.DataType = typeof(DateTime);    
            dateCol.Caption = "日期";


            //Input mask column
            Column editMaskCol = c1FlexGrid1.Cols[_editMaskCol];
            editMaskCol.EditMask = "GMT#0:00";
            editMaskCol.Caption = "输入占位符";

            //Checkbox List column
            Column checkListCol = c1FlexGrid1.Cols[_checkListCol];
            CheckListEditor checkListEditor = new CheckListEditor(new string[] { "丹麦语", "荷兰语", "英语", "芬兰语", "法语", "德语", "意大利语", "挪威语", "波兰语", "葡萄牙语", "西班牙语", "瑞典语" });
            checkListCol.Caption = "复选框列表";
            checkListCol.Editor = new UITypeEditorControl(checkListEditor, false);
            checkListCol.Width = 150;

            //Multi-column combo
            c1Combo1.AddItemTitles("Symbol;Code;Description");
            c1Combo1.AddItem("$;ARS;Argentinean Peso");
            c1Combo1.AddItem("R$;BRL;Brazilian Reais");
            c1Combo1.AddItem("$;CAD;Canadian Dollar");
            c1Combo1.AddItem("kr;DKK;Danish Krone");
            c1Combo1.AddItem((char)8364 + ";EUR;Euro");
            c1Combo1.AddItem((char)163 + ";GBP;Great Britain Pound");
            c1Combo1.AddItem("$;MXN;Mexican Peso");
            c1Combo1.AddItem("kr;NOK;Norwegian Krone");
            c1Combo1.AddItem("z" + (char)322 + ";PLK;Poland Zlotych");
            c1Combo1.AddItem("kr;SEK;Swedish Krone");
            c1Combo1.AddItem("CHF;CHF;Swiss Franc");
            c1Combo1.AddItem("$;USD;US Dollar");
            c1Combo1.DisplayMember = "Code";
            c1Combo1.ValueMember = "Code";
            c1Combo1.DropDownWidth = 202;
            c1Combo1.Splits[0].DisplayColumns[0].Width = 50;
            c1Combo1.Splits[0].DisplayColumns[1].Width = 30;
            Column multiComboCol = c1FlexGrid1.Cols[_multiComboCol];
          
            multiComboCol.Caption = "多列组合框";
            multiComboCol.Editor = c1Combo1;
            multiComboCol.Width = 130;     
            
            //Hyperlink column
            Column hyperlinkCol = c1FlexGrid1.Cols[_hyperlinkCol];

            hyperlinkCol.AllowEditing = true;
            hyperlinkCol.Width = 160;

            hyperlinkCol.Caption = "超链接";
            hyperlinkCol.ComboList = "...";
            CellStyle cs = c1FlexGrid1.Styles.Add("NewLink");
            cs.Font = new Font(c1FlexGrid1.Font, FontStyle.Underline);
            cs.ForeColor = Color.Blue;
            cs = c1FlexGrid1.Styles.Add("OldLink");
            cs.Font = new Font(c1FlexGrid1.Font, FontStyle.Underline);
            cs.ForeColor = Color.Purple;

            //Large text column
            Column largeTextCol = c1FlexGrid1.Cols[_largeTextCol];
            //largeTextCol.Caption = "Large Text";
            largeTextCol.Caption = "大规模文本";
            cs = c1FlexGrid1.Styles.Add("LargeText");
            cs.Trimming = StringTrimming.EllipsisWord;
            largeTextCol.Style = cs;
            largeTextCol.Width = 120;
            largeTextCol.Editor = flexTextBox1;

            //Progress bar column
            Column progressBarCol = c1FlexGrid1.Cols[_progressBarCol];
            //progressBarCol.Caption = "ProgressBar";
            progressBarCol.Caption = "进度条";
            progressBarCol.DataType = typeof(int);
            pb = new ProgressBar();
          
            //Load data
            LoadData();

            //Display Add new Row
            c1FlexGrid1.AllowAddNew = true;  
        
            //Add Demo Properties
            AddProperty("AllowAddNew", c1FlexGrid1);
            AddProperty("KeyActionTab", c1FlexGrid1);
            AddProperty("ShowButtons", c1FlexGrid1);
            
        }

        private void LoadData()
        {
            c1FlexGrid1.Rows.Count = 21;
            Random rnd = new Random();

            //string countries = "Argentina|Austria|Belgium|Brazil|Canada|Denmark|Finland|France|Germany|Ireland|Italy|Mexico|Norway|Poland|Portugal|Spain|Sweden|Switzerland|UK|USA";
            string countries = "阿根廷|澳大利亚|比利时|巴西|加拿大|丹麦|芬兰|法国|德国|爱尔兰|意大利|墨西哥|挪威|波兰|葡萄牙|西班牙|瑞典|瑞士|英国|美国";
            string currencies = "ARS|EUR|EUR|BRL|CAD|DKK|EUR|EUR|EUR|EUR|EUR|MXN|NOK|PLK|EUR|EUR|SEK|CHF|EUR|USD";
            string govs = "共和制|联邦政府共和制|其他|联邦政府共和制|其他|君主立宪制 |共和制|共和制|联邦政府共和制|共和制|共和制|联邦政府共和制|君主立宪制|共和制|共和制|君主国会制|君主立宪制 |其他| 君主立宪制|联邦共和制 ";
            string times = "GMT-3:00|GMT+2:00|GMT+2:00|GMT-3:00|GMT-3:30|GMT+2:00|GMT+3:00|GMT+2:00|GMT+1:00|GMT+1:00|GMT+1:00|GMT-6:00|GMT+1:00|GMT+1:00|GMT+1:00|GMT+1:00|GMT+1:00|GMT+1:00|GMT+0:00|GMT-6:00";
            string languages = "西班牙语|德语|荷兰语, 法语, 德语|葡萄牙语|英语, 法语|丹麦语|芬兰语, 瑞典语|法语|德语|英语|意大利语|西班牙语|芬兰语, 挪威语|波兰语|葡萄牙语|西班牙语|瑞典语|法语, 德语, 意大利语|英语|英语";
            
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                //Load image data
                c1FlexGrid1[i, _imageCol] = imageList1.Images[i - 1];
                //Load text data
                c1FlexGrid1[i, _textCol] = countries.Split('|')[i - 1];
                //Load combos data
                c1FlexGrid1[i, _multiComboCol] = currencies.Split('|')[i - 1];
                //Load multi-column combos data
                c1FlexGrid1[i, _comboCol] = govs.Split('|')[i - 1];
                //Load input mask data
                c1FlexGrid1[i, _editMaskCol] = times.Split('|')[i - 1];
                //Load checkbox list data
                c1FlexGrid1[i, _checkListCol] = languages.Split('|')[i - 1];
            }  

            //Load Dates column
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1[i, _dateCol] = DateTime.Now.AddDays(rnd.Next(1, 100));
            }
  
            //Load Checkbox column
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1[i, _checkboxCol] = countries.Split('|')[i - 1].Length % 2;
            }

            //Load numeric column
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1[i, _numericCol] = rnd.Next(1, 1500);
            }

            //Load hyperlink column
            c1FlexGrid1[1, _hyperlinkCol] = new FlexHyperlink("旅游秘书处", "http://www.turismo.gov.ar/eng/menu.htm");
            c1FlexGrid1[2, _hyperlinkCol] = new FlexHyperlink("澳大利亚大使馆", "http://www.austria.org/");
            c1FlexGrid1[3, _hyperlinkCol] = new FlexHyperlink("游览比利时", "http://www.visitbelgium.com/");
            c1FlexGrid1[4, _hyperlinkCol] = new FlexHyperlink("巴西 - 维基百科", "http://en.wikipedia.org/wiki/Brazil");
            c1FlexGrid1[5, _hyperlinkCol] = new FlexHyperlink("加拿大官网", "http://www.canada.com/");
            c1FlexGrid1[6, _hyperlinkCol] = new FlexHyperlink("丹麦的官方网", "http://www.denmark.dk/");
            c1FlexGrid1[7, _hyperlinkCol] = new FlexHyperlink("芬兰的新闻", "http://finland.fi/");
            c1FlexGrid1[8, _hyperlinkCol] = new FlexHyperlink("法国导游网", "http://www.franceguide.com/");
            c1FlexGrid1[9, _hyperlinkCol] = new FlexHyperlink("德国信息网", "http://www.germany.info/");
            c1FlexGrid1[10, _hyperlinkCol] = new FlexHyperlink("发现爱尔兰", "http://www.discoverireland.ie/");
            c1FlexGrid1[11, _hyperlinkCol] = new FlexHyperlink("关于意大利", "http://www.state.gov/r/pa/ei/bgn/4033.htm");
            c1FlexGrid1[12, _hyperlinkCol] = new FlexHyperlink("游览墨西哥", "http://www.visitmexico.com/");
            c1FlexGrid1[13, _hyperlinkCol] = new FlexHyperlink("挪威官方网", "http://www.norway.org/");
            c1FlexGrid1[14, _hyperlinkCol] = new FlexHyperlink("波兰.pl", "http://www.poland.pl/");
            c1FlexGrid1[15, _hyperlinkCol] = new FlexHyperlink("葡萄牙地图", "http://www.portugal-info.net/maps/");
            c1FlexGrid1[16, _hyperlinkCol] = new FlexHyperlink("西班牙旅行者", "http://www.spain.info/");
            c1FlexGrid1[17, _hyperlinkCol] = new FlexHyperlink("游览瑞典", "http://www.visitsweden.com/");
            c1FlexGrid1[18, _hyperlinkCol] = new FlexHyperlink("游览瑞士", "http://www.about.ch/");
            c1FlexGrid1[19, _hyperlinkCol] = new FlexHyperlink("谷歌 英国", "http://www.google.co.uk/");
            c1FlexGrid1[20, _hyperlinkCol] = new FlexHyperlink("美利坚合众国 - 维基百科", "http://en.wikipedia.org/wiki/United_States");

            //Load large text column
            //c1FlexGrid1[1, _largeTextCol] = "Argentina is the eighth largest country in the world by land area and the largest among Spanish-speaking nations, though Mexico, Colombia and Spain are more populous.";
            c1FlexGrid1[1, _largeTextCol] = "阿根廷的土地面积是世界上第八大的，在讲西班牙语的国家中是最大的国家，但墨西哥，哥伦比亚和西班牙是人口较多的.";
            //c1FlexGrid1[2, _largeTextCol] = "The origins of Austria date back to the time of the Roman Empire when a Celtic kingdom was conquered by the Romans in approximately 15 BC, and later became Noricum, a Roman province, in the mid 1st century AD—an area which mostly encloses today's Austria.";
            c1FlexGrid1[2, _largeTextCol] = "奥地利的起源追溯到罗马帝国时期，那时凯尔特王国征服了罗马人，时间大约公元前15年，后来在公元1世纪中期成为Noricum，罗马省，这些区域大多包围今天的奥地利。";
            //c1FlexGrid1[3, _largeTextCol] = "Straddling the cultural boundary between Germanic and Latin Europe, Belgium is home to two main linguistic groups, the Flemish and the French-speakers, mostly Walloons, plus a small group of German-speakers.";
            c1FlexGrid1[3, _largeTextCol] = "跨界日尔曼和拉丁欧洲之间的文化边界，比利时是两大语言群体的家乡，佛兰芒语和法语，大多是瓦隆人，再加上小部分说德语的人。";
            //c1FlexGrid1[4, _largeTextCol] = "Brazil is the world's tenth largest economy at market exchange rates and the ninth largest by purchasing power parity.";
            c1FlexGrid1[4, _largeTextCol] = "巴西是世界经济市场汇率第十大和购买力平价的第九大的国家。";
            //c1FlexGrid1[9, _largeTextCol] = "The territory of Germany covers 357,021 square kilometers (137,847 sq mi) and is influenced by a temperate seasonal climate. With 82 million inhabitants, it accounts for the largest population among the member states of the European Union and is home to the third-largest number of international migrants worldwide.";
            c1FlexGrid1[9, _largeTextCol] = "德国境内占地357021平方公里（137847平方英里），受温带季节性气候的影响，82万居民，是人口最多的欧洲联盟成员国，是国际移民的数量全球第三。";
            //c1FlexGrid1[10, _largeTextCol] = "Traditionally, the island of Ireland is subdivided into four provinces: Connacht, Leinster, Munster and Ulster; and, in a system developed between the 13th and 17th centuries, thirty-two counties.";
            c1FlexGrid1[10, _largeTextCol] = "传统上，爱尔兰岛分为四个省：康诺特，伦斯特，蒙斯特和阿尔斯特;第13和17世纪发展成的一个系统，该系统中有32个县。";
            //c1FlexGrid1[12, _largeTextCol] = "Mexico is crossed from north to south by two mountain ranges known as Sierra Madre Oriental and Sierra Madre Occidental, which are the extension of the Rocky Mountains from northern North America.";
            c1FlexGrid1[12, _largeTextCol] = "墨西哥被两山横跨南北，两山为马德雷东方和马德雷西方，这是从北美洲北部的洛基山脉的延伸范围。";
            
            //c1FlexGrid1[16, _largeTextCol] = "Because of its location, the territory of Spain was subject to many external influences, often simultaneously, since prehistoric times and through the dawn of the new era.";
            c1FlexGrid1[16, _largeTextCol] = "因为西班牙的位置，它的领土是受到许多外部因素的影响的，往往同时，自史前时代，到曙光的新时代。";
            //c1FlexGrid1[17, _largeTextCol] = "Sweden emerged as an independent and unified country during the Middle Ages. In the 17th century the country expanded its territories to form the Swedish empire.";
            c1FlexGrid1[17, _largeTextCol] = "在中世纪瑞典成为一个独立的和统一的国家，在17世纪国家扩大其领土，形成了瑞典帝国。";
            //c1FlexGrid1[18, _largeTextCol] = "Switzerland is a landlocked country whose territory is geographically divided between the Jura, the Central Plateau and the Alps; adding together an area of 41,285 km².";
            c1FlexGrid1[18, _largeTextCol] = "瑞士是一个内陆国家，其领土在地理上分为汝拉，中部高原和阿尔卑斯山，面积相加一共41285平方千米";
            //c1FlexGrid1[19, _largeTextCol] = "The UK is a developed country, with the world's sixth largest economy by nominal GDP and the seventh largest by purchasing power parity.";
            c1FlexGrid1[19, _largeTextCol] = "英国是一个发达国家，从国内生产总值来看是世界第六大经济体，购买力水平世界第七大。";
            //c1FlexGrid1[20, _largeTextCol] = "The country is situated mostly in central North America, where its 48 contiguous states and Washington, D.C., the capital district, lie between the Pacific and Atlantic Oceans, bordered by Canada to the north and Mexico to the south.";
            c1FlexGrid1[20, _largeTextCol] = "该国的大部分地区，如48个州和华盛顿特区，首都地区大都位于北美洲中部，介于太平洋和大西洋，与加拿大北部和墨西哥南部接壤。";

            //Load progressbar column
            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                c1FlexGrid1[i, _progressBarCol] = rnd.Next(0, 100);
            }
        } 

        private void c1FlexGrid1_CellButtonClick(object sender, RowColEventArgs e)
        {
            //Fires when user clicks any cell button. Use e.Row/e.Col to determine which button was clicked.
        }

        Bitmap _bmp;
        //CellStyle csCellStyle;
        ProgressBar pb;

        private void c1FlexGrid1_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Row <= 0) return;
            
            //Handle Hyperlinks
            if (e.Col == _hyperlinkCol)
            {
                FlexHyperlink link = c1FlexGrid1[e.Row, e.Col] as FlexHyperlink;
                if (link != null)
                    e.Style = c1FlexGrid1.Styles[link.Visited ? "OldLink" : "NewLink"];

            }

            //Handle Progress Bars
            else if (e.Col == _progressBarCol && e.Row > 0 && e.Row < c1FlexGrid1.Rows.Count - 1)
            {
                //Get underlying value
                int value = 0;
                if (c1FlexGrid1[e.Row, e.Col] == null)
                {
                    c1FlexGrid1[e.Row, e.Col] = value;
                }
                else
                {
                    value = (int)c1FlexGrid1[e.Row, e.Col];
                }
                if (value < 0) value = 0;
                if (value > 100) value = 100;

                // draw background
                //e.Style = c1FlexGrid1.Styles.Highlight;
                e.DrawCell(DrawCellFlags.Background);

                // draw progress bar background from actual ProgressBar control
                Rectangle rc = e.Bounds;
                rc.Inflate(-2, -2);
                _bmp = new Bitmap(e.Bounds.Size.Width, e.Bounds.Size.Height);
                pb.Size = e.Bounds.Size;
                pb.DrawToBitmap(_bmp, new Rectangle(new Point(0, 0), e.Bounds.Size));
                e.Graphics.DrawImage(_bmp, rc);
                
                //Draw Green Progress image over top of background
                rc.Width = rc.Width * value / 100;
                rc.Inflate(-1, -1);
                e.Graphics.DrawImage(imageList1.Images["progress.png"], rc);

                // draw text
                e.Text = value.ToString() + "%";
                e.DrawCell(DrawCellFlags.Content);
                e.Handled = true;
            }
            
        }

        private void c1FlexGrid1_MouseMove(object sender, MouseEventArgs e)
        {
            //Handle Hyperlink cursor
            HitTestInfo ht = c1FlexGrid1.HitTest(e.X, e.Y);
            if (ht.Column == _hyperlinkCol)
            {
                bool hand = false;
                if (ht.Type == HitTestTypeEnum.Cell)
                {
                    FlexHyperlink link = c1FlexGrid1[ht.Row, ht.Column] as FlexHyperlink;
                    if (link != null)
                    {
                        using (Graphics g = c1FlexGrid1.CreateGraphics())
                        {
                            Rectangle rc = c1FlexGrid1.GetCellRect(ht.Row, ht.Column, false);
                            int width = (int)g.MeasureString(link.ToString(), c1FlexGrid1.Font).Width;
                            if (e.X - rc.Left <= width)
                                hand = true;
                        }
                        //set Tooltip
                        c1SuperTooltip1.SetToolTip(c1FlexGrid1, link.Url);
                    }
                }
                Cursor = (hand) ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                if (Cursor == Cursors.Hand)
                {
                    Cursor = Cursors.Default;
                    c1SuperTooltip1.RemoveAll();
                }
            }
        }

        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            //Handle Hyperlink click
            if (Cursor == Cursors.Hand)
            {
                HitTestInfo ht = c1FlexGrid1.HitTest(e.X, e.Y);
                if (ht.Type == HitTestTypeEnum.Cell)
                {
                    FlexHyperlink link = c1FlexGrid1[ht.Row, ht.Column] as FlexHyperlink;
                    if (link != null)
                        link.Activate();
                }
            }
        }

        private void c1FlexGrid1_SetupEditor(object sender, RowColEventArgs e)
        {
            if (e.Col == _largeTextCol)
            {
                //Set size of large text box editor
                c1FlexGrid1.Cols[e.Col].Editor.Size = new Size(250, 100);
            }
            
        }     

    }

    #region ** UITypeEditorControl (base class for all of the controls below)

    /// <summary>
    /// UITypeEditorControl
    /// </summary>
    public class UITypeEditorControl :
        ComboBox,
        IServiceProvider,
        IWindowsFormsEditorService
    {
        //===========================================================================
        #region ** fields
        private UITypeEditor _editor;	// UITypeEditor responsible for editing the values
        private Form _form;		// form used to show the drop down
        private Rectangle _bounds;	// cell bounds (used to position control and form)
        private object _value;		// current editor value 
        private bool _dropped;	// whether the drop down was displayed
        private bool _allowTyping;	// whether to allow user to edit the string representation of the value
        #endregion

        //===========================================================================
        #region ** ctor

        public UITypeEditorControl(UITypeEditor editor, bool allowTyping)
        {
            // save ctor parameters
            _editor = editor;
            _allowTyping = allowTyping;

            // initialize combo
            DropDownStyle = ComboBoxStyle.DropDown;
            DrawMode = DrawMode.OwnerDrawFixed;

            // initialize drop down editor
            _form = new Form();
            _form.StartPosition = FormStartPosition.Manual;
            _form.FormBorderStyle = FormBorderStyle.None;
            _form.ShowInTaskbar = false;
            _form.TopLevel = true;
            _form.Deactivate += new EventHandler(_form_Deactivate);
        }
        #endregion

        //===========================================================================
        #region ** IC1EmbeddedEditor

        public void C1EditorInitialize(object value, IDictionary attributes)
        {
            // initialize editor value
            _value = value;
            if (value != null)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(value.GetType());
                try
                {
                    Text = (string)tc.ConvertToString(value);
                }
                catch
                {
                    Text = string.Empty;
                }
            }

            // initialize editor style
            Font = (Font)attributes["Font"];
            BackColor = (Color)attributes["BackColor"];
            ForeColor = (Color)attributes["ForeColor"];

            // we haven't dropped the editor yet
            _dropped = false;
        }
        public object C1EditorGetValue()
        {
            // return value from drop down or from edit area
            return (_dropped) ? _value : Text;
        }
        public UITypeEditorEditStyle C1EditorGetStyle()
        {
            return _editor.GetEditStyle();
        }
        public void C1EditorUpdateBounds(Rectangle rc)
        {
            // store bounds, will apply when showing the form
            _bounds = Parent.RectangleToScreen(rc);

            // if the user can type, position the combo
            if (_allowTyping)
            {
                rc.Inflate(2, 2);
                ItemHeight = Math.Max(3, rc.Height - 6);
                Bounds = rc;
            }
            else // can't type, so hide the control
            {
                Bounds = Rectangle.Empty;
            }
        }

        #endregion

        //===========================================================================
        #region ** overrides

        // if the user can't type, show drop down right away
        override protected void OnEnter(EventArgs e)
        {
            if (!_allowTyping)
                DoDropDown();
        }

        // if the user can type, show drop down when requested
        override protected void OnDropDown(EventArgs e)
        {
            if (_allowTyping)
                DoDropDown();
        }

        // suppress OnLeave event until we're done editing
        override protected void OnLeave(EventArgs e)
        {
            // if we dropped down, wait until we're done editing
            if (_dropped)
                return;

            // we didn't drop down, allow default processing
            base.OnLeave(e);
        }

        // this is done only to avoid annoying beeps from the ComboBox
        override public bool PreProcessMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case 0x100: // WM_KEYDOWN:

                    // digest key that was pressed
                    KeyEventArgs e = new KeyEventArgs((Keys)(int)msg.WParam);

                    // if it was a tab or enter, handle internally but don't pass
                    // to stupid base class to avoid annoying beeps.
                    switch (e.KeyCode)
                    {
                        case Keys.Tab:
                        case Keys.Enter:
                        case Keys.Escape:
                            OnKeyDown(e);
                            return true;
                    }
                    break;
            }

            // allow regular processing
            return false;
        }
        #endregion

        //===========================================================================
        #region ** private members

        private void DoDropDown()
        {
            // fire event as usual
            base.OnDropDown(EventArgs.Empty);

            // if this is a popup, hide editing area
            if (_editor.GetEditStyle() == UITypeEditorEditStyle.Modal)
                Bounds = Rectangle.Empty;

            // show editor and get the new value
            _dropped = true;
            _value = _editor.EditValue((IServiceProvider)this, _value);

            // force the drop down to close
            DrawMode = DrawMode.Normal;
            DrawMode = DrawMode.OwnerDrawFixed;
            DroppedDown = false;
            Capture = false;

            // fire OnLeave so grid knows we're done
            base.OnLeave(EventArgs.Empty);
        }

        #endregion

        //===========================================================================
        #region ** event handlers

        // close drop down when form deactivated
        private void _form_Deactivate(object sender, EventArgs e)
        {
            ((IWindowsFormsEditorService)this).CloseDropDown();
        }

        #endregion

        //===========================================================================
        #region ** IServiceProvider interface

        object IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(IWindowsFormsEditorService))
                return (IWindowsFormsEditorService)this;
            return null;
        }

        #endregion

        //===========================================================================
        #region ** IWindowsFormsEditorService interface

        void IWindowsFormsEditorService.DropDownControl(Control control)
        {
            // size form
            _form.ClientSize = control.Size;

            // calculate form location to avoid being off the screen
            Point pt = new Point(_bounds.Right - control.Width, _bounds.Bottom);
            Rectangle rc = Screen.GetWorkingArea(this);
            if (_bounds.Bottom + control.Height > rc.Bottom)	// check bottom
                pt.Y = _bounds.Top - _form.Height;
            if (pt.Y < 0) pt.Y = 0;					// check top
            if (_bounds.X + control.Width > rc.Right)		// check right
                pt.X = rc.Right - _form.Width;
            if (pt.X < 0) pt.X = 0;					// check left

            // position form
            _form.Location = pt;

            // add control to form and show it
            _form.Controls.Add(control);
            _form.Show();

            // readjust form size (seems redundant, but isn't...)
            _form.ClientSize = control.Size;

            // wait until user makes a selection
            while (control.Visible)
            {
                Application.DoEvents();
                MsgWaitForMultipleObjects(1, IntPtr.Zero, 0, 5, 255);
            }

            // done
            _form.Hide();
            _form.Controls.Clear();
        }
        void IWindowsFormsEditorService.CloseDropDown()
        {
            _form.Hide();
        }
        DialogResult IWindowsFormsEditorService.ShowDialog(Form dialog)
        {
            // support modal editors
            return dialog.ShowDialog();
        }

        #endregion

        //===========================================================================
        #region ** dll imports

        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int MsgWaitForMultipleObjects(
            int nCount, IntPtr pHandles, short bWaitAll, int dwMilliseconds, int dwWakeMask);

        #endregion
    }
    #endregion

    #region ** CheckListEditor
    //
    // CheckListEditor
    // UITypeEditor that can be used to edit items in CheckedListBox control.
    // Users can check any combination.
    // 
    public class CheckListEditor : UITypeEditor
    {
        // ** fields
        private IWindowsFormsEditorService _edSvc;
        private CheckedListBox _list;
        private string[] _items;
        private bool _cancel;

        // ** ctor
        public CheckListEditor(string[] items)
        {
            // store reference to items being edited
            _items = items;

            // build selector list
            _list = new CheckedListBox();
            _list.BorderStyle = BorderStyle.Fixed3D;
            _list.CheckOnClick = true;
            _list.ThreeDCheckBoxes = false;
            _list.KeyPress += new KeyPressEventHandler(_list_KeyPress);
        }

        // ** overrides
        override public UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext ctx)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        override public object EditValue(ITypeDescriptorContext ctx, IServiceProvider provider, object value)
        {
            // initialize editor service
            _edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (_edSvc == null)
                return value;

            // null means no flags are checked
            if (value == null)
                value = 0;

            // populate the list
            _list.Items.Clear();
            string items = value.ToString();
            foreach (string item in _items)
            {
                // add this item with the proper check state
                CheckState check = items.Contains(item) ? CheckState.Checked : CheckState.Unchecked;
                _list.Items.Add(item, check);
            }
            _list.Height = Math.Min(300, (_list.Items.Count + 1) * _list.Font.Height);
            _list.Width = 150;

            // show the list
            _cancel = false;
            _edSvc.DropDownControl(_list);

            // build return value from checked items on the list
            if (!_cancel)
            {
                // build a comma-delimited string with the checked items
                StringBuilder sb = new StringBuilder();
                foreach (object item in _list.CheckedItems)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(item.ToString());
                }

                // convert empty string
                return (sb.Length > 0) ? sb.ToString() : "None/Other";
            }

            // done
            return value;
        }

        // ** event handlers

        // close editor if the user presses enter or escape
        private void _list_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)27:
                    _cancel = true;
                    _edSvc.CloseDropDown();
                    break;
                case (char)13:
                    _edSvc.CloseDropDown();
                    break;
            }
        }
    }
    #endregion

    #region ** ImagePicker

    /// <summary>
    /// ImagePicker
    /// Uses the Image UITypeEditor to show a form where users can pick images
    /// </summary>
    //public class ImagePicker : UITypeEditorControl
    //{
    //    public ImagePicker() : base(new Control(), false) { }
    //}
    #endregion

    #region ** ColorPicker

    /// <summary>
    /// ColorPicker
    /// Uses the Color UITypeEditor to show a form where users can pick colors
    /// </summary>
    //public class ColorPicker : UITypeEditorControl
    //{
    //    //public ColorPicker() : base(new ColorEditor(), true) { }
    //}
    #endregion

    #region ** FlexHyperlink class

    public class FlexHyperlink
    {
        string _text;
        string _link;
        bool _visited;

        public FlexHyperlink(string text, string link)
        {
            _text = text;
            _link = link;
            _visited = false;
        }
        public bool Visited
        {
            get { return _visited; }
        }
        public string Url
        {
            get { return _link; }
        }
        public Process Activate()
        {
            _visited = true;
            return Process.Start(_link);
        }
        override public string ToString()
        {
            return _text;
        }
    }

#endregion

}
