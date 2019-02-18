using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForms.Classes
{
    public class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowHeadersVisible = false;
            this.ColumnRemoved += this_UIUpdated;
            this.ColumnWidthChanged += this_UIUpdated;
        }

        private void this_UIUpdated(object sender, DataGridViewColumnEventArgs e)
        {
            LoadHeaderTextBoxes();
        }

        private DataGridViewRow HeaderRow = new DataGridViewRow();

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                var obj = value;
                //var list = value as IEnumerable<object>;
                //if (list != null)
                //{
                //    var items = list.ToList();
                //    var type = list.FirstOrDefault().GetType();
                //    var instance = Activator.CreateInstance(type);
                //    items.Insert(0, instance);
                //    obj = items;
                //}

                base.DataSource = obj;
                this.LoadHeaderTextBoxes();
            }
        }

        private void LoadHeaderTextBoxes()
        {
            this.Controls.Clear();
            var textBoxes = new List<Control>();
            HeaderRow = new DataGridViewRow();

            var columns = this.Columns.Cast<DataGridViewTextBoxColumn>().ToList();
            foreach (var column in columns)
            {
                //var column = c as MyGridViewColumn;
                //if (column == null)
                //{
                //    continue;
                //}


                var textBox = column.Tag as TextBox;
                {
                    if (textBox == null)
                    {
                        textBox = new TextBox();
                        column.Tag = textBox;
                    }
                }

                if (textBox == null) return;
                var index = column.DisplayIndex;
                var rectangle = this.GetColumnDisplayRectangle(index, true);
                
                textBox.Location = new Point(rectangle.X, textBox.Height);
                textBox.Width = column.Width;
                textBoxes.Add(textBox);

                if (column != null && column.HeaderText != string.Empty && column.HeaderText.Contains(Environment.NewLine) == false)
                {
                    column.HeaderText = column.HeaderText + Environment.NewLine;
                }
            }

            
            var array = textBoxes.ToArray();
            this.Controls.AddRange(array);
        }
    }
}