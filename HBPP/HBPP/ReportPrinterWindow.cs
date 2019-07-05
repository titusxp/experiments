using System;
using System.Windows.Forms;

namespace HBPP
{
    public partial class ReportPrinterWindow : Form
    {
        private string url;
        public ReportPrinterWindow(string htmlFile)
        {
            InitializeComponent();
            url = htmlFile;
        }

        private void ReportPrinterWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
