namespace ControlExplorer.Editor
{
    partial class SyntaxHighlight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyntaxHighlight));
            this.C1EditorToolStripMain1 = new C1.Win.C1Editor.ToolStrips.C1EditorToolStripMain();
            this.C1Editor1 = new C1.Win.C1Editor.C1Editor();
            ((System.ComponentModel.ISupportInitialize)(this.C1Editor1)).BeginInit();
            this.SuspendLayout();
            // 
            // C1EditorToolStripMain1
            // 
            this.C1EditorToolStripMain1.Editor = null;
            this.C1EditorToolStripMain1.Location = new System.Drawing.Point(0, 0);
            this.C1EditorToolStripMain1.Name = "C1EditorToolStripMain1";
            this.C1EditorToolStripMain1.Size = new System.Drawing.Size(691, 25);
            this.C1EditorToolStripMain1.TabIndex = 1;
            this.C1EditorToolStripMain1.Text = "C1EditorToolStripMain1";
            // 
            // C1Editor1
            // 
            this.C1Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.C1Editor1.Location = new System.Drawing.Point(0, 25);
            this.C1Editor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.C1Editor1.MinimumSize = new System.Drawing.Size(233, 260);
            this.C1Editor1.Name = "C1Editor1";
            this.C1Editor1.Size = new System.Drawing.Size(691, 558);
            this.C1Editor1.TabIndex = 2;
            this.C1Editor1.Xml = resources.GetString("C1Editor1.Xml");
            // 
            // SyntaxHighlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 583);
            this.Controls.Add(this.C1Editor1);
            this.Controls.Add(this.C1EditorToolStripMain1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SyntaxHighlight";
            this.Text = "SyntaxHighlight";
            this.Load += new System.EventHandler(this.SyntaxHighlight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.C1Editor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Editor.ToolStrips.C1EditorToolStripMain C1EditorToolStripMain1;
        private C1.Win.C1Editor.C1Editor C1Editor1;
    }
}