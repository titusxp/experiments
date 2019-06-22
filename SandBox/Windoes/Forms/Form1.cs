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
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using WinForms.Classes;

namespace Windoes.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = new List<Person>
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
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var data = this.dataGridView1.DataSource;
            using (var p = new ExcelPackage())
            {
                //A workbook must have at least on cell, so lets add one... 
                var ws = p.Workbook.Worksheets.Add("MySheet");
                //To set values in the spreadsheet use the Cells indexer.
               
                ws.Cells[0,0].Value = "This is cell A1";
                //Save the new workbook. We haven't specified the filename so use the Save as method.
                var fileName = System.IO.Path.GetTempPath() + DateTime.Now.Ticks + "xls";
                p.SaveAs(new FileInfo(fileName));
                System.Diagnostics.Process.Start(fileName);

            }
        }
    }
}
