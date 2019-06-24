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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contributionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_Import = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.easyHTMLReports1 = new KimToo.EasyHTMLReports(this.components);
            this.button_GeneratePrintout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.employeeNameDataGridViewTextBoxColumn,
            this.accountNumberDataGridViewTextBoxColumn,
            this.loanDataGridViewTextBoxColumn,
            this.interestDataGridViewTextBoxColumn,
            this.contributionDataGridViewTextBoxColumn,
            this.stationDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.printItemBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(1, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(947, 568);
            this.dataGridView.TabIndex = 0;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "EmployeeName";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountNumberDataGridViewTextBoxColumn
            // 
            this.accountNumberDataGridViewTextBoxColumn.DataPropertyName = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn.HeaderText = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn.Name = "accountNumberDataGridViewTextBoxColumn";
            this.accountNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loanDataGridViewTextBoxColumn
            // 
            this.loanDataGridViewTextBoxColumn.DataPropertyName = "Loan";
            this.loanDataGridViewTextBoxColumn.HeaderText = "Loan";
            this.loanDataGridViewTextBoxColumn.Name = "loanDataGridViewTextBoxColumn";
            this.loanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestDataGridViewTextBoxColumn
            // 
            this.interestDataGridViewTextBoxColumn.DataPropertyName = "Interest";
            this.interestDataGridViewTextBoxColumn.HeaderText = "Interest";
            this.interestDataGridViewTextBoxColumn.Name = "interestDataGridViewTextBoxColumn";
            this.interestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contributionDataGridViewTextBoxColumn
            // 
            this.contributionDataGridViewTextBoxColumn.DataPropertyName = "Contribution";
            this.contributionDataGridViewTextBoxColumn.HeaderText = "Contribution";
            this.contributionDataGridViewTextBoxColumn.Name = "contributionDataGridViewTextBoxColumn";
            this.contributionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stationDataGridViewTextBoxColumn
            // 
            this.stationDataGridViewTextBoxColumn.DataPropertyName = "Station";
            this.stationDataGridViewTextBoxColumn.HeaderText = "Station";
            this.stationDataGridViewTextBoxColumn.Name = "stationDataGridViewTextBoxColumn";
            this.stationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // printItemBindingSource
            // 
            this.printItemBindingSource.DataSource = typeof(HBPP.PrintItem);
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(1, 4);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(121, 23);
            this.button_Import.TabIndex = 1;
            this.button_Import.Text = "Import Data";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xlsx";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*csv";
            // 
            // easyHTMLReports1
            // 
            this.easyHTMLReports1.AlternativeRowBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.easyHTMLReports1.AlternativeRowGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(65)))));
            this.easyHTMLReports1.HeaderBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(183)))), ((int)(((byte)(197)))));
            this.easyHTMLReports1.HeaderFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(46)))));
            this.easyHTMLReports1.HeaderGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(65)))));
            this.easyHTMLReports1.RowDefaultBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.easyHTMLReports1.RowDefaultFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(46)))));
            this.easyHTMLReports1.RowDefaultGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(65)))));
            // 
            // button_GeneratePrintout
            // 
            this.button_GeneratePrintout.Location = new System.Drawing.Point(128, 4);
            this.button_GeneratePrintout.Name = "button_GeneratePrintout";
            this.button_GeneratePrintout.Size = new System.Drawing.Size(121, 23);
            this.button_GeneratePrintout.TabIndex = 1;
            this.button_GeneratePrintout.Text = "Generate Printout";
            this.button_GeneratePrintout.UseVisualStyleBackColor = true;
            this.button_GeneratePrintout.Click += new System.EventHandler(this.button_GeneratePrintout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 600);
            this.Controls.Add(this.button_GeneratePrintout);
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contributionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource printItemBindingSource;
        private KimToo.EasyHTMLReports easyHTMLReports1;
        private System.Windows.Forms.Button button_GeneratePrintout;
    }
}

