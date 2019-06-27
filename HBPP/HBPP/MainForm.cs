using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                var value = printItemBindingSource.DataSource as List<PrintItem>;
                return value ?? new List<PrintItem>();
            }
            set
            {
                printItemBindingSource.DataSource = value
                    //.Where(i => string.IsNullOrWhiteSpace(i.Station) == false)
                    .OrderBy(i => i.Station).ThenBy(i => i.EmployeeName).ToList();
            }
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
                            Loan = ToDouble(row[3]?.Contents),
                            Interest = ToDouble(row[4]?.Contents),
                            Contribution = ToDouble(row[5]?.Contents),
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

        private double ToDouble(string stringValue)
        {
            double returnValue = 0;
            if (double.TryParse(stringValue, out returnValue))
            {
                return returnValue;
            }

            return 0;
        }

        private void button_GeneratePrintout_Click(object sender, EventArgs e)
        {
            var items = this.Items.OrderBy(i => i.Station).ThenBy(i => i.EmployeeName)
                .Take(100)
                .ToList();
            GenerateReportPrintOut(items);
        }

        private void GenerateReportPrintOut(List<PrintItem> items)
        {
            var cbchsLogo = Image.FromFile("cbchs.png");
            var hbppLogo = Image.FromFile("hbpp.jpeg");
            var signature = Image.FromFile("signature.jpeg");

            var cbchsLogoStream = "cbchs.png";//ToBase64(cbchsLogo);
            var hbppLogoStream = "hbpp.jpeg";//ToBase64(hbppLogo);
            var signatureStream = "signature.jpeg";//ToBase64(signature);

            this.button_GeneratePrintout.Enabled = this.button_Import.Enabled = false;
            this.loadingCircle1.Visible = this.label1.Visible = this.loadingCircle1.Active = true;

            var html = "<table style='width:720px;page-break-inside:auto; margin:auto; position: static; overflow: visible; display: block'>";

            Action<string> callBack = ShowProgress;
            Action start = () =>
            {
                var i = 1;
                var count = items.Count();
                foreach (var item in items)
                {
                    var span = GenerateReportHtml(item, cbchsLogoStream, hbppLogoStream, signatureStream);

                    if (i % 2 != 0)
                    {
                        html += $"<tr style='page-break-inside:avoid; page-break-after:auto'><td style='border:solid black;'>{span}</td>";
                    }
                    else
                    {
                        html += $"<td style='border:solid black;'>{span}</td></tr>";
                    }

                    callBack.Invoke(string.Format("{0} / {1}", i, count));
                    i++;
                }
                html += "</table>";
                var directoryName = "Cache";
                if (Directory.Exists(directoryName) == false)
                {
                    Directory.CreateDirectory(directoryName);
                }
                var fileName = $"{directoryName}\\{Guid.NewGuid()}.html";
                File.WriteAllText(fileName, html);
                Process.Start(fileName);

                Action end = () =>
                {
                    this.button_GeneratePrintout.Enabled = this.button_Import.Enabled = true;
                    this.loadingCircle1.Visible = this.label1.Visible = this.loadingCircle1.Active = false;
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
            var html =
$@"
<div style='width:350px; padding: 5px;'>
    <img src='../{cbcLogo}' style='width:50px; float:left'>
    <img src='../{hbppLogo}' style='width:50px; float:right'>
    <h4 style='text-align: center; margin: 0px;'>Health Board Pension Plan</h4>
    <h5 style='text-align: center; margin: 0px;font-size: 10pt'>699636342 - 677318383 - 674416300</h5>
    <h5 style='text-align: center; margin: 0px;'>June 30, 2019 Deductions</h5>
    <p style='text-align: center; margin: 0px;font-size: 8pt;'>{item.Station}</p>
    <hr />
    <table style='font-size: 12pt;width: 300px;margin:auto; border:0px'>
    		<tr>
    			<td colspan='2'> {item.EmployeeName}</td>
    		</tr>
    		<tr>
    			<td>Contributions:</td>
    			<td> {item.Contribution} FCFA</td>
    		</tr>
    		<tr>
    			<td>Loan Refund:</td>
    			<td> {item.Loan} FCFA</td>
    		</tr>
    		<tr style='padding:5px'>
    			<td>
                 <div style='position: relative;'>
                    <img src = '../black.png' style = 'width: 100%;height:20px' />
                    <div style = 'position: absolute; top: 0px; left: 0px;' >
                         Total:   
                    </div>
                </div >
                </td>
    			<td> 
                    <div style='position: relative;'>
                        <img src = '../black.png' style = 'width: 100%;height:20px' />
                        <div style = 'position: absolute; top: 0px; left: 0px;' >
                         {item.Total} FCFA    
                        </div>
                    </div >
                </td>
    		</tr>
            <tr>
    			<td>Sign:</td>
    			<td>
                    <img src='../{signature}' style='height:30px;width:100px'><br/>
    				<span style='font-size:10pt;font-style: italic'>HBPP Manager</span>
				</td>
    		</tr>
    	</table>
</div>
";
            return html;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
