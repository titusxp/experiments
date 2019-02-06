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
    public partial class UcPaintItem : UserControl
    {
        public Action<PaintItem> ItemUpdated;
        private bool Loaded;
        public UcPaintItem()
        {
            InitializeComponent();
            this.Load += (s, e) => { this.Loaded = true; };
        }

        public PaintItem PaintItem
        {
            get { return this.paintItemBindingSource.DataSource as PaintItem;}
            set
            {
                this.paintItemBindingSource.DataSource = value;
                this.label_FontName.Text = this.PaintItem.FontStyle.Name;
                this.label_FontName.Font = new Font(this.PaintItem.FontStyle.FontFamily, 9, FontStyle.Regular);
                this.label_Size.Text = this.PaintItem.FontStyle.Size + "";
                this.fontDialog1.Font = this.PaintItem.FontStyle;
                this.comboBox1.Items.Clear();
                if(value.ItemsList != null && value.ItemsList.Any())
                {
                    foreach (var i in value.ItemsList.OrderBy(i => i))
                    {
                        comboBox1.Items.Add(i);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            this.PaintItem.FontStyle = this.fontDialog1.Font;
            this.label_FontName.Text = this.PaintItem.FontStyle.Name;
            this.label_FontName.Font = new Font(this.PaintItem.FontStyle.FontFamily, 9, FontStyle.Regular);
            this.label_Size.Text = this.PaintItem.FontStyle.Size + "";

            if (Loaded)
            {
                ItemUpdated?.Invoke(this.PaintItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.PaintItem.FontColor = colorDialog1.Color;
            this.label_Colour.BackColor = this.PaintItem.FontColor;
            if (Loaded)
            {
                ItemUpdated?.Invoke(this.PaintItem);
            }
        }

        private void numericUpDown_X_ValueChanged(object sender, EventArgs e)
        {
            this.PaintItem.Y = (int)this.numericUpDown_Y.Value;
            if (Loaded)
            {
                ItemUpdated?.Invoke(this.PaintItem);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                ItemUpdated?.Invoke(this.PaintItem);
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.PaintItem.ItemValue = this.comboBox1.Text;
            if (Loaded)
            {
                ItemUpdated?.Invoke(this.PaintItem);
            }
        }
    }
}
