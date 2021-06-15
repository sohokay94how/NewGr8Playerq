namespace ControlExplorer.Main
{
    partial class C1CodeViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.c1PreviewPane1 = new C1.Win.C1Preview.C1PreviewPane();
            this.c1PrintDocument1 = new C1.C1Preview.C1PrintDocument();
            this.c1PreviewTextSearchPanel1 = new C1.Win.C1Preview.C1PreviewTextSearchPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1PreviewPane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintDocument1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.c1PreviewPane1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.c1PreviewTextSearchPanel1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(757, 405);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // c1PreviewPane1
            // 
            this.c1PreviewPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1PreviewPane1.Document = this.c1PrintDocument1;
            this.c1PreviewPane1.Location = new System.Drawing.Point(0, 0);
            this.c1PreviewPane1.MouseMode = C1.Win.C1Preview.MouseModeEnum.Select;
            this.c1PreviewPane1.Name = "c1PreviewPane1";
            this.c1PreviewPane1.ShowRulers = C1.Win.C1Preview.ShowRulersFlags.None;
            this.c1PreviewPane1.Size = new System.Drawing.Size(757, 405);
            this.c1PreviewPane1.TabIndex = 0;
            this.c1PreviewPane1.ZoomMode = C1.Win.C1Preview.ZoomModeEnum.TextWidth;
            // 
            // c1PrintDocument1
            // 
            this.c1PrintDocument1.PageLayouts.Default.PageSettings = new C1.C1Preview.C1PageSettings(false, System.Drawing.Printing.PaperKind.Letter, false, "1in", "1in", "1in", "1in", System.Drawing.Printing.PaperSourceKind.FormSource, 15, null, System.Drawing.Printing.PrinterResolutionKind.Custom, 600, 600);
            // 
            // c1PreviewTextSearchPanel1
            // 
            this.c1PreviewTextSearchPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1PreviewTextSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1PreviewTextSearchPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.c1PreviewTextSearchPanel1.MinimumSize = new System.Drawing.Size(233, 295);
            this.c1PreviewTextSearchPanel1.Name = "c1PreviewTextSearchPanel1";
            this.c1PreviewTextSearchPanel1.PreviewPane = this.c1PreviewPane1;
            this.c1PreviewTextSearchPanel1.Size = new System.Drawing.Size(233, 295);
            this.c1PreviewTextSearchPanel1.TabIndex = 0;
            this.c1PreviewTextSearchPanel1.DesiredVisibleChanged += new System.EventHandler(this.c1PreviewTextSearchPanel1_DesiredVisibleChanged);
            // 
            // C1CodeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "C1CodeViewer";
            this.Size = new System.Drawing.Size(757, 405);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1PreviewPane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1PrintDocument1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1Preview.C1PreviewPane c1PreviewPane1;
        private C1.Win.C1Preview.C1PreviewTextSearchPanel c1PreviewTextSearchPanel1;
        private C1.C1Preview.C1PrintDocument c1PrintDocument1;
    }
}
