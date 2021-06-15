﻿namespace ControlExplorer.Tiles
{
    partial class Flickr
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
            C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement2 = new C1.Win.C1Tile.TextElement();
            C1.Win.C1Tile.TextElement textElement3 = new C1.Win.C1Tile.TextElement();
            C1.Win.C1Tile.ImageElement imageElement2 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.PanelElement panelElement2 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.TextElement textElement4 = new C1.Win.C1Tile.TextElement();
            C1.Win.C1Tile.PanelElement panelElement3 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.PanelElement panelElement4 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement3 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement5 = new C1.Win.C1Tile.TextElement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.loadNewButton = new System.Windows.Forms.Button();
            this.waitLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.setTagButton = new System.Windows.Forms.Button();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.flickrTiles = new C1.Win.C1Tile.C1TileControl();
            this.group1 = new C1.Win.C1Tile.Group();
            this.tile1 = new C1.Win.C1Tile.Tile();
            this.tempError = new C1.Win.C1Tile.Template();
            this.tile2 = new C1.Win.C1Tile.Tile();
            this.tempFlickr = new C1.Win.C1Tile.Template();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imgPanel = new System.Windows.Forms.Panel();
            this.authorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.imgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.loadNewButton);
            this.panel1.Controls.Add(this.waitLabel);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.setTagButton);
            this.panel1.Controls.Add(this.tagBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 44);
            this.panel1.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Image = global::ControlExplorer.Properties.Resources.refresh;
            this.refreshButton.Location = new System.Drawing.Point(648, 2);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(44, 39);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.TabStop = false;
            this.toolTip1.SetToolTip(this.refreshButton, "Refresh");
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // loadNewButton
            // 
            this.loadNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadNewButton.FlatAppearance.BorderSize = 0;
            this.loadNewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadNewButton.Image = global::ControlExplorer.Properties.Resources.loadNew;
            this.loadNewButton.Location = new System.Drawing.Point(692, 2);
            this.loadNewButton.Margin = new System.Windows.Forms.Padding(0);
            this.loadNewButton.Name = "loadNewButton";
            this.loadNewButton.Size = new System.Drawing.Size(44, 39);
            this.loadNewButton.TabIndex = 6;
            this.loadNewButton.TabStop = false;
            this.toolTip1.SetToolTip(this.loadNewButton, "Load New Images");
            this.loadNewButton.UseVisualStyleBackColor = true;
            this.loadNewButton.Click += new System.EventHandler(this.loadNewButton_Click);
            // 
            // waitLabel
            // 
            this.waitLabel.AutoSize = true;
            this.waitLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.waitLabel.Location = new System.Drawing.Point(82, 15);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(52, 15);
            this.waitLabel.TabIndex = 5;
            this.waitLabel.Text = "请稍等...";
            this.waitLabel.Visible = false;
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = global::ControlExplorer.Properties.Resources.back;
            this.backButton.Location = new System.Drawing.Point(2, 2);
            this.backButton.Margin = new System.Windows.Forms.Padding(0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(44, 39);
            this.backButton.TabIndex = 4;
            this.backButton.TabStop = false;
            this.toolTip1.SetToolTip(this.backButton, "Back");
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // setTagButton
            // 
            this.setTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setTagButton.FlatAppearance.BorderSize = 0;
            this.setTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setTagButton.Image = global::ControlExplorer.Properties.Resources.tag;
            this.setTagButton.Location = new System.Drawing.Point(586, 2);
            this.setTagButton.Margin = new System.Windows.Forms.Padding(0);
            this.setTagButton.Name = "setTagButton";
            this.setTagButton.Size = new System.Drawing.Size(44, 39);
            this.setTagButton.TabIndex = 3;
            this.setTagButton.TabStop = false;
            this.toolTip1.SetToolTip(this.setTagButton, "Set Tags");
            this.setTagButton.UseVisualStyleBackColor = true;
            this.setTagButton.Click += new System.EventHandler(this.setTagButton_Click);
            // 
            // tagBox
            // 
            this.tagBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tagBox.Location = new System.Drawing.Point(464, 10);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(117, 23);
            this.tagBox.TabIndex = 1;
            this.tagBox.TabStop = false;
            this.tagBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tagBox_KeyPress);
            // 
            // flickrTiles
            // 
            this.flickrTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.flickrTiles.CellHeight = 50;
            this.flickrTiles.CellWidth = 50;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            imageElement1.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleInner;
            this.flickrTiles.DefaultTemplate.Elements.Add(panelElement1);
            this.flickrTiles.DefaultTemplate.Elements.Add(imageElement1);
            this.flickrTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flickrTiles.FocusedBorderColor = System.Drawing.Color.Firebrick;
            this.flickrTiles.ForeColor = System.Drawing.Color.SeaGreen;
            this.flickrTiles.GroupPadding = new System.Windows.Forms.Padding(20);
            this.flickrTiles.Groups.Add(this.group1);
            this.flickrTiles.HotBorderColor = System.Drawing.Color.SeaGreen;
            this.flickrTiles.Location = new System.Drawing.Point(0, 44);
            this.flickrTiles.Name = "flickrTiles";
            this.flickrTiles.Padding = new System.Windows.Forms.Padding(0);
            this.flickrTiles.Size = new System.Drawing.Size(739, 409);
            this.flickrTiles.SurfaceContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.flickrTiles.SurfacePadding = new System.Windows.Forms.Padding(5);
            this.flickrTiles.TabIndex = 1;
            this.flickrTiles.Templates.Add(this.tempError);
            this.flickrTiles.Templates.Add(this.tempFlickr);
            this.flickrTiles.TileBackColor = System.Drawing.Color.DarkSeaGreen;
            // 
            // group1
            // 
            this.group1.Name = "group1";
            this.group1.Tiles.Add(this.tile1);
            this.group1.Tiles.Add(this.tile2);
            // 
            // tile1
            // 
            this.tile1.HorizontalSize = 4;
            this.tile1.Name = "tile1";
            this.tile1.Template = this.tempError;
            this.tile1.VerticalSize = 2;
            // 
            // tempError
            // 
            this.tempError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tempError.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            textElement2.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleCenter;
            textElement2.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            textElement2.FontBold = C1.Win.C1Tile.ThreeStateBoolean.True;
            textElement2.FontSize = 16F;
            textElement2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 26);
            textElement2.Text = "Can\'t Load Images From Flickr";
            textElement2.TextSelector = C1.Win.C1Tile.TextSelector.Unbound;
            textElement3.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            textElement3.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            textElement3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            textElement3.Text = "Click or tap to see the error message";
            textElement3.TextSelector = C1.Win.C1Tile.TextSelector.Unbound;
            this.tempError.Elements.Add(textElement2);
            this.tempError.Elements.Add(textElement3);
            this.tempError.Name = "tempError";
            // 
            // tile2
            // 
            this.tile2.HorizontalSize = 4;
            this.tile2.Name = "tile2";
            this.tile2.Template = this.tempFlickr;
            this.tile2.Text = "主题";
            this.tile2.Text1 = "author";
            this.tile2.VerticalSize = 3;
            // 
            // tempFlickr
            // 
            imageElement2.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            panelElement2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            textElement4.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            textElement4.ForeColor = System.Drawing.Color.Black;
            textElement4.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            textElement4.SingleLine = true;
            panelElement2.Children.Add(textElement4);
            panelElement2.Dock = System.Windows.Forms.DockStyle.Top;
            panelElement2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panelElement3.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
            panelElement3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            imageElement3.FixedHeight = 32;
            imageElement3.FixedWidth = 32;
            imageElement3.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            imageElement3.ImageSelector = C1.Win.C1Tile.ImageSelector.Image1;
            panelElement4.Children.Add(imageElement3);
            panelElement4.Dock = System.Windows.Forms.DockStyle.Right;
            textElement5.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            textElement5.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
            textElement5.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
            panelElement3.Children.Add(panelElement4);
            panelElement3.Children.Add(textElement5);
            panelElement3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelElement3.FixedHeight = 32;
            this.tempFlickr.Elements.Add(imageElement2);
            this.tempFlickr.Elements.Add(panelElement2);
            this.tempFlickr.Elements.Add(panelElement3);
            this.tempFlickr.Name = "tempFlickr";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(20, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(699, 339);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            // 
            // imgPanel
            // 
            this.imgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.imgPanel.Controls.Add(this.authorLabel);
            this.imgPanel.Controls.Add(this.titleLabel);
            this.imgPanel.Controls.Add(this.pictureBox);
            this.imgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPanel.Location = new System.Drawing.Point(0, 44);
            this.imgPanel.Name = "imgPanel";
            this.imgPanel.Padding = new System.Windows.Forms.Padding(20, 35, 20, 35);
            this.imgPanel.Size = new System.Drawing.Size(739, 409);
            this.imgPanel.TabIndex = 2;
            this.imgPanel.Visible = false;
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.authorLabel.AutoEllipsis = true;
            this.authorLabel.Location = new System.Drawing.Point(20, 380);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(699, 18);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "author";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoEllipsis = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.titleLabel.Location = new System.Drawing.Point(17, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(702, 18);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Flickr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 453);
            this.Controls.Add(this.flickrTiles);
            this.Controls.Add(this.imgPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeyPreview = true;
            this.Name = "Flickr";
            this.Text = "Flickr Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ViewerForm_PreviewKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.imgPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Tile.C1TileControl flickrTiles;
        private C1.Win.C1Tile.Group group1;
        private C1.Win.C1Tile.Tile tile1;
        private C1.Win.C1Tile.Template tempError;
        private C1.Win.C1Tile.Tile tile2;
        private C1.Win.C1Tile.Template tempFlickr;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Button setTagButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel imgPanel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label waitLabel;
        private System.Windows.Forms.Button loadNewButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button refreshButton;
    }
}

