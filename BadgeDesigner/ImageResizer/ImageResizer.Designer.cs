namespace ImageResizer
{
    partial class ImageResizer
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
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lblZoomFactor = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.tbResize = new System.Windows.Forms.TrackBar();
            this.grpImage = new System.Windows.Forms.Panel();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCrop = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.nudCropWidth = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.nudCropHeight = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox_RotateRight = new System.Windows.Forms.PictureBox();
            this.pictureBox_RotateLeft = new System.Windows.Forms.PictureBox();
            this.picZoomIn = new System.Windows.Forms.PictureBox();
            this.picZoomOut = new System.Windows.Forms.PictureBox();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResize)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCropWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCropHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RotateRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RotateLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomOut)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBox3.Controls.Add(this.lblZoomFactor);
            this.GroupBox3.Location = new System.Drawing.Point(9, 461);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(41, 39);
            this.GroupBox3.TabIndex = 59;
            this.GroupBox3.TabStop = false;
            // 
            // lblZoomFactor
            // 
            this.lblZoomFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZoomFactor.Location = new System.Drawing.Point(4, 11);
            this.lblZoomFactor.Name = "lblZoomFactor";
            this.lblZoomFactor.Size = new System.Drawing.Size(34, 20);
            this.lblZoomFactor.TabIndex = 42;
            this.lblZoomFactor.Text = "100%";
            this.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.Location = new System.Drawing.Point(253, 492);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(33, 12);
            this.Label1.TabIndex = 57;
            this.Label1.Text = "200%";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.Location = new System.Drawing.Point(171, 492);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(33, 12);
            this.Label2.TabIndex = 45;
            this.Label2.Text = "100%";
            // 
            // tbResize
            // 
            this.tbResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbResize.Enabled = false;
            this.tbResize.Location = new System.Drawing.Point(88, 460);
            this.tbResize.Maximum = 200;
            this.tbResize.Minimum = 1;
            this.tbResize.Name = "tbResize";
            this.tbResize.Size = new System.Drawing.Size(199, 45);
            this.tbResize.TabIndex = 50;
            this.tbResize.TickFrequency = 10;
            this.tbResize.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbResize.Value = 100;
            this.tbResize.ValueChanged += new System.EventHandler(this.tbResize_ValueChanged);
            // 
            // grpImage
            // 
            this.grpImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImage.AutoScroll = true;
            this.grpImage.Location = new System.Drawing.Point(6, 3);
            this.grpImage.Name = "grpImage";
            this.grpImage.Size = new System.Drawing.Size(827, 451);
            this.grpImage.TabIndex = 43;
            this.grpImage.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.GroupBox1.Controls.Add(this.chkCrop);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.nudCropWidth);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.nudCropHeight);
            this.GroupBox1.Location = new System.Drawing.Point(530, 460);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(218, 44);
            this.GroupBox1.TabIndex = 49;
            this.GroupBox1.TabStop = false;
            // 
            // chkCrop
            // 
            this.chkCrop.AutoSize = true;
            this.chkCrop.Enabled = false;
            this.chkCrop.Location = new System.Drawing.Point(6, 0);
            this.chkCrop.Name = "chkCrop";
            this.chkCrop.Size = new System.Drawing.Size(48, 17);
            this.chkCrop.TabIndex = 4;
            this.chkCrop.Text = "Crop";
            this.chkCrop.UseVisualStyleBackColor = true;
            this.chkCrop.CheckedChanged += new System.EventHandler(this.chkCrop_CheckedChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 21);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 13);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Width";
            // 
            // nudCropWidth
            // 
            this.nudCropWidth.Enabled = false;
            this.nudCropWidth.Location = new System.Drawing.Point(47, 18);
            this.nudCropWidth.Name = "nudCropWidth";
            this.nudCropWidth.Size = new System.Drawing.Size(50, 20);
            this.nudCropWidth.TabIndex = 6;
            this.nudCropWidth.ValueChanged += new System.EventHandler(this.nudCrop_ValueChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(114, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(38, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Height";
            // 
            // nudCropHeight
            // 
            this.nudCropHeight.Enabled = false;
            this.nudCropHeight.Location = new System.Drawing.Point(158, 18);
            this.nudCropHeight.Name = "nudCropHeight";
            this.nudCropHeight.Size = new System.Drawing.Size(50, 20);
            this.nudCropHeight.TabIndex = 8;
            this.nudCropHeight.ValueChanged += new System.EventHandler(this.nudCrop_ValueChanged);
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.Location = new System.Drawing.Point(91, 492);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(21, 12);
            this.Label3.TabIndex = 58;
            this.Label3.Text = "1%";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(841, 434);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(101, 13);
            this.lblSize.TabIndex = 53;
            this.lblSize.Text = "0 x 0";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::ImageResizer.Properties.Resources.delete;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(839, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 23);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Image = global::ImageResizer.Properties.Resources.import1;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(839, 35);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 23);
            this.btnLoad.TabIndex = 44;
            this.btnLoad.Text = "Load Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::ImageResizer.Properties.Resources.disk_blue;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(839, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox_RotateRight
            // 
            this.pictureBox_RotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_RotateRight.Image = global::ImageResizer.Properties.Resources.object_rotate_left_2___Copy;
            this.pictureBox_RotateRight.Location = new System.Drawing.Point(382, 468);
            this.pictureBox_RotateRight.Name = "pictureBox_RotateRight";
            this.pictureBox_RotateRight.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_RotateRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_RotateRight.TabIndex = 55;
            this.pictureBox_RotateRight.TabStop = false;
            this.pictureBox_RotateRight.Click += new System.EventHandler(this.pictureBox_RotateRight_Click);
            // 
            // pictureBox_RotateLeft
            // 
            this.pictureBox_RotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_RotateLeft.Image = global::ImageResizer.Properties.Resources.object_rotate_left_2;
            this.pictureBox_RotateLeft.Location = new System.Drawing.Point(344, 468);
            this.pictureBox_RotateLeft.Name = "pictureBox_RotateLeft";
            this.pictureBox_RotateLeft.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_RotateLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_RotateLeft.TabIndex = 55;
            this.pictureBox_RotateLeft.TabStop = false;
            this.pictureBox_RotateLeft.Click += new System.EventHandler(this.pictureBox_RotateLeft_Click);
            // 
            // picZoomIn
            // 
            this.picZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picZoomIn.Image = global::ImageResizer.Properties.Resources.ZoomIn48;
            this.picZoomIn.Location = new System.Drawing.Point(291, 468);
            this.picZoomIn.Name = "picZoomIn";
            this.picZoomIn.Size = new System.Drawing.Size(32, 32);
            this.picZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZoomIn.TabIndex = 55;
            this.picZoomIn.TabStop = false;
            this.picZoomIn.Click += new System.EventHandler(this.picZoomIn_Click);
            // 
            // picZoomOut
            // 
            this.picZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picZoomOut.Image = global::ImageResizer.Properties.Resources.ZoomOut48;
            this.picZoomOut.Location = new System.Drawing.Point(56, 468);
            this.picZoomOut.Name = "picZoomOut";
            this.picZoomOut.Size = new System.Drawing.Size(32, 32);
            this.picZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZoomOut.TabIndex = 54;
            this.picZoomOut.TabStop = false;
            this.picZoomOut.Click += new System.EventHandler(this.picZoomOut_Click);
            // 
            // ImageResizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox_RotateRight);
            this.Controls.Add(this.pictureBox_RotateLeft);
            this.Controls.Add(this.picZoomIn);
            this.Controls.Add(this.picZoomOut);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.grpImage);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.tbResize);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "ImageResizer";
            this.Size = new System.Drawing.Size(950, 507);
            this.SizeChanged += new System.EventHandler(this.EasyImageResizerControl_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageResizer_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EasyImageResizerControl_MouseClick);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbResize)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCropWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCropHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RotateRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RotateLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SaveFileDialog sfdImage;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label lblZoomFactor;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnLoad;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.PictureBox picZoomIn;
        internal System.Windows.Forms.PictureBox picZoomOut;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TrackBar tbResize;
        internal System.Windows.Forms.Panel grpImage;
        internal System.Windows.Forms.OpenFileDialog ofdImage;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkCrop;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown nudCropWidth;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown nudCropHeight;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblSize;
        internal System.Windows.Forms.PictureBox pictureBox_RotateLeft;
        internal System.Windows.Forms.PictureBox pictureBox_RotateRight;
    }
}
