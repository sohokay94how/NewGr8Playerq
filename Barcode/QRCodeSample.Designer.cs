namespace ControlExplorer.Barcode
{
    partial class QRCodeSample
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
            this.c1QRCode1 = new C1.Win.C1BarCode.C1QRCode();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // c1QRCode1
            // 
            this.c1QRCode1.BackColor = System.Drawing.SystemColors.Control;
            this.c1QRCode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1QRCode1.Location = new System.Drawing.Point(0, 0);
            this.c1QRCode1.Margin = new System.Windows.Forms.Padding(4);
            this.c1QRCode1.Name = "c1QRCode1";
            this.c1QRCode1.Size = new System.Drawing.Size(690, 583);
            this.c1QRCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.c1QRCode1.TabIndex = 1;
            this.c1QRCode1.Text = "C1QRCode: Compact 2D barcode symbology";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(130, 7);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 4296;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(546, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "C1QRCode：紧凑型二维条码符号";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "QR 码值:";
            // 
            // QRCodeSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 583);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.c1QRCode1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QRCodeSample";
            this.Text = "QRCodeSample";
            this.Load += new System.EventHandler(this.QRCodeSample_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1BarCode.C1QRCode c1QRCode1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;

    }
}