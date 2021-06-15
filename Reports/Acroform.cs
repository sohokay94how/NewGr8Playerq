using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using C1.C1Preview;
using C1.C1Preview.DataBinding;
using C1.C1Preview.Export;

namespace ControlExplorer.Reports
{
    public partial class Acroform : C1DemoForm
    { 
        private Style _captionStyle;
        private Style _fieldCaptionStyle;
        private Style _requiredCharStyle;
        private Style _passwordInfoStyle;
        private Style _textFieldStyle;
        string answers = "";

        public Acroform()
        {
            InitializeComponent();    
        }

        private void comboDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDocs.SelectedItem.ToString().Equals("Acroform"))
            {
                createAcroform();
            }
            else if (comboDocs.SelectedItem.ToString().Equals("Brain Quiz"))
            {
                createQuizForm();
            }
        }

        // This method creates a C1PrintDocument Acroform using the doc.Generate approach.
        // When using doc.Generate the content is added to the Body.children collection.
        private void createAcroform()
        {
            doc.Clear();
            RenderTable ph = new RenderTable(doc);
            RenderInputButton rbPrior = new RenderInputButton(doc, "<<");
            rbPrior.InputActions.Add(
                UserActionEnum.Click,
                new ActionHandlerLink(new C1LinkTargetPage(PageJumpTypeEnum.Previous)));
            RenderInputButton rbNext = new RenderInputButton(doc, ">>");
            rbNext.X = "parent.Width - width";
            rbNext.InputActions.Add(
                UserActionEnum.Click,
                new ActionHandlerLink(new C1LinkTargetPage(PageJumpTypeEnum.Next)));
            ph.Cells[0, 0].Area.Children.Add(rbPrior);
            ph.Cells[0, 1].Area.Children.Add(rbNext);
            ph.Style.Borders.Bottom = new LineDef("1pt", Color.Black);
            ph.Style.Spacing.Bottom = "5mm";

            doc.PageLayout.PageHeader = ph;

            doc.PageLayout.PageFooter = new RenderText(doc, "页 [PageNo] 共[PageCount]页", AlignHorzEnum.Right);

            //  create styles
            _captionStyle = doc.Style.Children.Add();
            _captionStyle.Font = new Font("Tahoma", 16, FontStyle.Bold);
            _captionStyle.BackColor = Color.FromArgb(208, 237, 253);
            _captionStyle.Spacing.Bottom = "5mm";

            _fieldCaptionStyle = doc.Style.Children.Add();
            _fieldCaptionStyle.Font = new Font("Tahoma", 13);

            _requiredCharStyle = doc.Style.Children.Add();
            _requiredCharStyle.Parents = _fieldCaptionStyle;
            _requiredCharStyle.TextColor = Color.Red;

            _passwordInfoStyle = doc.Style.Children.Add();
            _passwordInfoStyle.Parents = _fieldCaptionStyle;
            _passwordInfoStyle.TextPosition = TextPositionEnum.Subscript;

            _textFieldStyle = doc.Style.Children.Add();
            _textFieldStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            //  Personal information
            doc.Body.Children.Add(new RenderText(doc, "个人信息", _captionStyle, _captionStyle));
            //  create RenderTable containing the form's fields
            RenderTable rt = new RenderTable(doc);
            rt.CellStyle.Padding.All = "0.5mm";
            rt.Cells[0, 0].RenderObject = CreateFieldCaption(doc, "名字:", true, false);
            rt.Cells[1, 0].RenderObject = CreateTextField(doc, "FirstName", Color.Black, false);

            rt.Cells[0, 1].RenderObject = CreateFieldCaption(doc, "姓氏:", true, false);
            rt.Cells[1, 1].RenderObject = CreateTextField(doc, "LastName", Color.Black, false);

            rt.Cells[2, 0].RenderObject = CreateFieldCaption(doc, "邮件地址:", true, false);
            rt.Cells[3, 0].RenderObject = CreateTextField(doc, "EmailAddress", Color.Blue, false);

            rt.Cells[2, 1].RenderObject = CreateFieldCaption(doc, "确认邮件地址:", true, false);
            rt.Cells[3, 1].RenderObject = CreateTextField(doc, "RetypeEmailAddress", Color.Blue, false);

            rt.Cells[4, 0].RenderObject = CreateFieldCaption(doc, "密码:", true, true);
            rt.Cells[5, 0].RenderObject = CreateTextField(doc, "Password", Color.Black, true);

            rt.Cells[4, 1].RenderObject = CreateFieldCaption(doc, "确认密码:", true, false);
            rt.Cells[5, 1].RenderObject = CreateTextField(doc, "RetypePassword", Color.Black, true);

            rt.Cells[6, 0].RenderObject = CreateFieldCaption(doc, "城市:", false, false);
            rt.Cells[7, 0].RenderObject = CreateTextField(doc, "City", Color.Black, false);

            rt.Cells[6, 1].RenderObject = CreateFieldCaption(doc, "州:", false, false);
            rt.Cells[7, 1].RenderObject = CreateTextField(doc, "State", Color.Black, false);

            //  add the "Select" button
            RenderArea ra = new RenderArea(doc);
            RenderInputButton rb = new RenderInputButton(doc, "选择...");
            rb.Name = "Select";
            rb.X = "parent.Width - width";
            ra.Children.Add(rb);
            rt.Cells[8, 1].RenderObject = ra;

            //  Work status field
            rt.Cells[9, 0].RenderObject = CreateFieldCaption(doc, "工作状态:", true, false);
            rt.Cells[9, 0].SpanCols = 2;

            rt.Cells[10, 0].RenderObject = new RenderInputRadioButton(doc, "StatusCitizen", "我是一个公民");
            ((RenderInputRadioButton)rt.Cells[10, 0].RenderObject).Checked = true;
            rt.Cells[10, 1].RenderObject = new RenderInputRadioButton(doc, "StatusAny", "我获批准为任何雇主工作");
            rt.Cells[11, 0].RenderObject = new RenderInputRadioButton(doc, "StatusCurrent", "我获批准为当前雇主工作");
            rt.Cells[11, 1].RenderObject = new RenderInputRadioButton(doc, "StatusSeeking", "我正寻求批准");
            rt.Style.Spacing.Bottom = "5mm";
            doc.Body.Children.Add(rt);

            // 
            doc.Body.Children.Add(new RenderText(doc, "兴趣", _captionStyle, _captionStyle));

            rt = new RenderTable(doc);
            rt.Cells[0, 0].RenderObject = new RenderInputCheckBox(doc, "会计");
            rt.Cells[0, 1].RenderObject = new RenderInputCheckBox(doc, "一般业务");
            rt.Cells[0, 2].RenderObject = new RenderInputCheckBox(doc, "制药");
            rt.Cells[1, 0].RenderObject = new RenderInputCheckBox(doc, "行政及文书");
            rt.Cells[1, 1].RenderObject = new RenderInputCheckBox(doc, "一般劳工");
            rt.Cells[1, 2].RenderObject = new RenderInputCheckBox(doc, "专业服务");
            rt.Cells[2, 0].RenderObject = new RenderInputCheckBox(doc, "汽车");
            rt.Cells[2, 1].RenderObject = new RenderInputCheckBox(doc, "政府");
            rt.Cells[2, 2].RenderObject = new RenderInputCheckBox(doc, "QA - 质量保证");
            rt.Cells[2, 0].RenderObject = new RenderInputCheckBox(doc, "生物技术");
            rt.Cells[2, 1].RenderObject = new RenderInputCheckBox(doc, "信息技术");
            rt.Cells[2, 2].RenderObject = new RenderInputCheckBox(doc, "仓库");
            rt.BreakAfter = BreakEnum.Page;
            doc.Body.Children.Add(rt);


            doc.Body.Children.Add(new RenderText(doc, "希望职位", _captionStyle, _captionStyle));
            doc.Body.Children.Add(new RenderText(doc, "通过尽可能多的完成以下问题来描述你所需要的职位。请指明你所期望的工资。"));

            rt = new RenderTable(doc);
            rt.Cells[0, 0].RenderObject = new RenderInputCheckBox(doc, "全职");
            rt.Cells[0, 1].RenderObject = new RenderInputCheckBox(doc, "兼职");
            rt.Cells[0, 2].RenderObject = new RenderInputCheckBox(doc, "实习生");
            rt.Cells[1, 0].RenderObject = new RenderInputCheckBox(doc, "季节工");
            rt.Cells[1, 1].RenderObject = new RenderInputCheckBox(doc, "临时工");
            rt.Style.Spacing.Bottom = "5mm";
            doc.Body.Children.Add(rt);

            doc.Body.Children.Add(new RenderText(doc, "你上下班愿意走多远？"));
            RenderInputComboBox rc = new RenderInputComboBox(
                doc,
                "-- 选择距离 --",
                "1 英里",
                "5 英里",
                "10 英里",
                "25 英里",
                "50 英里",
                "100 英里");
            rc.Text = rc.Items[0].Text;
            rc.Style.Parents = _textFieldStyle;
            rc.Style.Spacing.Bottom = "5mm";
            doc.Body.Children.Add(rc);

            doc.Body.Children.Add(new RenderText(doc, "你希望工作的多长时间用在出差上？"));
            rc = new RenderInputComboBox(
                doc,
                "不太想出差",
                "25%的时间",
                "50%的时间",
                "更多");
            rc.DropDownStyle = ComboBoxStyle.DropDownList;
            rc.Text = rc.Items[0].Text;
            doc.Body.Children.Add(rc);

            //  Save button
            rb = new RenderInputButton(doc, "保存...");
            rb.AcceptButton = true;
            rb.InputActions.Add(
                UserActionEnum.Click,
                new ActionHandlerFileSave());
            doc.Body.Children.Add(rb);

            rb = new RenderInputButton(doc, "另存为PDF...");
            rb.InputActions.Add(
                UserActionEnum.Click,
                new ActionHandlerFileSave(null, ExportProviders.PdfExportProvider));
            doc.Body.Children.Add(rb);

            // Generate Doc
            doc.Generate();

            // Hide custom button (used only for Quiz form)
            btnCheckAnswers.Visible = false;
        }


        private RenderObject CreateCaption(C1PrintDocument doc, string text)
        {
            return null;
        }

        // Used internally in createAcroform to add field captions
        private RenderObject CreateFieldCaption(
            C1PrintDocument doc,
            string caption,
            bool required,
            bool password)
        {
            ParagraphText pt;
            RenderParagraph result = new RenderParagraph(doc);
            if (required)
            {
                pt = new ParagraphText("*");
                pt.Style.Parents = _requiredCharStyle;
                result.Content.Add(pt);

                pt = new ParagraphText(" ");
                pt.Style.Parents = _fieldCaptionStyle;
                result.Content.Add(pt);
            }

            pt = new ParagraphText(caption);
            pt.Style.Parents = _fieldCaptionStyle;
            result.Content.Add(pt);

            if (password)
            {
                pt = new ParagraphText("(至少5个字符)");
                pt.Style.Parents = _passwordInfoStyle;
                result.Content.Add(pt);
            }

            return result;
        }

        // Used internally in createAcroform to add textfield input objects
        private RenderInputBase CreateTextField(
            C1PrintDocument doc,
            string name,
            Color textColor,
            bool passwordField)
        {
            RenderInputText result = new RenderInputText(doc);
            result.Name = name;
            result.Style.Parents = _textFieldStyle;
            result.Style.TextColor = textColor;
            result.StatusText = name;
            result.ToolTip = name;
            if (passwordField)
                result.PasswordChar = (char)0x25CF;
            return result;
        }

        // This method creates a C1PrintDocument acroform using the StartDoc/EndDoc approach.
        // When using StartDoc/EndDoc the content is created using the Render methods.
        private void createQuizForm()
        {
            doc.Clear();
            doc.PageLayouts.Default.PageSettings = new C1.C1Preview.C1PageSettings(false, System.Drawing.Printing.PaperKind.Letter, false, "1in", "1in", "1in", "1in");
            doc.AllowNonReflowableDocs = true;
            doc.Style.Font = new Font("Comic Sans MS", 12);
            doc.StartDoc();
            doc.RenderBlockRichText(@"{\fonttbl{\f0\froman\fprq2\fcharset2 Webdings;}{\f1\fscript\fprq2\fcharset0 Comic Sans MS;}{\f2\fswiss\fcharset0 Arial;}}{\*\generator Msftedit 5.41.21.2507;}\viewkind4\uc1\pard\f0\fs96 [\f1\fs28  \fs72 Brain Quiz\f2\fs20\par}");
            doc.RenderBlockText("说明：尽你能力回答一下问题，点击“查看答案”来查看分数。");

            // Read in quiz questions from text file
            try
            {
                StreamReader sr = new StreamReader(File.Open(AppDomain.CurrentDomain.BaseDirectory + "Reports\\Files\\quiz1.txt", FileMode.Open));
                string question, choice;
                int count = 1, numOfChoices = 3;
                while (!sr.EndOfStream)
                {
                    // Read in Question    
                    question = sr.ReadLine();
                    doc.RenderBlockText(" ");
                    doc.RenderBlockText(count.ToString() + ") " + question);
                    RenderTable rtChoices = new RenderTable(1, numOfChoices);
                    for (int i = 0; i < numOfChoices; i++)
                    {
                        // Read in each choice
                        choice = sr.ReadLine();
                        rtChoices.Cells[0, i].Area.Children.Add(new RenderInputRadioButton("rad" + count.ToString() + i.ToString(), (char)(65 + i) + ") " + choice, count));
                        rtChoices.Name = "rtChoices" + count.ToString();
                    }
                    doc.RenderBlock(rtChoices);
                    answers = answers + sr.ReadLine(); // store correct answer
                    count += 1;
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("抱歉， 不能够读入测试文件 :(");
            }

            doc.EndDoc();

            // Add a custom ToolBar button for checking answers
            btnCheckAnswers.Visible = true;

        }

        private void btnCheckAnswers_Click(object sender, EventArgs e)
        {
            if (c1PrintPreviewControl1.Document != doc)
            {
                MessageBox.Show("你应该首先查看测验.");
                return;
            }
            string guesses = "";
            int leftBlank;
            // Cycle through each render table containing each set of radio buttons
            foreach (RenderObject ro in doc.Body.Children)
            {
                if (ro.GetType() == typeof(C1.C1Preview.RenderTable))
                {
                    RenderTable rt = (RenderTable)ro;
                    leftBlank = guesses.Length;
                    for (int i = 0; i < 3; i++)
                    {
                        RenderInputRadioButton rib = (RenderInputRadioButton)rt.Cells[0, i].Area.Children[0];
                        // Mark the selected choice
                        if (rib.Checked)
                            guesses = guesses + (char)(65 + i);
                    }
                    if (guesses.Length == leftBlank) // Mark questions left blank with X
                        guesses = guesses + "X";
                }

            }
            int num_correct = 0;
            for (int i = 0; i < guesses.Length; i++)
            {
                if (answers.Length >= guesses.Length && guesses[i] == answers[i])
                    num_correct += 1;
            }
            MessageBox.Show("你答对了10个题中的 " + num_correct.ToString() + " 个!");
        }

        private void Acroform_Load(object sender, EventArgs e)
        {
            c1PrintPreviewControl1.Document = doc;
            comboDocs.SelectedIndex = 0;

            //  add demo properties
            AddProperty("ImageSet", c1PrintPreviewControl1);
            AddProperty("NavigationPanelVisible", c1PrintPreviewControl1);
            AddProperty("PageLayout", c1PrintPreviewControl1.PreviewPane);
            AddProperty("ShowRulers", c1PrintPreviewControl1.PreviewPane);
            AddProperty("StatusBarVisible", c1PrintPreviewControl1);
            AddProperty("TextSearchPanelVisible", c1PrintPreviewControl1);
            AddProperty("ZoomMode", c1PrintPreviewControl1.PreviewPane);
        }
    }
}
