namespace BadgeDesigner
{
    partial class PaintBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintBoard));
            this.pictureBox_Badge = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.button_Apply = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_SaveChanges = new System.Windows.Forms.Button();
            this.pictureBox_DP = new System.Windows.Forms.PictureBox();
            this.profilePicturePaintItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_Browse = new System.Windows.Forms.Button();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_PrintBadge = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_PrintList = new System.Windows.Forms.FlowLayoutPanel();
            this.button_AddToPrintList = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown_BadgeHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_BadgeWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_NewItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Badge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicturePaintItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BadgeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BadgeWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Badge
            // 
            this.pictureBox_Badge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Badge.Image = global::BadgeDesigner.Properties.Resources.templae;
            this.pictureBox_Badge.Location = new System.Drawing.Point(1, 1);
            this.pictureBox_Badge.Name = "pictureBox_Badge";
            this.pictureBox_Badge.Size = new System.Drawing.Size(420, 621);
            this.pictureBox_Badge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Badge.TabIndex = 0;
            this.pictureBox_Badge.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(423, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(748, 370);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Apply.Location = new System.Drawing.Point(656, 628);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 2;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Visible = false;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(735, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_SaveChanges
            // 
            this.button_SaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SaveChanges.Location = new System.Drawing.Point(1020, 628);
            this.button_SaveChanges.Name = "button_SaveChanges";
            this.button_SaveChanges.Size = new System.Drawing.Size(148, 23);
            this.button_SaveChanges.TabIndex = 2;
            this.button_SaveChanges.Text = "Save Configuration";
            this.button_SaveChanges.UseVisualStyleBackColor = true;
            this.button_SaveChanges.Click += new System.EventHandler(this.button_SaveChanges_Click);
            // 
            // pictureBox_DP
            // 
            this.pictureBox_DP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_DP.BackColor = System.Drawing.Color.Teal;
            this.pictureBox_DP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_DP.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.profilePicturePaintItemBindingSource, "ProfilePicture", true));
            this.pictureBox_DP.Location = new System.Drawing.Point(4, 77);
            this.pictureBox_DP.Name = "pictureBox_DP";
            this.pictureBox_DP.Size = new System.Drawing.Size(138, 143);
            this.pictureBox_DP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DP.TabIndex = 3;
            this.pictureBox_DP.TabStop = false;
            // 
            // profilePicturePaintItemBindingSource
            // 
            this.profilePicturePaintItemBindingSource.DataSource = typeof(BadgeDesigner.ProfilePicturePaintItem);
            // 
            // button_Browse
            // 
            this.button_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Browse.ForeColor = System.Drawing.Color.Black;
            this.button_Browse.Location = new System.Drawing.Point(146, 197);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(123, 23);
            this.button_Browse.TabIndex = 2;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.profilePicturePaintItemBindingSource, "X", true));
            this.numericUpDown_X.Location = new System.Drawing.Point(211, 75);
            this.numericUpDown_X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_X.TabIndex = 4;
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.profilePicturePaintItemBindingSource, "Y", true));
            this.numericUpDown_Y.Location = new System.Drawing.Point(211, 101);
            this.numericUpDown_Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_Y.TabIndex = 4;
            // 
            // numericUpDown_Width
            // 
            this.numericUpDown_Width.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.profilePicturePaintItemBindingSource, "Width", true));
            this.numericUpDown_Width.Location = new System.Drawing.Point(211, 127);
            this.numericUpDown_Width.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Width.Name = "numericUpDown_Width";
            this.numericUpDown_Width.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_Width.TabIndex = 4;
            // 
            // numericUpDown_Height
            // 
            this.numericUpDown_Height.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.profilePicturePaintItemBindingSource, "Height", true));
            this.numericUpDown_Height.Location = new System.Drawing.Point(211, 153);
            this.numericUpDown_Height.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Height.Name = "numericUpDown_Height";
            this.numericUpDown_Height.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_Height.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Height";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.pictureBox_DP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_Browse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_X);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown_Y);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_Width);
            this.groupBox1.Controls.Add(this.numericUpDown_Height);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(427, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 226);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load DP";
            // 
            // button_PrintBadge
            // 
            this.button_PrintBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_PrintBadge.Location = new System.Drawing.Point(944, 628);
            this.button_PrintBadge.Name = "button_PrintBadge";
            this.button_PrintBadge.Size = new System.Drawing.Size(75, 23);
            this.button_PrintBadge.TabIndex = 2;
            this.button_PrintBadge.Text = "Print Badge";
            this.button_PrintBadge.UseVisualStyleBackColor = true;
            this.button_PrintBadge.Click += new System.EventHandler(this.button_PrintBadge_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.flowLayoutPanel_PrintList);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(706, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 227);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print List";
            // 
            // flowLayoutPanel_PrintList
            // 
            this.flowLayoutPanel_PrintList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_PrintList.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_PrintList.Name = "flowLayoutPanel_PrintList";
            this.flowLayoutPanel_PrintList.Size = new System.Drawing.Size(459, 208);
            this.flowLayoutPanel_PrintList.TabIndex = 0;
            // 
            // button_AddToPrintList
            // 
            this.button_AddToPrintList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_AddToPrintList.Location = new System.Drawing.Point(2, 628);
            this.button_AddToPrintList.Name = "button_AddToPrintList";
            this.button_AddToPrintList.Size = new System.Drawing.Size(98, 23);
            this.button_AddToPrintList.TabIndex = 2;
            this.button_AddToPrintList.Text = "Add to Print List";
            this.button_AddToPrintList.UseVisualStyleBackColor = true;
            this.button_AddToPrintList.Click += new System.EventHandler(this.button_AddToPrintList_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(848, 628);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clear Print List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown_BadgeHeight
            // 
            this.numericUpDown_BadgeHeight.Location = new System.Drawing.Point(299, 629);
            this.numericUpDown_BadgeHeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_BadgeHeight.Name = "numericUpDown_BadgeHeight";
            this.numericUpDown_BadgeHeight.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_BadgeHeight.TabIndex = 4;
            // 
            // numericUpDown_BadgeWidth
            // 
            this.numericUpDown_BadgeWidth.Location = new System.Drawing.Point(169, 630);
            this.numericUpDown_BadgeWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_BadgeWidth.Name = "numericUpDown_BadgeWidth";
            this.numericUpDown_BadgeWidth.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_BadgeWidth.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 632);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 633);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Height";
            // 
            // button_NewItem
            // 
            this.button_NewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_NewItem.Location = new System.Drawing.Point(1076, 1);
            this.button_NewItem.Name = "button_NewItem";
            this.button_NewItem.Size = new System.Drawing.Size(95, 23);
            this.button_NewItem.TabIndex = 2;
            this.button_NewItem.Text = "New Item";
            this.button_NewItem.UseVisualStyleBackColor = true;
            this.button_NewItem.Click += new System.EventHandler(this.button_NewItem_Click);
            // 
            // PaintBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 655);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_SaveChanges);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_NewItem);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_PrintBadge);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_AddToPrintList);
            this.Controls.Add(this.numericUpDown_BadgeWidth);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.numericUpDown_BadgeHeight);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox_Badge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaintBoard";
            this.Text = "Badge Designer";
            this.Load += new System.EventHandler(this.PaintBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Badge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicturePaintItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BadgeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BadgeWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Badge;
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_SaveChanges;
        private System.Windows.Forms.PictureBox pictureBox_DP;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_Width;
        private System.Windows.Forms.NumericUpDown numericUpDown_Height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource profilePicturePaintItemBindingSource;
        private System.Windows.Forms.Button button_PrintBadge;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_PrintList;
        private System.Windows.Forms.Button button_AddToPrintList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown_BadgeHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_BadgeWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_NewItem;
    }
}

