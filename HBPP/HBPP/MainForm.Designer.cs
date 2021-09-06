using System.Windows.Forms;

namespace HBPP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_Import = new System.Windows.Forms.Button();
            this.button_GeneratePrintout = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contributionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.flowLayoutPanel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xlsx";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*csv";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.employeeNameDataGridViewTextBoxColumn1,
            this.accountNumberDataGridViewTextBoxColumn1,
            this.loanDataGridViewTextBoxColumn1,
            this.interestDataGridViewTextBoxColumn1,
            this.contributionDataGridViewTextBoxColumn1,
            this.stationDataGridViewTextBoxColumn1,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.printItemBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(1, 50);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1272, 586);
            this.dataGridView.TabIndex = 4;
            // 
            // flowLayoutPanel_Buttons
            // 
            this.flowLayoutPanel_Buttons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Import);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_GeneratePrintout);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button3);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button1);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button2);
            this.flowLayoutPanel_Buttons.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanel_Buttons.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel_Buttons.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            this.flowLayoutPanel_Buttons.Size = new System.Drawing.Size(1269, 44);
            this.flowLayoutPanel_Buttons.TabIndex = 5;
            this.flowLayoutPanel_Buttons.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_Buttons_Paint);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(203, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 38);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // button_Import
            // 
            this.button_Import.Image = global::HBPP.Properties.Resources.FileExcel32x32;
            this.button_Import.Location = new System.Drawing.Point(0, 0);
            this.button_Import.Margin = new System.Windows.Forms.Padding(0);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(42, 41);
            this.button_Import.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_Import, "Import Excel Sheet");
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // button_GeneratePrintout
            // 
            this.button_GeneratePrintout.Image = global::HBPP.Properties.Resources.document_quickprint_5;
            this.button_GeneratePrintout.Location = new System.Drawing.Point(42, 0);
            this.button_GeneratePrintout.Margin = new System.Windows.Forms.Padding(0);
            this.button_GeneratePrintout.Name = "button_GeneratePrintout";
            this.button_GeneratePrintout.Size = new System.Drawing.Size(39, 41);
            this.button_GeneratePrintout.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_GeneratePrintout, "Generate Printout");
            this.button_GeneratePrintout.UseVisualStyleBackColor = true;
            this.button_GeneratePrintout.Click += new System.EventHandler(this.button_GeneratePrintout_Click);
            // 
            // button3
            // 
            this.button3.Image = global::HBPP.Properties.Resources.Tile_Icon_PrintDocs;
            this.button3.Location = new System.Drawing.Point(81, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 41);
            this.button3.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button3, "Generate Interest Printout");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Image = global::HBPP.Properties.Resources.ic_receipt;
            this.button1.Location = new System.Drawing.Point(117, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 41);
            this.button1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button1, "Generate Summary");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::HBPP.Properties.Resources.CommentsSummary;
            this.button2.Location = new System.Drawing.Point(157, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 41);
            this.button2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button2, "Generate Interest Summary");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.codeDataGridViewTextBoxColumn1.Width = 125;
            // 
            // employeeNameDataGridViewTextBoxColumn1
            // 
            this.employeeNameDataGridViewTextBoxColumn1.DataPropertyName = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn1.HeaderText = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.employeeNameDataGridViewTextBoxColumn1.Name = "employeeNameDataGridViewTextBoxColumn1";
            this.employeeNameDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.employeeNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // accountNumberDataGridViewTextBoxColumn1
            // 
            this.accountNumberDataGridViewTextBoxColumn1.DataPropertyName = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn1.HeaderText = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.accountNumberDataGridViewTextBoxColumn1.Name = "accountNumberDataGridViewTextBoxColumn1";
            this.accountNumberDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.accountNumberDataGridViewTextBoxColumn1.Width = 125;
            // 
            // loanDataGridViewTextBoxColumn1
            // 
            this.loanDataGridViewTextBoxColumn1.DataPropertyName = "Loan";
            this.loanDataGridViewTextBoxColumn1.HeaderText = "Loan";
            this.loanDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.loanDataGridViewTextBoxColumn1.Name = "loanDataGridViewTextBoxColumn1";
            this.loanDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.loanDataGridViewTextBoxColumn1.Width = 125;
            // 
            // interestDataGridViewTextBoxColumn1
            // 
            this.interestDataGridViewTextBoxColumn1.DataPropertyName = "Interest";
            this.interestDataGridViewTextBoxColumn1.HeaderText = "Interest";
            this.interestDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.interestDataGridViewTextBoxColumn1.Name = "interestDataGridViewTextBoxColumn1";
            this.interestDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.interestDataGridViewTextBoxColumn1.Width = 125;
            // 
            // contributionDataGridViewTextBoxColumn1
            // 
            this.contributionDataGridViewTextBoxColumn1.DataPropertyName = "Contribution";
            this.contributionDataGridViewTextBoxColumn1.HeaderText = "Contribution";
            this.contributionDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.contributionDataGridViewTextBoxColumn1.Name = "contributionDataGridViewTextBoxColumn1";
            this.contributionDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.contributionDataGridViewTextBoxColumn1.Width = 125;
            // 
            // stationDataGridViewTextBoxColumn1
            // 
            this.stationDataGridViewTextBoxColumn1.DataPropertyName = "Station";
            this.stationDataGridViewTextBoxColumn1.HeaderText = "Station";
            this.stationDataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.stationDataGridViewTextBoxColumn1.Name = "stationDataGridViewTextBoxColumn1";
            this.stationDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.stationDataGridViewTextBoxColumn1.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // printItemBindingSource
            // 
            this.printItemBindingSource.DataSource = typeof(HBPP.PrintItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 636);
            this.Controls.Add(this.flowLayoutPanel_Buttons);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.flowLayoutPanel_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.BindingSource printItemBindingSource;
        private System.Windows.Forms.Button button_GeneratePrintout;
        private DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contributionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel_Buttons;
        private Button button2;
        private DateTimePicker dateTimePicker1;
        private Button button3;
        private ToolTip toolTip1;
    }
}

