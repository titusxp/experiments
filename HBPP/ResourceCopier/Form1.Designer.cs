namespace ResourceCopier
{
    partial class Form1
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
            this.button_Start = new System.Windows.Forms.Button();
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Source = new System.Windows.Forms.TextBox();
            this.button_Browse_Source = new System.Windows.Forms.Button();
            this.openFileDialog_Source = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Destination = new System.Windows.Forms.TextBox();
            this.button_Browse_Destination = new System.Windows.Forms.Button();
            this.openFileDialog_Destination = new System.Windows.Forms.OpenFileDialog();
            this.label_Status = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(222, 158);
            this.button_Start.Margin = new System.Windows.Forms.Padding(2);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(128, 28);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(202, 3);
            this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(175, 26);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Resource Copier";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Source);
            this.groupBox1.Controls.Add(this.button_Browse_Source);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // textBox_Source
            // 
            this.textBox_Source.Location = new System.Drawing.Point(6, 19);
            this.textBox_Source.Name = "textBox_Source";
            this.textBox_Source.Size = new System.Drawing.Size(414, 20);
            this.textBox_Source.TabIndex = 0;
            this.textBox_Source.Text = "C:\\Users\\titus\\Desktop\\New folder\\Translatable Resources-1.Beleck_05.08.2019.xlsx" +
    "";
            // 
            // button_Browse_Source
            // 
            this.button_Browse_Source.Location = new System.Drawing.Point(425, 19);
            this.button_Browse_Source.Margin = new System.Windows.Forms.Padding(2);
            this.button_Browse_Source.Name = "button_Browse_Source";
            this.button_Browse_Source.Size = new System.Drawing.Size(97, 21);
            this.button_Browse_Source.TabIndex = 2;
            this.button_Browse_Source.Text = "Browse";
            this.button_Browse_Source.UseVisualStyleBackColor = true;
            this.button_Browse_Source.Click += new System.EventHandler(this.Button_Browse_Source_Click);
            // 
            // openFileDialog_Source
            // 
            this.openFileDialog_Source.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Destination);
            this.groupBox2.Controls.Add(this.button_Browse_Destination);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 45);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // textBox_Destination
            // 
            this.textBox_Destination.Location = new System.Drawing.Point(6, 19);
            this.textBox_Destination.Name = "textBox_Destination";
            this.textBox_Destination.Size = new System.Drawing.Size(414, 20);
            this.textBox_Destination.TabIndex = 0;
            this.textBox_Destination.Text = "C:\\Users\\titus\\Desktop\\2019_08_28_14_32.xlsx";
            // 
            // button_Browse_Destination
            // 
            this.button_Browse_Destination.Location = new System.Drawing.Point(425, 19);
            this.button_Browse_Destination.Margin = new System.Windows.Forms.Padding(2);
            this.button_Browse_Destination.Name = "button_Browse_Destination";
            this.button_Browse_Destination.Size = new System.Drawing.Size(97, 21);
            this.button_Browse_Destination.TabIndex = 2;
            this.button_Browse_Destination.Text = "Browse";
            this.button_Browse_Destination.UseVisualStyleBackColor = true;
            this.button_Browse_Destination.Click += new System.EventHandler(this.Button_Browse_Destination_Click);
            // 
            // openFileDialog_Destination
            // 
            this.openFileDialog_Destination.FileName = "openFileDialog1";
            // 
            // label_Status
            // 
            this.label_Status.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Status.ForeColor = System.Drawing.Color.Red;
            this.label_Status.Location = new System.Drawing.Point(11, 118);
            this.label_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(531, 26);
            this.label_Status.TabIndex = 3;
            this.label_Status.Text = "Resource Copier";
            this.label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(540, 248);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.helloWorldLabel);
            this.Controls.Add(this.button_Start);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Resource Copier";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Source;
        private System.Windows.Forms.Button button_Browse_Source;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Source;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Destination;
        private System.Windows.Forms.Button button_Browse_Destination;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Destination;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

