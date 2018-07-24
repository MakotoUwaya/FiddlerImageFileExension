using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    partial class ImageDialog : Form
    {
	    public IList<Image> Images { get; set; }

	    private int imageIndex = -1;

        private FormWindowState beforeWindowState = FormWindowState.Normal;

        public ImageDialog()
        {
            this.InitializeComponent();
        }

        public ImageDialog(IList<Image> images) : this()
        {
            this.Images = images;
        }

        public void SetImage(Image image)
        {
            this.imageIndex = this.Images.IndexOf(image);
            this.SetImageByIndex(this.imageIndex);
        }

        private void SetImageByIndex(int index)
        {
            this.PictureImage.Image = this.imageIndex == -1 ? null : this.Images[index];
        }

        private void ImageDialog_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                if (this.imageIndex + 1 < (this.Images?.Count ?? 0))
                {
                    this.SetImageByIndex(++this.imageIndex);
                }
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                if (0 <= this.imageIndex - 1 && 0 <= (this.Images?.Count ?? 0))
                {
                    this.SetImageByIndex(--this.imageIndex);
                }
            }
            if (e.Alt & e.KeyCode == Keys.Enter)
            {
                this.beforeWindowState = this.WindowState;
                if (this.WindowState == FormWindowState.Maximized)
                {                    
                    this.WindowState = FormWindowState.Normal;
                }

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (this.beforeWindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = this.beforeWindowState;
            }
        }
    }
}
