using Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var sheet = Workbook.Worksheets(@"D:\savings.xlsx").FirstOrDefault();
            var header = sheet.Rows.FirstOrDefault();
            //var xxx = header.Cells.Select(r => //r.Text).ToList()
            //{
            //    try
            //    {

            //        var a = DateTime.FromOADate(r.Amount);
            //        return a.ToString();
            //    }
            //    catch(Exception ex)
            //    {
            //        return "";
            //    }
            //}).ToList();
            var i = -1;
            var report = string.Empty;
            foreach (var row in sheet.Rows)
            {
                i++;
                if(i < 2)
                {
                    continue;
                }

                var name = row.Cells[0].Text;
                var total = row.Cells[1].Text;
                report += $"{Environment.NewLine}{Environment.NewLine}{name}";
                for(var x = 2;  x < sheet.NumberOfColumns; x++)
                {
                    var amount = row.Cells[x].Text;
                    if (string.IsNullOrWhiteSpace(amount) == false)
                    {
                        var date = DateTime.FromOADate(header.Cells[x].Amount);
                        report += $"{Environment.NewLine}{date: dd-MMM-yyyy} :  {amount: 10}";
                    }
                }
                report += $"{Environment.NewLine}------------------------------{Environment.NewLine}TOTAL :  {total: 10}";
            }
            Application.Run(new Form1());
        }
    }
}
