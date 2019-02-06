namespace BadgeDesigner
{
    partial class ImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.imageResizer1 = new ImageResizer.ImageResizer();
            this.SuspendLayout();
            // 
            // imageResizer1
            // 
            this.imageResizer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageResizer1.Location = new System.Drawing.Point(0, 0);
            this.imageResizer1.MinimumSize = new System.Drawing.Size(550, 300);
            this.imageResizer1.Name = "imageResizer1";
            this.imageResizer1.RequiredHeight = 0;
            this.imageResizer1.RequiredWidth = 0;
            this.imageResizer1.Size = new System.Drawing.Size(978, 452);
            this.imageResizer1.StandAloneMode = true;
            this.imageResizer1.TabIndex = 0;
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 452);
            this.Controls.Add(this.imageResizer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageEditor";
            this.Text = "Image Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private ImageResizer.ImageResizer imageResizer1;
    }
}