using System;
using System.Drawing;
using System.Windows.Forms;

namespace BadgeDesigner
{
    public partial class ImageEditor : Form
    {
        public Action<Image> ApplyButtonClicked { get; set; }

        public ImageEditor()
        {
            InitializeComponent();
            this.imageResizer1.CancelButtonClicked = (c) => this.Close();
            this.imageResizer1.ApplyButtonClicked = (c) => this.ApplyButtonClicked?.Invoke(c);
        }
    }
}
