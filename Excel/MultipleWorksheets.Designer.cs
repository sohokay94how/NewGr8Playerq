﻿namespace ControlExplorer.Excel
{
    partial class MultipleWorksheets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleWorksheets));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this._c1xl = new C1.C1Excel.C1XLBook();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(689, 446);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(需要Excel 97或更高版本)";
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(224, 353);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(140, 23);
            this.c1Button1.TabIndex = 1;
            this.c1Button1.Text = "生成 Excel 文件";
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // MultipleWorksheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 446);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MultipleWorksheets";
            this.Text = "多个工作表";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private C1.Win.C1Input.C1Button c1Button1;
        private C1.C1Excel.C1XLBook _c1xl;
        private System.Windows.Forms.Label label2;
    }
}