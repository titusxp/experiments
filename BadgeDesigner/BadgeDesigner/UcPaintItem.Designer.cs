namespace BadgeDesigner
{
    partial class UcPaintItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_FontName = new System.Windows.Forms.Label();
            this.label_Size = new System.Windows.Forms.Label();
            this.label_Colour = new System.Windows.Forms.Label();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.paintItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_Delete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button_Delete);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label_FontName);
            this.groupBox1.Controls.Add(this.label_Size);
            this.groupBox1.Controls.Add(this.label_Colour);
            this.groupBox1.Controls.Add(this.numericUpDown_Y);
            this.groupBox1.Controls.Add(this.numericUpDown_X);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paintItemBindingSource, "ItemCaption", true));
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 73);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ItemName";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paintItemBindingSource, "ItemValue", true));
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(598, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(342, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(604, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_FontName
            // 
            this.label_FontName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FontName.BackColor = System.Drawing.Color.White;
            this.label_FontName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paintItemBindingSource, "FontName", true));
            this.label_FontName.Location = new System.Drawing.Point(238, 46);
            this.label_FontName.Name = "label_FontName";
            this.label_FontName.Size = new System.Drawing.Size(113, 20);
            this.label_FontName.TabIndex = 3;
            // 
            // label_Size
            // 
            this.label_Size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Size.BackColor = System.Drawing.Color.White;
            this.label_Size.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Size.Location = new System.Drawing.Point(411, 46);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(80, 20);
            this.label_Size.TabIndex = 3;
            // 
            // label_Colour
            // 
            this.label_Colour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Colour.BackColor = System.Drawing.Color.White;
            this.label_Colour.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.paintItemBindingSource, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label_Colour.Location = new System.Drawing.Point(554, 47);
            this.label_Colour.Name = "label_Colour";
            this.label_Colour.Size = new System.Drawing.Size(57, 20);
            this.label_Colour.TabIndex = 3;
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.paintItemBindingSource, "Y", true));
            this.numericUpDown_Y.Location = new System.Drawing.Point(120, 44);
            this.numericUpDown_Y.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(55, 24);
            this.numericUpDown_Y.TabIndex = 2;
            this.numericUpDown_Y.ValueChanged += new System.EventHandler(this.numericUpDown_X_ValueChanged);
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.paintItemBindingSource, "X", true));
            this.numericUpDown_X.Location = new System.Drawing.Point(26, 44);
            this.numericUpDown_X.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(55, 24);
            this.numericUpDown_X.TabIndex = 2;
            this.numericUpDown_X.Visible = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(506, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Colour";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(378, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Size";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(101, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Y";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(201, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Font";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.fontDialog1.FontMustExist = true;
            // 
            // paintItemBindingSource
            // 
            this.paintItemBindingSource.DataSource = typeof(BadgeDesigner.PaintItem);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Delete.Image = global::BadgeDesigner.Properties.Resources.delete;
            this.button_Delete.Location = new System.Drawing.Point(604, 17);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(30, 23);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // UcPaintItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.groupBox1);
            this.Name = "UcPaintItem";
            this.Size = new System.Drawing.Size(637, 73);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Colour;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.BindingSource paintItemBindingSource;
        private System.Windows.Forms.Label label_FontName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Size;
        private System.Windows.Forms.Button button_Delete;
    }
}

