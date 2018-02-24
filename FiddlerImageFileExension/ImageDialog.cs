using System.Drawing;
using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    partial class ImageDialog : Form
    {
        public ImageDialog()
        {
            this.InitializeComponent();
        }

        public ImageDialog(Image image) : this()
        {
            this.PictureImage.Image = image;
        }
    }
}
