namespace ControlExplorer.Input
{
    partial class SplitButton
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitButton));
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1SplitButtonSpell = new C1.Win.C1Input.C1SplitButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dropDownItemEnglish = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemGerman = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemSpanish = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemRussian = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemSeparator = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemMenu = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemMed = new C1.Win.C1Input.DropDownItem();
            this.dropDownItemBusiness = new C1.Win.C1Input.DropDownItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c1SplitButtonVisualStyle = new C1.Win.C1Input.C1SplitButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1SplitButtonSpell);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 126);
            this.panel1.TabIndex = 1;
            // 
            // c1SplitButtonSpell
            // 
            this.c1SplitButtonSpell.DropDownImageList = this.imageList1;
            this.c1SplitButtonSpell.Image = global::ControlExplorer.Properties.Resources.Action_spellcheck_icon_1_1;
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemEnglish);
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemGerman);
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemSpanish);
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemRussian);
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemSeparator);
            this.c1SplitButtonSpell.Items.Add(this.dropDownItemMenu);
            this.c1SplitButtonSpell.Location = new System.Drawing.Point(14, 16);
            this.c1SplitButtonSpell.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c1SplitButtonSpell.Name = "c1SplitButtonSpell";
            this.c1SplitButtonSpell.Size = new System.Drawing.Size(157, 92);
            this.c1SplitButtonSpell.TabIndex = 1;
            this.c1SplitButtonSpell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.c1SplitButtonSpell.UseVisualStyleBackColor = true;
            this.c1SplitButtonSpell.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.c1SplitButtonSpell.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.c1SplitButtonSpell.DropDownItemClicked += new C1.Win.C1Input.DropDownItemClickedEventHandler(this.c1SplitButtonSpell_DropDownItemClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "flag_great_britain.png");
            this.imageList1.Images.SetKeyName(1, "flag_spain.png");
            this.imageList1.Images.SetKeyName(2, "flag_france.png");
            this.imageList1.Images.SetKeyName(3, "flag_russia.png");
            this.imageList1.Images.SetKeyName(4, "flag_germany.png");
            this.imageList1.Images.SetKeyName(5, "tiny_1286011416_meditsina[1].gif");
            this.imageList1.Images.SetKeyName(6, "user_business_boss[1].png");
            // 
            // dropDownItemEnglish
            // 
            this.dropDownItemEnglish.ImageIndex = 0;
            this.dropDownItemEnglish.ImageKey = "flag_great_britain.png";
            this.dropDownItemEnglish.Text = "English";
            // 
            // dropDownItemGerman
            // 
            this.dropDownItemGerman.ImageKey = "flag_germany.png";
            this.dropDownItemGerman.Text = "German";
            // 
            // dropDownItemSpanish
            // 
            this.dropDownItemSpanish.ImageKey = "flag_spain.png";
            this.dropDownItemSpanish.Text = "Spanish";
            // 
            // dropDownItemRussian
            // 
            this.dropDownItemRussian.ImageKey = "flag_russia.png";
            this.dropDownItemRussian.Text = "Russian";
            // 
            // dropDownItemSeparator
            // 
            this.dropDownItemSeparator.Text = "-";
            // 
            // dropDownItemMenu
            // 
            this.dropDownItemMenu.Items.Add(this.dropDownItemMed);
            this.dropDownItemMenu.Items.Add(this.dropDownItemBusiness);
            this.dropDownItemMenu.Text = "Special";
            // 
            // dropDownItemMed
            // 
            this.dropDownItemMed.ImageKey = "tiny_1286011416_meditsina[1].gif";
            this.dropDownItemMed.Text = "Medical";
            // 
            // dropDownItemBusiness
            // 
            this.dropDownItemBusiness.Enabled = false;
            this.dropDownItemBusiness.ImageKey = "user_business_boss[1].png";
            this.dropDownItemBusiness.Text = "Business";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.c1SplitButtonVisualStyle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 755);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 65);
            this.panel2.TabIndex = 2;
            // 
            // c1SplitButtonVisualStyle
            // 
            this.c1SplitButtonVisualStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c1SplitButtonVisualStyle.Location = new System.Drawing.Point(14, 20);
            this.c1SplitButtonVisualStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c1SplitButtonVisualStyle.Name = "c1SplitButtonVisualStyle";
            this.c1SplitButtonVisualStyle.Size = new System.Drawing.Size(169, 30);
            this.c1SplitButtonVisualStyle.TabIndex = 2;
            this.c1SplitButtonVisualStyle.Text = "c1SplitButton1";
            this.c1SplitButtonVisualStyle.UseVisualStyleBackColor = true;
            this.c1SplitButtonVisualStyle.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.c1SplitButtonVisualStyle.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.c1SplitButtonVisualStyle.DropDownItemClicked += new C1.Win.C1Input.DropDownItemClickedEventHandler(this.c1SplitButtonVisualStyle_DropDownItemClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Size = new System.Drawing.Size(974, 629);
            this.panel3.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 3);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(970, 623);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // SplitButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 820);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SplitButton";
            this.Text = "C1SpiltButton Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private C1.Win.C1Input.C1SplitButton c1SplitButtonVisualStyle;
        private C1.Win.C1Input.C1SplitButton c1SplitButtonSpell;
        private C1.Win.C1Input.DropDownItem dropDownItemEnglish;
        private C1.Win.C1Input.DropDownItem dropDownItemGerman;
        private C1.Win.C1Input.DropDownItem dropDownItemSpanish;
        private C1.Win.C1Input.DropDownItem dropDownItemRussian;
        private C1.Win.C1Input.DropDownItem dropDownItemSeparator;
        private C1.Win.C1Input.DropDownItem dropDownItemMenu;
        private C1.Win.C1Input.DropDownItem dropDownItemMed;
        private System.Windows.Forms.ImageList imageList1;
        private C1.Win.C1Input.DropDownItem dropDownItemBusiness;

    }
}

