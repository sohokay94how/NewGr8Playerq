namespace ControlExplorer.List
{
    partial class MoreFeatures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreFeatures));
            this.c1List1 = new C1.Win.C1List.C1List();
            this.btnHorizontalSplit = new System.Windows.Forms.Button();
            this.btnVerticalSplit = new System.Windows.Forms.Button();
            this.c1Combo1 = new C1.Win.C1List.C1Combo();
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1List1
            // 
            this.c1List1.AddItemSeparator = ';';
            this.c1List1.AllowHorizontalSplit = true;
            this.c1List1.AllowVerticalSplit = true;
            this.c1List1.AlternatingRows = true;
            this.c1List1.Caption = "供应商";
            this.c1List1.CaptionHeight = 17;
            this.c1List1.CellTips = C1.Win.C1List.CellTipEnum.Floating;
            this.c1List1.ColumnCaptionHeight = 17;
            this.c1List1.ColumnFooterHeight = 17;
            this.c1List1.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark;
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images1"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images2"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images3"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images4"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images5"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images6"))));
            this.c1List1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1List1.Images7"))));
            this.c1List1.ItemHeight = 30;
            this.c1List1.Location = new System.Drawing.Point(14, 51);
            this.c1List1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c1List1.MatchCol = C1.Win.C1List.MatchColEnum.AllCols;
            this.c1List1.MatchEntry = C1.Win.C1List.MatchEntryEnum.Standard;
            this.c1List1.MatchEntryTimeout = ((long)(2000));
            this.c1List1.Name = "c1List1";
            this.c1List1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1List1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1List1.PreviewInfo.ZoomFactor = 75D;
            this.c1List1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1List1.PrintInfo.PageSettings")));
            this.c1List1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1List1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1List1.ScrollTips = true;
            this.c1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox;
            this.c1List1.ShowHeaderCheckBox = false;
            this.c1List1.Size = new System.Drawing.Size(662, 377);
            this.c1List1.TabIndex = 0;
            this.c1List1.Text = "c1List1";
            this.c1List1.UnboundColumnFetch += new C1.Win.C1List.UnboundColumnFetchEventHandler(this.c1List1_UnboundColumnFetch);
            this.c1List1.FetchScrollTips += new C1.Win.C1List.FetchScrollTipsEventHandler(this.c1List1_FetchScrollTips);
            this.c1List1.PropBag = resources.GetString("c1List1.PropBag");
            // 
            // btnHorizontalSplit
            // 
            this.btnHorizontalSplit.Location = new System.Drawing.Point(684, 51);
            this.btnHorizontalSplit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHorizontalSplit.Name = "btnHorizontalSplit";
            this.btnHorizontalSplit.Size = new System.Drawing.Size(135, 30);
            this.btnHorizontalSplit.TabIndex = 1;
            this.btnHorizontalSplit.Text = "增加水平分割";
            this.btnHorizontalSplit.UseVisualStyleBackColor = true;
            this.btnHorizontalSplit.Click += new System.EventHandler(this.btnHorizontalSplit_Click);
            // 
            // btnVerticalSplit
            // 
            this.btnVerticalSplit.Location = new System.Drawing.Point(684, 89);
            this.btnVerticalSplit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerticalSplit.Name = "btnVerticalSplit";
            this.btnVerticalSplit.Size = new System.Drawing.Size(135, 30);
            this.btnVerticalSplit.TabIndex = 2;
            this.btnVerticalSplit.Text = "增加竖直分割";
            this.btnVerticalSplit.UseVisualStyleBackColor = true;
            this.btnVerticalSplit.Click += new System.EventHandler(this.btnVerticalSplit_Click);
            // 
            // c1Combo1
            // 
            this.c1Combo1.AddItemSeparator = ';';
            this.c1Combo1.AlternatingRows = true;
            this.c1Combo1.AutoCompletion = true;
            this.c1Combo1.AutoSelect = true;
            this.c1Combo1.Caption = "";
            this.c1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.c1Combo1.EditorBackColor = System.Drawing.SystemColors.Window;
            this.c1Combo1.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images1"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images2"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images3"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images4"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images5"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images6"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images7"))));
            this.c1Combo1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1Combo1.Images8"))));
            this.c1Combo1.Location = new System.Drawing.Point(14, 16);
            this.c1Combo1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c1Combo1.MatchEntryTimeout = ((long)(2000));
            this.c1Combo1.MaxDropDownItems = ((short)(5));
            this.c1Combo1.MaxLength = 32767;
            this.c1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.c1Combo1.Name = "c1Combo1";
            this.c1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.c1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.c1Combo1.Size = new System.Drawing.Size(380, 21);
            this.c1Combo1.TabIndex = 3;
            this.c1Combo1.Text = "c1Combo1";
            this.c1Combo1.PropBag = resources.GetString("c1Combo1.PropBag");
            // 
            // MoreFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 583);
            this.Controls.Add(this.c1Combo1);
            this.Controls.Add(this.btnVerticalSplit);
            this.Controls.Add(this.btnHorizontalSplit);
            this.Controls.Add(this.c1List1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MoreFeatures";
            this.Text = "更多特性";
            this.Load += new System.EventHandler(this.MoreFeatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1List1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Combo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1List.C1List c1List1;
        private System.Windows.Forms.Button btnHorizontalSplit;
        private System.Windows.Forms.Button btnVerticalSplit;
        private C1.Win.C1List.C1Combo c1Combo1;
    }
}