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

        private string[,] Data = {};
        private string[] heading = { };

        private void button_Import_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var app = Workbook.getWorkbook(filePath);
                var firstSheet = app.Sheets?.FirstOrDefault();
                var columnCount = firstSheet?.Columns ?? 0;
                var rowCount = firstSheet?.Rows ?? 0;
                Data = new string[rowCount, columnCount];
                heading = new string[columnCount];
                var headingCells = firstSheet.getRow(0);
                for (int j = 0; j < columnCount; j++)
                {
                    var content = headingCells[j]?.Contents;
                    heading[j] = content;
                }

                for (int i = 1; i < rowCount; i++)
                {
                    var row = firstSheet.getRow(i);
                    for (int j = 0; j < columnCount; j++)
                    {
                        var content = row[j]?.Contents;
                        Data[i, j] = content;
                    }
                }
            }
        }
    }
}
