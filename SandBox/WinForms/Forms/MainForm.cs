using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinForms.Classes;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.dataGridView.Columns.Clear();
            var cols = new []
            {
                new MyGridViewColumn { DataPropertyName = "DOB", HeaderText = "DOB"},
                new MyGridViewColumn { DataPropertyName = "Name", HeaderText = "Name"},
                new MyGridViewColumn { DataPropertyName = "PhoneNumber", HeaderText = "PhoneNumber"}
            };
            this.dataGridView.Columns.AddRange(cols);

            this.dataGridView.Anchor = ((AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                              | System.Windows.Forms.AnchorStyles.Left)
                                                                             | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 22);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(940, 518);
            this.dataGridView.TabIndex = 1;

            this.dataGridView.DataSource = new List<Person>
            {
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
                new Person {DOB = new DateTime(1990,9,11), Name = "Titus Yusinyu", PhoneNumber = "67968428"},
            };

            this.dataGridView.LoadHeaderTextBoxes();
        }
    }
}
