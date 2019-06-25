using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            var cbchsLogo = Image.FromFile("cbchs.png");
            var hbppLogo = Image.FromFile("hbpp.jpeg");
            var signature = Image.FromFile("signature.jpeg");

            var cbchsLogoStream = ToBase64(cbchsLogo);
            var hbppLogoStream = ToBase64(hbppLogo);
            var signatureStream = ToBase64(signature);

            this.button_GeneratePrintout.Enabled = this.button_Import.Enabled = false;
            this.loadingCircle1.Visible = this.label1.Visible = this.loadingCircle1.Active = true;

            var html = "";

            Action<string> callBack = ShowProgress;
            Action start = () =>
            {
                var i = 1;
                var count = items.Count();
                foreach (var item in items)
                {
                    html += GenerateReportHtml(item, cbchsLogoStream, hbppLogoStream, signatureStream);
                    callBack.Invoke(string.Format("{0} / {1}", i, count));
                    i++;
                }

                Action end = () =>
                {
                    this.easyHTMLReports1.AddString(html);
                    this.button_GeneratePrintout.Enabled = this.button_Import.Enabled = true;
                    this.loadingCircle1.Visible = this.label1.Visible = this.loadingCircle1.Active = false;
                    this.easyHTMLReports1.ShowPrintPreviewDialog();
                };

                this.Invoke(end);
            };
            start.BeginInvoke(null, null);

        }

        private void ShowProgress(string progressMessage)
        {
            Action showData = () =>
            {
                this.label1.Text = progressMessage;
            };
            try
            {
                this.Invoke(showData);
            }
            catch (Exception ex)
            {

            }
            
        }

        public string ToBase64(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private string GenerateReportHtml(PrintItem item, string cbcLogo, string hbppLogo, string signature)
        {
            // return @"<span style='width=100px;border: solid black;'>Test</span>";
            return
$@"
<span style='width: 360px; margin:5px; border:solid black; padding: 5px; display: inline-block;'>
    <img src='data:image/png;base64,{cbcLogo}' style='width:50px; float:left'>
    <img src='data:image/jpeg;base64,{hbppLogo}' style='width:50px; float:right'>
    <h4 style='text-align: center; margin: 0px;'>Health Board Pension Plan</h4>
    <h5 style='text-align: center; margin: 0px;'>699636342 - 677318383 - 674416300</h5>
    <h5 style='text-align: center; margin: 0px;'>June 30, 2019 Deductions</h5>
    <p style='text-align: center; margin: 0px;font-size: 8pt;'>{item.Station}</p>
    <hr />
    <table style='font-size: 12pt;width: 300px;margin:auto'>
    		<tr>
    			<td colspan='2'> {item.EmployeeName}</td>
    		</tr>
    		<tr>
    			<td>Contributions:</td>
    			<td> {item.Contribution} FCFA</td>
    		</tr>
    		<tr>
    			<td>Loan Refund:</td>
    			<td> {item.LoanInteger} FCFA</td>
    		</tr>
    		<tr style='color:white;background-color:#555''>
    			<td>Total:</td>
    			<td> {item.Total} FCFA</td>
    		</tr>
            <tr>
    			<td>Sign:</td>
    			<td>
                    <img src='data:image/jpeg;base64,{signature}' style='height:30px;width:100px'><br/>
    				<span style='font-size:10pt;font-style: italic'>HBPP Manager</span>
				</td>
    		</tr>
    	</table>
</span>
";
        }
    }
}
