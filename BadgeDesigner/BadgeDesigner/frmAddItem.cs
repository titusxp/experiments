using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadgeDesigner
{
    public partial class frmAddItem : Form
    {
        public Action<string> OKButtonClicked;
        public frmAddItem()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_ItemCaption.Text))
            {
                MessageBox.Show("Please type item caption");
                return;
            }
            OKButtonClicked?.Invoke(textBox_ItemCaption.Text);
            this.Close();
        }
    }
}
