using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BadgeDesigner
{
    public partial class PaintBoard : Form
    {
        public PaintBoard()
        {
            InitializeComponent();
        }

        private void PaintBoard_Load(object sender, EventArgs e)
        {
            this.OriginalImage = this.pictureBox1.Image;
            var paintItems = GetPaintItems();
            //var dpItem = paintItems.FirstOrDefault(i => i.PaintedItemType == PaintedItemTypes.ProfilePicture) as ProfilePicturePaintItem;
            //if (dpItem == null)
            //{
            //    dpItem = new ProfilePicturePaintItem();
            //    paintItems.Add(dpItem);
            //}

            //this.DPPaintItem = dpItem;
            this.flowLayoutPanel1.Controls.Clear();
            foreach (var paintItem in paintItems.Where(i => i.PaintedItemType != PaintedItemTypes.ProfilePicture))
            {
                var uc = new UcPaintItem()
                {
                    PaintItem = paintItem,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 10, 0, 0)
                };
                uc.ItemUpdated += (s) => { this.UpdateImage(); };
                flowLayoutPanel1.Controls.Add(uc);
            }

            this.UpdateImage();



            this.numericUpDown_X.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Y.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Width.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Height.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        }

        public Image OriginalImage { get; set; }


        private void UpdateImage()
        {
            try
            {
                var bitmap = (Bitmap) this.OriginalImage.Clone();
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var paintItems = GetUpdatedPaintItems();
                    foreach (var item in paintItems.Where(i => i.ItemValue != null))
                    {
                        var location = item.Location;
                        //var characterSize = item.FontStyle.SizeInPoints / 72 * graphics.DpiX;
                        //var stringLength = item.ItemValue.Length;
                        //var totalSize = characterSize * stringLength / 2;
                        var textSize = GetTextSize(item.ItemValue, item.FontStyle);
                        var imageWidthInPixels = this.pictureBox1.Image.Width;
                        var x = 2 + (imageWidthInPixels - textSize.Width) / 2;
                        location.X = (int)x;
                        graphics.DrawString(item.ItemValue, item.FontStyle, new SolidBrush(item.FontColor),
                            location);
                    }

                    if (this.DPPaintItem.ProfilePicture != null)
                    {
                        graphics.DrawImage(this.DPPaintItem.ProfilePicture, this.DPPaintItem.X, this.DPPaintItem.Y, this.DPPaintItem.Width, this.DPPaintItem.Height);
                    }
                }
                this.pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private SizeF GetTextSize(string itemValue, Font fontStyle)
        {
            using (var graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                var stringSize = graphics.MeasureString(itemValue, fontStyle);
                return stringSize;
            }
        }

        private List<PaintItem> GetUpdatedPaintItems()
        {
            var ucs = this.flowLayoutPanel1.Controls.Cast<UcPaintItem>();
            var list = ucs?.Select(uc => uc.PaintItem).ToList();
            return list;
        }

        private List<PaintItem> GetPaintItems()
        {
            try
            {
                var serialized = File.ReadAllText(this.databasePath);
                var database = JsonConvert.DeserializeObject<Database>(serialized);
                var dpItem = database?.ProfilePictureItem;
                dpItem?.UnArchiveImage();
                this.DPPaintItem = dpItem;
                return database?.PaintItems ?? Functions.PaintItems;
            }
            catch (Exception ex)
            {
                return Functions.PaintItems;
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            this.UpdateImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = OriginalImage;
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            var paintItems = GetUpdatedPaintItems();
            SavePaintItems(paintItems);
        }

        private void SavePaintItems(List<PaintItem> paintItems)
        {
            var dpItem = this.DPPaintItem;
            dpItem.ArchiveImage();
            var database = new Database()
            {
                PaintItems = paintItems,
                ProfilePictureItem = dpItem
            };
            var serialized = JsonConvert.SerializeObject(database);
            File.WriteAllText(this.databasePath, serialized);
        }

        private string databasePath = "database.bd";

        private ProfilePicturePaintItem DPPaintItem
        {
            get { return this.profilePicturePaintItemBindingSource.DataSource as ProfilePicturePaintItem;}
            set { this.profilePicturePaintItemBindingSource.DataSource = value; }
        }
        private void button_Browse_Click(object sender, EventArgs e)
        {
            using (var imageEditor = new ImageEditor())
            {
                imageEditor.ApplyButtonClicked += (c) =>
                {
                    this.NewImageLoaded(c);
                    imageEditor.Close();
                };
                imageEditor.ShowDialog();
            }
        }

        private void NewImageLoaded(Image loadedImage)
        {
            this.pictureBox_DP.Image = loadedImage;
            this.DPPaintItem.ProfilePicture = loadedImage;
            this.UpdateImage();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.DPPaintItem.X = int.Parse(numericUpDown_X.Value.ToString(CultureInfo.InvariantCulture));
            this.DPPaintItem.Y = int.Parse(numericUpDown_Y.Value.ToString(CultureInfo.InvariantCulture));
            this.DPPaintItem.Width = int.Parse(numericUpDown_Width.Value.ToString(CultureInfo.InvariantCulture));
            this.DPPaintItem.Height = int.Parse(numericUpDown_Height.Value.ToString(CultureInfo.InvariantCulture));

            this.UpdateImage();
        }

        private void button_PrintBadge_Click(object sender, EventArgs e)
        {
            var document = new PrintDocument();
            var printDialog = new PrintDialog();

            document.PrintPage += document_PrintPage;

            printDialog.Document = document;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            pictureBox1.DrawToBitmap(image, new Rectangle(0,0,pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(image, 0,0);
            image.Dispose();
        }
    }
}
