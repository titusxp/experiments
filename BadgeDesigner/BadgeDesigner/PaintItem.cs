using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;

namespace BadgeDesigner
{
    public enum PaintedItemTypes
    {
        Organization,
        ParticipantName,
        Country,
        ProfilePicture
    }
    public class PaintItem
    {
        public PaintItem()
        {
            this.FontStyle = new Font("Calibri", 9);
            this.FontSize = 9;
            FontColor = Color.Black;
        }

        public PaintedItemTypes PaintedItemType { get; set; }
        public string ItemCaption { get; set; }
        public string ItemValue { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Font FontStyle { get; set; }
        public int FontSize { get; set; }
        public Color FontColor { get; set; } = Color.Black;
        public string FontName => this.FontStyle?.Name;

        public string[] ItemsList { get; set; }
        public Point Location => new Point(this.X,  this.Y);
    }

    public class ProfilePicturePaintItem : PaintItem
    {
        private Image _profilePicture;

        public ProfilePicturePaintItem()
        {
            this.PaintedItemType = PaintedItemTypes.ProfilePicture;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public Image ProfilePicture
        {
            get { return _profilePicture; }
            set
            {
                _profilePicture = value;
            }
        }
        public byte[] ProfilePictureBytes { get; set; }

        internal void ArchiveImage()
        {
            if (this.ProfilePicture != null)
            {
                var imageConverter = new ImageConverter();
                var bytes = (byte[]) imageConverter.ConvertTo(this.ProfilePicture, typeof(byte[]));
                this.ProfilePictureBytes = bytes;
                this.ProfilePicture = null;
            }
        }
        internal void UnArchiveImage()
        {
            if (this.ProfilePictureBytes != null)
            {
                var imageConverter = new ImageConverter();
                var image = (Image) imageConverter.ConvertFrom(this.ProfilePictureBytes);
                this.ProfilePicture = image;
                this.ProfilePictureBytes = null;

                //using (var ms = new MemoryStream(this.ProfilePictureBytes))
                //{
                //    this.ProfilePicture = Image.FromStream(ms);
                //    this.ProfilePictureBytes = null;
                //}
            }
        }
    }

    public class Database
    {
        private ProfilePicturePaintItem _profilePictureItem;
        public List<PaintItem> PaintItems { get; set; }

        public int BadgeWidth { get; set; }
        public int BadgeHeight { get; set; }
        public ProfilePicturePaintItem ProfilePictureItem
        {
            get { return _profilePictureItem; }
            set { _profilePictureItem = value; }
        }
    }
}