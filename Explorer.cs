using C1.Win.C1Ribbon;
using ControlExplorer.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using C1.Win.C1Themes;
using System.Xml.Linq;

namespace ControlExplorer
{
    public partial class Explorer : C1RibbonForm
    {
        //===================================================================================//
        #region fields
        private static readonly object locker = new object();
        private bool tileLayoutCompleted = false;
        private int tileColumns = 0;
        private C1DemoViewer _viewer = null;
        private C1DemoForm _activeForm;
        private FlatIconList _icons = new FlatIconList();
        private Image _controlNewOverlay = Properties.Resources.New;
        private ExplorerMode explorerMode;

        #endregion
        //===================================================================================//
        #region properties

        public ExplorerMode CurrentExplorerMode
        {
            get
            {
                return explorerMode;
            }
            set
            {
                explorerMode = value;
                switch (explorerMode)
                {
                    case ExplorerMode.Suite:
                        pnlMainSamples.Visible = false;
                        pnlMainControls.Visible = true;
                        pnlLeftSamples.Visible = false;
                        pnlLeftControls.Visible = true;
                        break;
                    case ExplorerMode.Controls:
                        pnlMainSamples.Visible = true;
                        pnlMainControls.Visible = false;
                        pnlLeftSamples.Visible = true;
                        pnlLeftControls.Visible = false;
                        break;
                    case ExplorerMode.Samples:
                        pnlMainSamples.Visible = true;
                        pnlMainControls.Visible = false;
                        pnlLeftSamples.Visible = true;
                        pnlLeftControls.Visible = false;
                        break;
                }
            }
        }

        public static Explorer TheExplorer { get; private set; }

        #endregion
        //===================================================================================//
        public Explorer()
        {
            Properties.Settings.Default.SettingsLoaded += Default_SettingsLoaded;
            foreach (KeyValuePair<string, Image> icon in StyleInfo.ControlIcons)
            {
                _icons.Add(icon.Key, icon.Value);
            }
            _icons.Add("ControlOverlay", _controlNewOverlay);
            InitializeComponent();
            TheExplorer = this;
            _viewer = new C1DemoViewer();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            CurrentExplorerMode = ExplorerMode.Suite;
            breadCrumb.Home.Tag = ExplorerMode.Suite;
            breadCrumb.HomeImage = Properties.Resources.home24;
            featureStack.AutoWidth = true;
        }
        //===================================================================================//
        #region Load Samples and Controls

        private void LoadControlTiles()
        {
            tilesPopular.Groups[0].Tiles.Clear();
            tilesNew.Groups[0].Tiles.Clear();
            tilesControlUtil.Groups[0].Tiles.Clear();
            cteUtil.Text = "系统提示工具";
            tilesControlDV.Groups[0].Tiles.Clear();
            ctelDV.Text = "数据可视化";
            tilesControlNaL.Groups[0].Tiles.Clear();
            cteNaL.Text = "导航和布局";
            tilesControlIaE.Groups[0].Tiles.Clear();
            cteIaE.Text = "输入和编辑";
            tilesControlRaD.Groups[0].Tiles.Clear();
            cteRaD.Text = "报表和文档";
            tilesControlGDM.Groups[0].Tiles.Clear();
            cteGDM.Text = "表格数据管理";
            tilesControlSch.Groups[0].Tiles.Clear();
            cteSch.Text = "日程安排";

            foreach (ControlInfo.ControlData control in ControlInfo.Controls)
            {
                C1.Win.C1Tile.Tile controlTile = new C1.Win.C1Tile.Tile();
                controlTile.Text = control.Name;
                controlTile.Image = control.Icon;
                controlTile.Template = template2;
                controlTile.Tag = control;
                if (control.IsNew)
                {
                    controlTile.Template = template2;
                    controlTile.Image1 = _icons["ControlOverlay"].Image;

                    C1.Win.C1Tile.Tile newTile = new C1.Win.C1Tile.Tile();
                    newTile.Text = control.Name;
                    newTile.Image = control.Icon;
                    //newTile.Image1 = _icons["ControlOverlay"].Image;
                    newTile.Tag = control;
                    tilesNew.Groups[0].Tiles.Add(newTile);
                }
                if (control.IsPopular)
                {
                    C1.Win.C1Tile.Tile newTile = new C1.Win.C1Tile.Tile();
                    newTile.Text = control.Name;
                    newTile.Image = control.Icon;
                    newTile.Tag = control;
                    tilesPopular.Groups[0].Tiles.Add(newTile);
                }
                switch (control.Group)
                {
                    case "Utilities":
                        tilesControlUtil.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Data Visualization":
                        tilesControlDV.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Navigation and Layout":
                        tilesControlNaL.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Input and Editing":
                        tilesControlIaE.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Reporting and Documents":
                        tilesControlRaD.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Grids and Data Management":
                        tilesControlGDM.Groups[0].Tiles.Add(controlTile);
                        break;
                    case "Scheduling":
                        tilesControlSch.Groups[0].Tiles.Add(controlTile);
                        break;
                }
            }
            UpdateTileLayout();
            tileLayoutCompleted = true;
            if (tilesNew.Groups[0].Tiles.Count == 0)
            {
                tilesNew.Parent.Visible = false;
            }
            if (tilesPopular.Groups[0].Tiles.Count == 0)
            {
                tilesPopular.Parent.Visible = false;
            }
        }
        private void UpdateTileLayout()
        {
            lock (locker)
            {
                int width = pnlMainControls.Width;
                int widthofeachpanel = 122;
                int spacing = 10;
                int heightofeachpanel = 122;
                int topandbottompadding = 20 + 20;
                int noofCols = width / (widthofeachpanel + spacing);

                if (noofCols > 0)
                {
                    if (noofCols != tileColumns)
                    {
                        tileColumns = noofCols;
                        int i = 0;
                        Dictionary<C1.Win.C1Tile.C1TileControl, ControlTreeExpander> tiles 
                            = new Dictionary<C1.Win.C1Tile.C1TileControl, ControlTreeExpander>()
                        {
                            { tilesControlUtil,cteUtil },
                            { tilesControlDV,ctelDV},
                            { tilesControlNaL,cteNaL},
                            { tilesControlIaE,cteIaE},
                            { tilesControlRaD,cteRaD},
                            { tilesControlGDM,cteGDM },
                            { tilesControlSch,cteSch }
                        };
                        foreach (KeyValuePair<C1.Win.C1Tile.C1TileControl, ControlTreeExpander> tileControl in tiles)
                        {
                            tileControl.Value.ChildCollapsedHeight = 20;
                            i = 0;
                            int k = 0;
                            foreach (var tile in tileControl.Key.Groups[0].Tiles)
                            {
                                tile.LeftCell = (i % noofCols) + 1;
                                tile.TopCell = (i / noofCols) + 1;
                                k = k < tile.TopCell ? tile.TopCell : k;
                                i++;
                            }
                            int Height = topandbottompadding + k * (heightofeachpanel + spacing) - spacing;
                            tileControl.Value.ChildExpandedHeight = Height;
                        }
                    }
                }
            }
        }

        private void loadControl(ControlInfo.ControlData control)
        {
            if (control != null)
            {
                TheExplorer.CurrentExplorerMode = ExplorerMode.Controls;
                if (breadCrumb.Items.Count == 1)
                {
                    BreadCrumbItem item = breadCrumb.AddItem(control.Name);
                    item.Tag = ExplorerMode.Controls;
                    lblLeftDescriptionSamplesTitle.Text = control.Name;
                    loadSamples(control);
                }
            }
        }

        private void loadSamples(ControlInfo.ControlData control)
        {
            if (control != null)
            {
                if (control.Samples.Count > 0)
                {
                    featureStack.Items.Clear();
                    foreach (ControlInfo.SampleData sample in control.Samples)
                    {
                        FeatureStackItem item = featureStack.AddItem(sample.Name);
                        item.Tag = sample;
                    }
                    featureStack.SelectItem(featureStack.Items.First());
                    loadSample(control.Samples.First());
                }
            }
        }

        private void loadSample(ControlInfo.SampleData sample)
        {
            if (sample != null)
            {
                if (breadCrumb.Items.Count == 2)
                {
                    BreadCrumbItem item = breadCrumb.AddItem(sample.Name);
                    item.Tag = ExplorerMode.Samples;
                }
                else
                {
                    breadCrumb.RemoveTop();
                    BreadCrumbItem item = breadCrumb.AddItem(sample.Name);
                    item.Tag = ExplorerMode.Samples;
                }
                string description = sample.LongDescription;
                if (description == null || description == "")
                {
                    description = sample.ShortDescription;
                }
                lblLeftDescriptionSamples.Text = description;
                loadSampleForm(sample);
                TheExplorer.CurrentExplorerMode = ExplorerMode.Samples;
            }
        }

        private void loadSampleForm(ControlInfo.SampleData sample)
        {
            DemoForm d = new DemoForm(sample.FormName, sample.LongDescription);
            this.Cursor = Cursors.AppStarting;
            _activeForm = _viewer.Run(d.FormName, sample.Name, d.Description);
            this.Attach(_viewer);
            this.Cursor = Cursors.Default;
        }

        internal void loadSampleForm(string formName, string title, string desc)
        {
            this.Cursor = Cursors.AppStarting;
            _activeForm = _viewer.Run(formName, title, desc);
            this.Attach(_viewer);
            this.Cursor = Cursors.Default;
        }

        private void Attach(C1DemoViewer _viewer)
        {
            Control.ControlCollection collection = pnlMainSamples.Controls;
            if (_viewer == null)
            {
                collection.Clear();
                return;
            }

            if (!collection.Contains(_viewer))
            {
                collection.Clear();
                collection.Add(_viewer);
                _viewer.Dock = DockStyle.Fill;
                _viewer.Visible = true;
            }
        }

        #endregion
        //===================================================================================//
        #region Theming
        static string themeName;

        public static string ThemeName
        {
            get
            {
                return themeName;
            }
            set
            {
                if (themeName != value)
                {
                    themeName = value;
                }
            }
        }

        public static C1Theme Theme
        {
            get
            {
                if (!string.IsNullOrEmpty(ThemeName))
                    return C1.Win.C1Themes.C1ThemeController.GetThemeByName(ThemeName, false);
                else
                    return null;
            }
        }

        public static void ApplyTheme(Control control)
        {
            var theme = Theme;
            if (theme != null)
            {
                if (control == TheExplorer)
                {
                    // color all icons according to the new loaded theme
                    Color foreground = Theme.GetColor(@"BaseThemeProperties\ControlText");
                    bool needUpdateIcons = foreground != TheExplorer._icons.Foreground;
                    if (needUpdateIcons)
                    {
                        TheExplorer._icons.Foreground = foreground;
                        // Data Visualization group
                        for (int i = 0; i < TheExplorer.tilesControlDV.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlDV.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Grids and Data Management group
                        for (int i = 0; i < TheExplorer.tilesControlGDM.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlGDM.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Input and Editing group
                        for (int i = 0; i < TheExplorer.tilesControlIaE.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlIaE.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Navigation and Layout group
                        for (int i = 0; i < TheExplorer.tilesControlNaL.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlNaL.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Reporting and Documents group
                        for (int i = 0; i < TheExplorer.tilesControlRaD.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlRaD.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Scheduling group
                        for (int i = 0; i < TheExplorer.tilesControlSch.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlSch.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                        // Utilities group
                        for (int i = 0; i < TheExplorer.tilesControlUtil.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesControlUtil.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }

                        for (int i = 0; i < TheExplorer.tilesNew.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesNew.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }

                        for (int i = 0; i < TheExplorer.tilesPopular.Groups[0].Tiles.Count; ++i)
                        {
                            var tile = TheExplorer.tilesPopular.Groups[0].Tiles[i];
                            if (tile.Image1 != null) //= _controlNewOverlay;
                                tile.Image1 = TheExplorer._icons["ControlOverlay"].Image;
                            ControlInfo.ControlData cnt = tile.Tag as ControlInfo.ControlData;
                            tile.Image = TheExplorer._icons[cnt.Name].Image;
                        }
                    }
                }

                if (control.FindForm() == TheExplorer)
                {
                    // Controls that rely on specific colors to be visible/usable:
                    List<Control> noTheming = new List<Control>()
                    {

                    };
                    C1ThemeController.ApplyThemeToControlTree(control, theme, (c) => !noTheming.Contains(c));
                }
                else
                    C1ThemeController.ApplyThemeToControlTree(control, theme);

                // Style non themable controls for uniformity
                StyleForNonThemableControls();
            }
        }

        private static void StyleForNonThemableControls()
        {
            #region get font and colors from existing theme
            Font newFont = Theme.GetFont(@"BaseThemeProperties\ControlText", null);
            Color newFormBackColor = TheExplorer.tilesControlDV.BackColor;

            Color c = Color.Transparent;
            c = Theme.GetColor(@"C1TileControl\Tiles\TileBackColor", Color.Transparent);
            Color OpaqueTileTileBackColor = Color.FromArgb(c.R, c.G, c.B);

            c = Theme.GetColor(@"C1TileControl\Common\BackColor", Color.Transparent);
            Color OpaqueTileBackColor = Color.FromArgb(c.R, c.G, c.B);

            c = Theme.GetColor(@"C1TileControl\Common\ForeColor", Color.Transparent);
            Color OpaqueTileForeColor = Color.FromArgb(c.R, c.G, c.B);

            c = Theme.GetColor(@"C1TileControl\Tiles\CheckMarkColor", Color.Transparent);
            Color OpaqueTileCheckMarkColor = Color.FromArgb(c.R, c.G, c.B);

            c = Theme.GetColor(@"C1TileControl\Tiles\CheckBorderColor", Color.Transparent);
            Color OpaqueTileCheckBorderColor = Color.FromArgb(c.R, c.G, c.B);

            c = Theme.GetColor(@"C1TileControl\Tiles\HotBorderColor", Color.Transparent);
            Color OpaqueTileHotBorderColor = Color.FromArgb(c.R, c.G, c.B);
            #endregion

            // Apply background containers adn controls to blend with form
            TheExplorer.pnlHeaderLogo.BackColor = newFormBackColor;
            TheExplorer.pbMainLogo.BackColor = newFormBackColor;
            TheExplorer.pnlHeaderTop.BackColor = newFormBackColor;
            TheExplorer.pnlLeftControls.BackColor = newFormBackColor;
            TheExplorer.pnlMainTopGutter.BackColor = newFormBackColor;
            TheExplorer.lblLeftDescriptionControls.BackColor = newFormBackColor;
            TheExplorer.lblNewControls.BackColor = newFormBackColor;
            TheExplorer.lblPopularControls.BackColor = newFormBackColor;
            TheExplorer.pnlMainGutter.BackColor = newFormBackColor;
            TheExplorer.pnlMainControls.BackColor = newFormBackColor;
            TheExplorer.pnlLeftSamples.BackColor = newFormBackColor;
            TheExplorer.lblLeftDescriptionSamplesTitle.BackColor = newFormBackColor;
            TheExplorer.lblLeftDescriptionSamples.BackColor = newFormBackColor;
            TheExplorer.lblLeftSamplesListTitle.BackColor = newFormBackColor;
            TheExplorer.pnlMainSamples.BackColor = newFormBackColor;
            TheExplorer._viewer.BackColor = newFormBackColor;

            // Apply style to title labels
            if (newFont != null)
            {
                TheExplorer.lblFree.Font = new Font(newFont, FontStyle.Bold);
            }

            StyleInfo.LabelNormalBackColor = OpaqueTileTileBackColor;
            StyleInfo.LabelNormalForeColor = GetFarthestColor(OpaqueTileTileBackColor, new Color[] { OpaqueTileForeColor, OpaqueTileCheckMarkColor });

            StyleInfo.HoverLabelNormalBackColor = OpaqueTileCheckBorderColor;
            StyleInfo.HoverLabelNormalForeColor = GetFarthestColor(OpaqueTileCheckBorderColor, new Color[] { OpaqueTileHotBorderColor, OpaqueTileCheckMarkColor });


            foreach (Control sender in new Control[] { TheExplorer.lblAbout, TheExplorer.lblPricing, TheExplorer.lblSupport, TheExplorer.lblFree })
            {
                if ((sender as Label).Tag != null && (sender as Label).Tag.ToString() == "Highlight")
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelHighlightForeColor;
                }
                else
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelNormalForeColor;
                }
            }

            TheExplorer.pnlHeaderMid.BackColor = OpaqueTileTileBackColor == Color.Transparent ? TheExplorer.pnlHeaderMid.BackColor : OpaqueTileTileBackColor;
            TheExplorer.pnlHeaderMid.ForeColor = OpaqueTileForeColor == Color.Transparent ? TheExplorer.pnlHeaderMid.ForeColor : OpaqueTileForeColor;

            TheExplorer.lblMainTitle.BackColor = OpaqueTileTileBackColor == Color.Transparent ? TheExplorer.lblMainTitle.BackColor : OpaqueTileTileBackColor;
            TheExplorer.lblMainTitle.ForeColor = OpaqueTileForeColor == Color.Transparent ? TheExplorer.lblMainTitle.ForeColor : OpaqueTileForeColor;

            TheExplorer.pnlHeaderMidTitle.BackColor = OpaqueTileTileBackColor == Color.Transparent ? TheExplorer.pnlHeaderMidTitle.BackColor : OpaqueTileTileBackColor;
            TheExplorer.pnlHeaderMidTitle.ForeColor = OpaqueTileForeColor == Color.Transparent ? TheExplorer.pnlHeaderMidTitle.ForeColor : OpaqueTileForeColor;

            // Apply style to breadcrumb
            Color bccolor1 = OpaqueTileTileBackColor == Color.Transparent ? TheExplorer.pnlHeaderMid.BackColor : OpaqueTileTileBackColor;
            Color bcforecolor = OpaqueTileForeColor == Color.Transparent ? TheExplorer.pnlHeaderMid.ForeColor : OpaqueTileForeColor;
            Color bccolor2 = OpaqueTileCheckBorderColor == Color.Transparent ? TheExplorer.breadCrumb.BackColor : OpaqueTileCheckBorderColor;
            Color bcforecolor2 = OpaqueTileCheckMarkColor == Color.Transparent ? TheExplorer.breadCrumb.ForeColor : OpaqueTileCheckMarkColor;

            if (newFont != null)
            {
                TheExplorer.breadCrumb.Font = new Font(newFont.FontFamily, TheExplorer.breadCrumb.Font.Size);
            }

            TheExplorer.breadCrumb.BackColor = bccolor1;
            TheExplorer.breadCrumb.BackColor2 = bccolor2;
            TheExplorer.breadCrumb.ForeColor = bcforecolor; 
            TheExplorer.breadCrumb.ForeColor2 = bcforecolor2; 
            TheExplorer.breadCrumb.Parent.BackColor = newFormBackColor;


            // Apply style to feature stack
            Color fsHoverBackColor = OpaqueTileCheckBorderColor == Color.Transparent ? TheExplorer.featureStack.HoverBackColor : OpaqueTileCheckBorderColor;
            Color fsSelectedBackColor = OpaqueTileCheckBorderColor == Color.Transparent ? TheExplorer.featureStack.SelectedBackColor : OpaqueTileCheckBorderColor;
            Color fsHoverForeColor = OpaqueTileCheckMarkColor == Color.Transparent ? TheExplorer.featureStack.HoverForeColor : OpaqueTileCheckMarkColor;
            Color fsSelectedForeColor = OpaqueTileCheckMarkColor == Color.Transparent ? TheExplorer.featureStack.SelectedForeColor : OpaqueTileCheckMarkColor;
            Color fsForeColor = OpaqueTileCheckBorderColor == Color.Transparent ? TheExplorer.featureStack.ForeColor : OpaqueTileCheckBorderColor;
            Color fsBackColor = newFormBackColor == Color.Transparent ? TheExplorer.featureStack.BackColor : newFormBackColor;

            if (newFont != null)
            {
                TheExplorer.featureStack.Font = new Font(newFont.FontFamily, TheExplorer.featureStack.SelectedFont.Size);
                TheExplorer.featureStack.SelectedFont = new Font(newFont.FontFamily, TheExplorer.featureStack.SelectedFont.Size, FontStyle.Bold);
            }

            TheExplorer.featureStack.HoverBackColor = fsHoverBackColor;
            TheExplorer.featureStack.HoverForeColor = fsHoverForeColor;

            TheExplorer.featureStack.SelectedBackColor = fsSelectedBackColor;
            TheExplorer.featureStack.SelectedForeColor = fsSelectedForeColor;
            
            TheExplorer.featureStack.BackColor = fsBackColor;
            TheExplorer.featureStack.ForeColor = fsForeColor;


            // Apply background to controlexpanders
            TheExplorer.cteGDM.BackColor = TheExplorer.cteIaE.BackColor 
                = TheExplorer.ctelDV.BackColor = TheExplorer.cteNaL.BackColor 
                = TheExplorer.cteRaD.BackColor = TheExplorer.cteSch.BackColor
                = TheExplorer.cteUtil.BackColor 
                = OpaqueTileTileBackColor == Color.Transparent ? TheExplorer.pnlHeaderMid.BackColor : OpaqueTileTileBackColor;

            // Apply foreground to controlexpanders
            TheExplorer.cteGDM.ForeColor = TheExplorer.cteIaE.ForeColor
                = TheExplorer.ctelDV.ForeColor = TheExplorer.cteNaL.ForeColor
                = TheExplorer.cteRaD.ForeColor = TheExplorer.cteSch.ForeColor
                = TheExplorer.cteUtil.ForeColor = TheExplorer.lblNewControls.ForeColor;



        }

        #region Color Utility

        public static Color GetFarthestColor(Color backColor, Color[] foreColors)
        {
            int c = Convert.ToInt16(backColor.R) + Convert.ToInt16(backColor.G) + Convert.ToInt16(backColor.B);
            Dictionary<Color, int> ColorDistance = new Dictionary<Color, int>();
            foreach(Color option in foreColors.Distinct())
            {
                int o = Convert.ToInt16(option.R) + Convert.ToInt16(option.G) + Convert.ToInt16(option.B);
                int val = (int)Math.Sqrt(Math.Pow(c - o, 2));
                ColorDistance.Add(option, val);
            }
            return ColorDistance.Aggregate((c1, c2) => c1.Value > c2.Value ? c1 : c2).Key;

        }
        
        #endregion

        private void cmbTheme_DropDown(object sender, EventArgs e)
        {
            cmbTheme.Items.Clear();
            string[] themes = C1ThemeController.GetThemes();
            var showThemes = themes.Where((tn) =>
            {
                var ltn = tn.ToLower();
                if (ltn.Contains("visualstyle")) // avoid old "visual style" themes
                    return false;
                else
                    return true;
            });
            foreach (string theme in showThemes)
                cmbTheme.Items.Add(new C1.Win.C1InputPanel.InputOption(theme));
        }

        private void cmbTheme_ChangeCommitted(object sender, EventArgs e)
        {
            this.SuspendPainting();
            C1Theme theme = null;
            try
            {
                theme = C1ThemeController.GetThemeByName(cmbTheme.Text, false);
            }
            catch
            {

            }
            if (theme != null)
                ThemeName = theme.Name;
            else
                ThemeName = string.Empty;
            ApplyTheme(this);
            this.ResumePainting();
        }

        private static void LoadDefaultStyle()
        {
            TheExplorer.lblMainTitle.BackColor = StyleInfo.TitleBackColor;
            TheExplorer.pnlHeaderMidTitle.BackColor = StyleInfo.TitleBackColor;
            TheExplorer.pnlHeaderMid.BackColor = StyleInfo.TitleBackColor;
            TheExplorer.lblAbout.BackColor = StyleInfo.LabelNormalBackColor;
            TheExplorer.lblSupport.BackColor = StyleInfo.LabelNormalBackColor;
            TheExplorer.lblPricing.BackColor = StyleInfo.LabelNormalBackColor;
            TheExplorer.breadCrumb.BackColor = StyleInfo.BreadcrumbColor1;
            TheExplorer.breadCrumb.BackColor2 = StyleInfo.BreadcrumbColor2;
            TheExplorer.breadCrumb.ForeColor = StyleInfo.BreadcrumbForeColor;
            TheExplorer.breadCrumb.ForeColor2 = StyleInfo.BreadcrumbForeColor2;
            TheExplorer.lblLeftDescriptionSamples.ForeColor = StyleInfo.FeatureDescriptionForeColor;
            TheExplorer.featureStack.ForeColor = StyleInfo.FeatureListForeColor;
            TheExplorer.featureStack.BackColor = TheExplorer.featureStack.Parent.BackColor;
            TheExplorer.featureStack.SelectedForeColor = StyleInfo.FeatureListSelectedForeColor;
            TheExplorer.featureStack.SelectedBackColor = StyleInfo.FeatureListSelectedBackColor;
            TheExplorer.featureStack.HoverForeColor = StyleInfo.FeatureListHoverForeColor;
            TheExplorer.featureStack.HoverBackColor = StyleInfo.FeatureListHoverBackColor;
        }

        #endregion
        //===================================================================================//
        #region Events and Methods

        private void Explorer_Load(object sender, EventArgs e)
        {
            #region ReadControlXML

            XElement elem = XDocument.Load("C1Controls.xml").Root;
            int pageIndex = 0;
            ControlInfo.Controls = new List<ControlInfo.ControlData>();
            foreach (XElement controlNode in elem.Descendants("control").ToList())
            {
                ControlInfo.ControlData control = new ControlInfo.ControlData();
                if (controlNode.Attribute("name") != null)
                {
                    control.Name = controlNode.Attribute("name").Value;
                }
                if (controlNode.Attribute("group") != null)
                {
                    control.Group = controlNode.Attribute("group").Value;
                }
                if (controlNode.Attribute("status") != null)
                {
                    foreach (string val in controlNode.Attribute("status").Value.Split(','))
                    {
                        switch (val)
                        {
                            case "new":
                                control.IsNew = true;
                                break;
                            case "popular":
                                control.IsPopular = true;
                                break;
                        }
                    }
                }
                else
                {
                    control.IsNew = false;
                    control.IsPopular = false;
                }
                control.Icon = _icons[control.Name].Image;
                control.Samples = new List<ControlInfo.SampleData>();
                foreach (XElement sampleNode in controlNode.Descendants("sample"))
                {
                    ControlInfo.SampleData sample = new ControlInfo.SampleData();
                    if (sampleNode.Attribute("name") != null)
                    {
                        sample.Name = sampleNode.Attribute("name").Value;
                    }
                    if (sampleNode.Attribute("form") != null)
                    {
                        sample.FormName = sampleNode.Attribute("form").Value;
                    }
                    if (sampleNode.Attribute("short") != null)
                    {
                        sample.ShortDescription = sampleNode.Attribute("short").Value;
                    }
                    if (sampleNode.Attribute("description") != null)
                    {
                        sample.LongDescription = sampleNode.Attribute("description").Value.Replace("\\r\\n", "\r\n");
                    }
                    if (sampleNode.Attribute("status") != null)
                    {
                        sample.IsNew = (sampleNode.Attribute("status").Value == "new") ? true : false;
                    }
                    else
                    {
                        sample.IsNew = false;
                    }
                    control.Samples.Add(sample);
                }
                ControlInfo.Controls.Add(control);
                pageIndex++;
            }

            #endregion

            LoadDefaultString();
            LoadDefaultStyle();
            LoadControlTiles();
        }

        private void Default_SettingsLoaded(object sender, SettingsLoadedEventArgs e)
        {
            cmbTheme.Items.Clear();
            cmbTheme.Items.Add(new C1.Win.C1InputPanel.InputOption(ThemeName));
            cmbTheme.SelectedIndex = 0;
            ApplyTheme(this);
        }

        private void LoadDefaultString()
        {
            lblLeftDescriptionControls.Text = StringInfo.SuiteDescription;
        }

        private void taskLabels_MouseEnter(object sender, EventArgs e)
        {
            if (cmbTheme.SelectedIndex == -1)
            {
                if ((sender as Label).Tag != null && (sender as Label).Tag.ToString() == "Highlight")
                {
                    (sender as Label).Parent.BackColor = StyleInfo.HoverLabelHighlightBackColor;
                    (sender as Label).BackColor = StyleInfo.HoverLabelHighlightBackColor;
                    (sender as Label).ForeColor = StyleInfo.HoverLabelHighlightForeColor;
                }
                else
                {
                    (sender as Label).Parent.BackColor = StyleInfo.HoverLabelNormalBackColor;
                    (sender as Label).BackColor = StyleInfo.HoverLabelNormalBackColor;
                    (sender as Label).ForeColor = StyleInfo.HoverLabelNormalForeColor;
                }
            }
            else
            {
                if ((sender as Label).Tag != null && (sender as Label).Tag.ToString() == "Highlight")
                {
                    (sender as Label).Parent.BackColor = StyleInfo.HoverLabelHighlightBackColor;
                    (sender as Label).BackColor = StyleInfo.HoverLabelHighlightBackColor;
                    (sender as Label).ForeColor = StyleInfo.HoverLabelHighlightForeColor;
                }
                else
                {
                    (sender as Label).Parent.BackColor = StyleInfo.HoverLabelNormalBackColor;
                    (sender as Label).BackColor = StyleInfo.HoverLabelNormalBackColor;
                    (sender as Label).ForeColor = StyleInfo.HoverLabelNormalForeColor;
                }
            }

        }

        private void taskLabels_MouseLeave(object sender, EventArgs e)
        {
            if (cmbTheme.SelectedIndex == -1)
            {
                if ((sender as Label).Tag != null && (sender as Label).Tag.ToString() == "Highlight")
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelHighlightForeColor;
                }
                else
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelNormalForeColor;
                }
            }
            else
            {
                if ((sender as Label).Tag != null && (sender as Label).Tag.ToString() == "Highlight")
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelHighlightBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelHighlightForeColor;
                }
                else
                {
                    (sender as Label).Parent.BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).BackColor = StyleInfo.LabelNormalBackColor;
                    (sender as Label).ForeColor = StyleInfo.LabelNormalForeColor;
                }
            }
        }

        private void tiles_TileClicked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            loadControl(ControlInfo.Controls.First(ct => ct.Name == e.Tile.Text));
        }

        private void breadCrumb_ItemClicked(object sender, BreadCrumbEventArgs e)
        {
            breadCrumb.RemoveItemsAfter(e.BreadCrumbItem);
            if (e.BreadCrumbItem.Tag != null)
            {
                try
                {
                    switch ((ExplorerMode)e.BreadCrumbItem.Tag)
                    {
                        case ExplorerMode.Suite:
                            CurrentExplorerMode = ExplorerMode.Suite;
                            break;
                        case ExplorerMode.Controls:
                            CurrentExplorerMode = ExplorerMode.Controls;
                            loadSamples(ControlInfo.Controls.First(c=>c.Name == e.BreadCrumbItem.Value));
                            break;
                        case ExplorerMode.Samples:
                            CurrentExplorerMode = ExplorerMode.Samples;
                            break;

                    }
                }
                catch { }
            }
        }

        private void featureStack_ItemClicked(object sender, FeatureStackEventArgs e)
        {
            loadSample((ControlInfo.SampleData)e.FeatureStackItem.Tag);
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            switch ((sender as Label).Text.ToLower())
            {
                case "文档":
                    System.Diagnostics.Process.Start(StringInfo.AboutLink);
                    break;
                case "论坛":
                    System.Diagnostics.Process.Start(StringInfo.SupportLink);
                    break;
                case "购买":
                    System.Diagnostics.Process.Start(StringInfo.PricingLink);
                    break;
                case "试用":
                    System.Diagnostics.Process.Start(StringInfo.FreeLink);
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (tileLayoutCompleted)
            {
                UpdateTileLayout();
            }
        }

        #endregion
        //===================================================================================//
    }

    #region helper classes
    public enum ExplorerMode
    {
        Suite, Controls, Samples
    }

    public static class ControlInfo
    {
        public static List<ControlData> Controls;
        public class ControlData
        {
            public string Name { get; set; }
            public Image Icon { get; set; }
            public bool IsNew { get; set; }
            public bool IsPopular { get; set; }
            public string Group { get; set; }
            public List<SampleData> Samples;
            public override string ToString()
            {
                return Name;
            }
        }
        public class SampleData
        {
            public string Name { get; set; }
            public string FormName { get; set; }
            public string ShortDescription { get; set; }
            public string LongDescription { get; set; }
            public bool IsNew { get; set; }

        }
    }

    public static class StyleInfo
    {
        public static readonly Dictionary<string, Font> FontSet = new Dictionary<string, Font>()
        {
            {"TaskbarTitle", new System.Drawing.Font("Segoe UI Semibold", 16, FontStyle.Regular, GraphicsUnit.Point) },
            {"TaskbarHighlight", new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold, GraphicsUnit.Point) },
            {"Taskbar", new System.Drawing.Font("Segoe UI", 14, FontStyle.Regular, GraphicsUnit.Point) },
            {"Description", new System.Drawing.Font("Segoe UI", 12, FontStyle.Regular, GraphicsUnit.Point) },
            {"Popular", new System.Drawing.Font("Segoe UI Semibold", 14, FontStyle.Regular, GraphicsUnit.Point) }
        };

        public static Color TileBackColor = Color.FromArgb(82, 81, 80);
        public static Color TileHoverBackColor = Color.FromArgb(113, 113, 113);

        public static Color TitleBackColor = Color.FromArgb(114, 114, 114);

        public static Color HoverLabelHighlightBackColor = Color.FromArgb(253, 220, 160);
        public static Color HoverLabelNormalBackColor = Color.FromArgb(203, 204, 203);
        public static Color LabelHighlightBackColor = Color.FromArgb(251, 172, 24);
        public static Color LabelNormalBackColor = Color.FromArgb(114, 114, 114);
        public static Color HoverLabelHighlightForeColor = Color.White;
        public static Color HoverLabelNormalForeColor = Color.White;
        public static Color LabelHighlightForeColor = Color.White;
        public static Color LabelNormalForeColor = Color.White;

        public static Color BreadcrumbColor1 = Color.FromArgb(203, 204, 203);
        public static Color BreadcrumbColor2 = Color.FromArgb(162, 163, 162);
        public static Color BreadcrumbForeColor = Color.White;
        public static Color BreadcrumbForeColor2 = Color.White;

        public static Color FeatureDescriptionForeColor = Color.FromArgb(113, 113, 113);
        public static Color FeatureTitleForeColor = Color.FromArgb(87, 87, 87);
        public static Color FeatureListForeColor = Color.FromArgb(87, 87, 87);
        public static Color FeatureListBackColor = Color.Transparent;
        public static Color FeatureListSelectedBackColor = Color.FromArgb(162, 162, 162);
        public static Color FeatureListSelectedForeColor = Color.FromArgb(87, 87, 87);
        public static Color FeatureListHoverBackColor = Color.FromArgb(162, 162, 162);
        public static Color FeatureListHoverForeColor = Color.FromArgb(87, 87, 87);

        public static readonly Dictionary<string, Image> ControlIcons = new Dictionary<string, Image>()
        {
            {"条形码", Properties.Resources.ci_Barcode },
            {"图表", Properties.Resources.ci_Chart},
            {"FlexChart", Properties.Resources.ci_FlexChart},
            {"DockingTab", Properties.Resources.ci_DockingTab},
            {"动态帮助", Properties.Resources.ci_DynamicHelp},
            {"编辑器", Properties.Resources.ci_Editor},
            {"Excel", Properties.Resources.ci_Excel},
            {"FlexGrid", Properties.Resources.ci_FlexGrid},
            {"FlexPivot", Properties.Resources.ci_FlexPivot},
            {"FlexReport", Properties.Resources.ci_FlexReport},
            {"甘特图", Properties.Resources.ci_GanttView},
            {"仪表盘", Properties.Resources.ci_Gauge},
            {"输入", Properties.Resources.ci_Input},
            {"输入面板", Properties.Resources.ci_InputPanel},
            {"列表", Properties.Resources.ci_List},
            {"地图控件", Properties.Resources.ci_Map},
            {"PDF", Properties.Resources.ci_PDF},
            {"Ribbon", Properties.Resources.ci_Ribbon},
            {"日程表", Properties.Resources.ci_Scheduler},
            {"尺寸", Properties.Resources.ci_Sizer},
            {"拼写检查", Properties.Resources.ci_SpellChecker},
            {"分割器", Properties.Resources.ci_SplitContainer},
            {"超级工具提示", Properties.Resources.ci_SuperTooltip},
            {"主题", Properties.Resources.ci_Themes},
            {"磁贴控件", Properties.Resources.ci_TileControl},
            {"菜单和工具栏", Properties.Resources.ci_Toolbars},
            {"TreeView", Properties.Resources.ci_TreeView},
            {"True DBGrid", Properties.Resources.ci_TrueDBGrid},
            {"Win Pack", Properties.Resources.ci_Win7Pack},
            {"Word", Properties.Resources.ci_Word},
            {"Calendar View", Properties.Resources.ci_CalendarView}
        };
    }

    public static class StringInfo
    {
        public static string SuiteDescription = "超过80个.NET Windows窗体控件，包括您无法在其他任何地方访问的窗体。\n\nComponentOneStudio®WinForms Edition控件包含有智能，无代码的设计人员，无尽的内置功能，卓越的灵活性和卓越的 保证这些控制将经得起时间的考验。";
        internal static string FreeLink = @"http://www.gcpowertools.com.cn/products/download.aspx?pid=3&utm_source=Demo&utm_medium=componentone&utm_term=controlexplorer&utm_content=download&utm_campaign=win";
        internal static string PricingLink = @"http://www.gcpowertools.com.cn/order/price.htm?utm_source=Demo&utm_medium=componentone&utm_term=controlexplorer&utm_content=purchase&utm_campaign=win";
        internal static string SupportLink = @"http://gcdn.gcpowertools.com.cn/showforum-66.aspx?utm_source=Demo&utm_medium=componentone&utm_term=controlexplorer&utm_content=forum&utm_campaign=win";
        public static string AboutLink = @"http://www.gcpowertools.com.cn/support/document.htm?utm_source=Demo&utm_medium=componentone&utm_term=controlexplorer&utm_content=document&utm_campaign=win";
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

    #endregion
}
