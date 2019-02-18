using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForms.Classes
{
    //public class MyGridViewColumn : DataGridViewTextBoxColumn
    //{
    //    public TextBox SearchHeader { get; set; }
    //    public MyGridViewColumn()
    //    {
    //        this.SearchHeader = new TextBox() {Tag = this};
    //    }
    //}

    public class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            this.RowHeadersVisible = false;
            this.ColumnRemoved += this_ColumnRemoved;
        }

        private void this_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            LoadHeaderTextBoxes();
        }

        private DataGridViewRow HeaderRow = new DataGridViewRow();

        public void LoadHeaderTextBoxes()
        {
            this.Controls.Clear();
            var textBoxes = new List<Control>();
            HeaderRow = new DataGridViewRow();
            var cells = new List<DataGridViewCell>();
            foreach (var col in this.Columns.Cast<DataGridViewTextBoxColumn>())
            {
                if (col == null)
                {
                    continue;
                }

                var cell = new DataGridViewCell()
                var textBox = new TextBox();
                if (textBox == null) return;
                var index = col.DisplayIndex;
                var rectangle = this.GetColumnDisplayRectangle(index, true);
                textBox.Location = new Point(rectangle.X, rectangle.Height - textBox.Height);
                textBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                //textBox.Width = e.Column.Width;
                textBoxes.Add(textBox);
            }
            
            var array = textBoxes.ToArray();
            this.Controls.AddRange(array);
        }
    }
}