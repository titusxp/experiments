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
            var items = this.Items.OrderBy(i => i.Station).ThenBy(i => i.EmployeeName).ToList();
            GenerateReportPrintOut(items);
        }

        private void GenerateReportPrintOut(List<PrintItem> items)
        {

            var cbchsLogoStream = "cbchs.png";
            var hbppLogoStream = "hbpp.jpeg";
            var signatureStream = "signature.jpeg";


            ToggleWaiting(showWaitForm: true);

            var html = "<table style='width:720px;page-break-inside:auto; margin:auto; position: static; overflow: visible; display: block'>";

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

                    i++;
                }
                html += "</table>";

                Action end = () =>
                {
                    ReportPrinter.PrintReport(html);
                    ToggleWaiting(showWaitForm: false);
                };

                this.Invoke(end);
            };
            start.BeginInvoke(null, null);

        }


        //public string ToBase64(Image image)
        //{
        //    using (MemoryStream m = new MemoryStream())
        //    {
        //        image.Save(m, image.RawFormat);
        //        byte[] imageBytes = m.ToArray();

        //        // Convert byte[] to Base64 String
        //        string base64String = Convert.ToBase64String(imageBytes);
        //        return base64String;
        //    }
        //}

        private DateTime DateTime => this.dateTimePicker1.Value;
        private string GenerateReportHtml(PrintItem item, string cbcLogo, string hbppLogo, string signature)
        {
            var html = $@"
                        <div style='width:350px; padding: 5px;'>
                            <img src='../{cbcLogo}' style='width:50px; float:left'>
                            <img src='../{hbppLogo}' style='width:50px; float:right'>
                            <h4 style='text-align: center; margin: 0px;'>Health Board Pension Plan</h4>
                            <h5 style='text-align: center; margin: 0px;font-size: 10pt'>699636342 - 677318383 - 674416300</h5>
                            <h5 style='text-align: center; margin: 0px;'>{DateTime: MMM dd, yyyy} Deductions</h5>
                            <p style='text-align: center; margin: 0px;font-size: 8pt;'>{item.Station}</p>
                            <hr />
                            <table style='font-size: 12pt;width: 300px;margin:auto; border:0px'>
    		                        <tr>
    			                        <td colspan='2'> {item.EmployeeName}</td>
    		                        </tr>
    		                        <tr>
    			                        <td>Contributions:</td>
    			                        <td style = 'text-align:right;'> {String.Format("{0:n0}", item.Contribution)} FCFA</td>
    		                        </tr>
    		                        <tr>
    			                        <td>Loan Refund:</td>
    			                        <td style = 'text-align:right;'> {String.Format("{0:n0}", item.Loan)} FCFA</td>
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
                                                <div style = 'width: 100%;text-align:right; position: absolute; top: 0px; left: 0px;' >
                                                    {String.Format("{0:n0}", item.Total)} FCFA    
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

        private void ToggleWaiting(bool showWaitForm)
        {
            //this.flowLayoutPanel_Buttons.Enabled = !showWaitForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleWaiting(showWaitForm: true);
            var items = this.Items.GroupBy(i => i.Station);

            Action start = () =>
            {
                var html = @"
                            <html>
                                <head>
                                    <title>Summaries</title>
                                    <link rel='stylesheet' href='../site.css' />
                                </head>
                                <body>";
                                        foreach (var item in items)
                                        {
                                            var vals = item.Select(i => i).OrderBy(i => i.EmployeeName).ToList();
                                            html += GenerateSummaryHtml(vals);
                                        }

                                        html += @"
                                </body>
                            <html>";


                Action end = () =>
                {
                    ReportPrinter.PrintReport(html);

                    ToggleWaiting(showWaitForm:false);
                };

                this.Invoke(end);
            };


            start.BeginInvoke(null, null);
        }

        private string GenerateSummaryHtml(List<PrintItem> items)
        {
            var cbcLogo = "cbchs.png";
            var hbppLogo = "hbpp.jpeg";
            var item = items.FirstOrDefault();
            var html =
                $@"
                    <div style='width:800px; padding: 5px; margin:auto;'>
                        <img src='../{cbcLogo}' style='width:80px; float:left'>
                        <img src='../{hbppLogo}' style='width:80px; float:right'>
                        <h4 style='text-align: center; margin: 0px;'>HEALTH BOARD PENSION PLAN</h4>
                        <h5 style='text-align: center; margin: 0px;font-size: 10pt'>P O Box 01-NKWEN BAMENDA</h5>
                        <h5 style='text-align: center; margin: 0px;font-size: 10pt'>TEL: 699636342 - 677318383 - 674416300</h5>
                        <h5 style='text-align: center; margin: 0px;'>Email: cbchshbpp@yahoo.com</h5>
                        <h5 style='text-align: center; margin: 0px;'>{DateTime: yyyy} Interest on Contributions</h5>
                        <p style='text-align: center; margin: 0px;font-size: 8pt;'>Station: {item?.Station}</p>
                        <hr />
                        <table id='summaryTable' style='font-size: 12pt;width:100%; margin:auto; border:solid black 1px'>
    	                    <tr>
                                   <th>NO:</th> 
                                   <th>CODE</th> 
                                   <th>MEMBER'S NAME</th> 
                                   <th>INTEREST</th> 
                                </tr>";

                                var x = 1;
                                foreach (var i in items)
                                {
                                    html += $@"
                                    <tr>
                                       <td>{x}</td> 
                                       <td>{i.Code}</td> 
                                       <td>{i.EmployeeName}</td>  
                                       <td style = 'text-align:right;'>{String.Format("{0:n0}", i.Interest)}</td> 
                                    </tr>";
                                    x++;
                                }

                            var totalLoan = items.Sum(ii => ii.Loan);
                            var totalContribution = items.Sum(ii => ii.Contribution);
                            var totalTotal = items.Sum(ii => ii.Interest);

                            html += $@"
                                    <tr>
                                       <td colspan='3' style = 'text-align:right;'>Total</td> 
                                       <td style = 'text-align:right;'>{String.Format("{0:n0}", totalTotal)}</td> 
                                    </tr>
                        </table>
                        <br/><br/>
                        <table style='width:100%;border:none;'>
                            <tr>
                                <td>Prepared By:</td>
                                <td>Checked By:</td>
                            </tr>
                        </table>
                        <div style='height:50px;'></div>
                    </div>";

            return html;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToggleWaiting(showWaitForm: true);
            var items = this.Items.GroupBy(i => i.Station);

            Action start = () =>
            {
                var html = @"
                            <html>
                                <head>
                                    <title>Summaries</title>
                                    <link rel='stylesheet' href='../site.css' />
                                </head>
                                <body>";
                foreach (var item in items)
                {
                    var vals = item.Select(i => i).OrderBy(i => i.EmployeeName).ToList();
                    html += GenerateSummaryHtml(vals);
                }

                html += @"
                                </body>
                            <html>";


                Action end = () =>
                {
                    ReportPrinter.PrintReport(html);

                    ToggleWaiting(showWaitForm: false);
                };

                this.Invoke(end);
            };


            start.BeginInvoke(null, null);
        }
    }
}
