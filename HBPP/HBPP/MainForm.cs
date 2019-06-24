using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NExcel;

namespace HBPP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<PrintItem> Items
        {
            get
            {
                var value = dataGridView.DataSource as List<PrintItem>;
                return value ?? new List<PrintItem>();
            }
            set { dataGridView.DataSource = value; }
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog.FileName;
                    var app = Workbook.getWorkbook(filePath);
                    var firstSheet = app.Sheets?.FirstOrDefault();
                    var rowCount = firstSheet?.Rows ?? 0;

                    var items = new List<PrintItem>();


                    for (int i = 1; i < rowCount; i++)
                    {
                        var row = firstSheet.getRow(i);
                        var item = new PrintItem
                        {
                            Code = row[0]?.Contents,
                            EmployeeName = row[1]?.Contents,
                            AccountNumber = row[2]?.Contents,
                            Loan = row[3]?.Contents,
                            Interest = row[4]?.Contents,
                            Contribution = row[5]?.Contents,
                            Station = row[6]?.Contents,
                        };
                        items.Add(item);
                    }

                    Items = items;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error Occured");
                }
            }
        }

        private void button_GeneratePrintout_Click(object sender, EventArgs e)
        {
            GenerateReportPrintOut(this.Items);
        }

        private void GenerateReportPrintOut(List<PrintItem> items)
        {
            foreach (var item in items)
            {
                var html = GenerateReportHtml(item);
                this.easyHTMLReports1.AddString(html);
            }

            this.easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private string GenerateReportHtml(PrintItem item)
        {
            return 
$@"
<div style='color:red'>
    {item.EmployeeName}
</div
";

        }
    }
}
