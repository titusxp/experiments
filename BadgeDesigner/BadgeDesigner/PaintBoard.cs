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

        private bool IncludeImage => checkBox_ShowPhoto.Checked;

        private void PaintBoard_Load(object sender, EventArgs e)
        {
            this.OriginalImage = this.pictureBox_Badge.Image;
            var paintItems = GetPaintItems();

            LoadPaintItemsToUI(paintItems);

            this.numericUpDown_X.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Y.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Width.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown_Height.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        }

        private void LoadPaintItemsToUI(List<PaintItem> paintItems)
        {
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
                uc.DeleteButtonClicked += (s) => { this.RemoveItem(s?.ItemCaption); };
                flowLayoutPanel1.Controls.Add(uc);
            }

            this.UpdateImage();
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
                        var imageWidthInPixels = this.pictureBox_Badge.Image.Width;
                        var x = 2 + (imageWidthInPixels - textSize.Width) / 2;
                        location.X = (int)x;
                        graphics.DrawString(item.ItemValue, item.FontStyle, new SolidBrush(item.FontColor),
                            location);
                    }

                    if (this.IncludeImage && this.DPPaintItem.ProfilePicture != null)
                    {
                        graphics.DrawImage(this.DPPaintItem.ProfilePicture, this.DPPaintItem.X, this.DPPaintItem.Y, this.DPPaintItem.Width, this.DPPaintItem.Height);
                    }
                }
                this.pictureBox_Badge.Image = bitmap;
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
                this.numericUpDown_BadgeHeight.Value = database.BadgeHeight > 1 ? database.BadgeHeight : this.pictureBox_Badge.Height;
                this.numericUpDown_BadgeWidth.Value = database.BadgeWidth > 1 ? database.BadgeWidth : this.pictureBox_Badge.Width;
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
            this.pictureBox_Badge.Image = OriginalImage;
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
                ProfilePictureItem = dpItem,
                BadgeWidth = (int)this.numericUpDown_BadgeWidth.Value,
                BadgeHeight = (int)this.numericUpDown_BadgeHeight.Value,
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
            if(flowLayoutPanel_PrintList.Controls.Count < 1)
            {
                MessageBox.Show("There is no image in the print list");
                return;
            }

            var document = new PrintDocument();
            var printDialog = new PrintDialog();

            document.PrintPage += document_PrintPage;

            printDialog.Document = document;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        private int BadgeWidth => (int)this.numericUpDown_BadgeWidth.Value;
        private int BadgeHeight => (int)this.numericUpDown_BadgeHeight.Value;

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            var images = flowLayoutPanel_PrintList.Controls.Cast<Button>()
                .Select(l => l.BackgroundImage)
                .Take(4);
            var i = 0;
            foreach(var img in images)
            {
                var width = this.BadgeWidth;
                var height = this.BadgeHeight;
                var tolerance = 20;
                i++;
                var x = 0;
                var y = 0;
                switch (i)
                {
                    case 1:
                        x = 0;
                        y = 0;
                        break;
                    case 2:
                        x = width + tolerance;
                        y = 0;
                        break;
                    case 3:
                        x = 0;
                        y = height + tolerance;
                        break;
                    case 4:
                        x = width + tolerance;
                        y = height + tolerance;
                        break;
                }
                var newImage = new Bitmap(img, width, height);
                e.Graphics.DrawImage(newImage, x, y);
                newImage.Dispose();
            }
        }

        private void button_AddToPrintList_Click(object sender, EventArgs e)
        {
            if(this.flowLayoutPanel_PrintList.Controls.Count == 4)
            {
                MessageBox.Show("There are already 4 images in the list. To add a new one you have to remove an existing item from the list");
                return;
            }
            var currentImage = pictureBox_Badge.Image;
            var label = new Button
            {
                AutoSize = false,
                Width = 100,
                Height = 160,
                BackgroundImage = currentImage,
                BackgroundImageLayout = ImageLayout.Stretch,
            };
            label.Click += (s, ev) =>
            {
                var clidkedLabel = s as Button;
                if (clidkedLabel == null) return;
                if(MessageBox.Show("Do you want to remove this image from the print paper?") == DialogResult.Yes)
                {
                    flowLayoutPanel_PrintList.Controls.Remove(clidkedLabel);
                }
            };
            flowLayoutPanel_PrintList.Controls.Add(label);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel_PrintList.Controls.Clear();
        }

        private void button_NewItem_Click(object sender, EventArgs e)
        {
            using (var newItemForm = new frmAddItem())
            {
                newItemForm.OKButtonClicked += (s) =>
                {
                    var items = GetUpdatedPaintItems();
                    items.Add(new PaintItem()
                    {
                        ItemCaption = s
                    });
                    this.LoadPaintItemsToUI(items);
                };
                newItemForm.ShowDialog(this);
            }
        }

        private void RemoveItem(string itemCaption)
        {
            var items = GetUpdatedPaintItems();
            var selectItem = items.FirstOrDefault(i => i.ItemCaption == itemCaption);
            items.Remove(selectItem);
            this.LoadPaintItemsToUI(items);
        }

        private void checkBox_ShowPhoto_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateImage();
        }
    }
}
