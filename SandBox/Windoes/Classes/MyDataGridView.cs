using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForms.Classes
{
    public class MyDataGridView : DataGridView
    {
        private readonly Timer Timer;
        private object _dataSource;

        public MyDataGridView()
        {
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false;
            this.AutoSize = false;
            this.ScrollBars = ScrollBars.Both;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeRows = false;
            this.AutoGenerateColumns = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowCellErrors = false;
            this.ShowRowErrors = false;

            this.ColumnRemoved += this_UIUpdated;
            this.ColumnWidthChanged += this_UIUpdated;
            this.Scroll += (s, e) =>
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    this.this_UIUpdated(s, e);
                }
            };

            Timer = new Timer { Interval = 1000 };
            Timer.Tick += Timer_Tick;
        }

        public sealed override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        private void this_UIUpdated(object sender, EventArgs e)
        {
            LoadHeaderTextBoxes();
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                _dataSource = value;
                DisplayData();
                this.LoadHeaderTextBoxes();
            }
        }

        private void DisplayData()
        {
            var filteredDataSource = _dataSource;
            var list = _dataSource as IEnumerable<object>;
            if (list != null && list.Any())
            {
                var dataType = list?.FirstOrDefault()?.GetType();

                var textBoxes = this.Controls.Cast<Control>().Where(t => t is TextBox && string.IsNullOrEmpty(t.Text) == false);
                foreach (var textBox in textBoxes)
                {
                    var column = this.Columns.Cast<DataGridViewTextBoxColumn>().FirstOrDefault(c => c.Tag == textBox);
                    if (column == null) continue;
                    filteredDataSource = FilterData(filteredDataSource, textBox.Text, column.DataPropertyName, dataType);
                }
            }

            list = filteredDataSource as IEnumerable<object>;
            base.DataSource = list?.ToList();
        }

        private object FilterData(object dataSource, string searchKeyword, string propertyName, Type datasourceType)
        {
            var propertyInfo = datasourceType.GetProperties()
                .FirstOrDefault(p => p.Name.ToUpper() == propertyName.ToUpper());
            if (propertyInfo == null)
            {
                return new object();
            }

            var isDateTime = propertyInfo.PropertyType == typeof(DateTime) ||
                             propertyInfo.PropertyType == typeof(DateTime?);

            var list = dataSource as IEnumerable<object>;
            try
            {
                IEnumerable<object> filter;
                if (isDateTime)
                    filter = list.Where(i => string.Format("{0:dd-MMM-yyyy}", propertyInfo.GetValue(i)?.ToString()).ToLower()
                                                 .Contains(searchKeyword.ToLower()) == true);
                else
                    filter = list.Where(i => propertyInfo.GetValue(i)?.ToString().ToLower()
                            .Contains(searchKeyword.ToLower()) == true);
                return filter;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        private void LoadHeaderTextBoxes()
        {
            var textBoxes = new List<Control>();

            var columns = this.Columns.Cast<DataGridViewTextBoxColumn>().ToList();
            foreach (var column in columns)
            {
                var textBox = column.Tag as TextBox;
                if (textBox == null)
                {
                    textBox = new TextBox();
                    column.Tag = textBox;
                    textBox.TextChanged += FooterTextBox_TextChanged;
                }
                var index = column.DisplayIndex;
                var rectangle = this.GetColumnDisplayRectangle(index, true);
                
                textBox.Location = new Point(rectangle.X, textBox.Height);
                textBox.Width = column.Width;
                textBoxes.Add(textBox);

                if (column.HeaderText != string.Empty && column.HeaderText.Contains(Environment.NewLine) == false)
                {
                    column.HeaderText = column.HeaderText + Environment.NewLine;
                }
            }

            var abandonedcontrols = this.Controls.Cast<Control>().Where(c => textBoxes.Contains(c) == false);
            foreach (var c in abandonedcontrols)
            {
                this.Controls.Remove(c);
            }

            var controlsToAdd = textBoxes.Where(c => this.Controls.Contains(c) == false).ToArray();
            this.Controls.AddRange(controlsToAdd);
            this.Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();
            DisplayData();
        }

        private void FooterTextBox_TextChanged(object sender, EventArgs e)
        {
            Timer.Stop();
            Timer.Start();
        }
    }
}