namespace ControlExplorer.FlexGrid
{
    partial class DateTrees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateTrees));
            this._flex = new ControlExplorer.FlexGrid.C1FlexDataTree();
            ((System.ComponentModel.ISupportInitialize)(this._flex)).BeginInit();
            this.SuspendLayout();
            // 
            // _flex
            // 
            this._flex.AllowAddNew = true;
            this._flex.AllowDelete = true;
            this._flex.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this._flex.ColumnInfo = "10,1,0,0,0,110,Columns:0{Width:34;Style:\"ImageAlign:RightCenter;\";}\t";
            this._flex.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flex.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flex.Location = new System.Drawing.Point(0, 0);
            this._flex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._flex.Name = "_flex";
            this._flex.Rows.Count = 51;
            this._flex.Rows.DefaultSize = 22;
            this._flex.Size = new System.Drawing.Size(691, 583);
            this._flex.StyleInfo = resources.GetString("_flex.StyleInfo");
            this._flex.TabIndex = 0;
            this._flex.SetupColumns += new System.EventHandler(this._flex_SetupColumns);
            // 
            // DateTrees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 583);
            this.Controls.Add(this._flex);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "DateTrees";
            this.Text = "数据树";
            this.Load += new System.EventHandler(this.DataTrees_Load);
            ((System.ComponentModel.ISupportInitialize)(this._flex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1FlexDataTree _flex;
    }
}