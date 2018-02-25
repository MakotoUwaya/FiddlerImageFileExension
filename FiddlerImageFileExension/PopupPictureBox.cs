using System;
using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    public partial class PopupPictureBox : SelectablePictureBox
    {
        public PopupPictureBox()
        {
            this.InitializeComponent();
        }

        public event EventHandler ShowingImageDialogWindow;

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.ShowImageDialogWindow();
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ShowImageDialogWindow();
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            this.ShowImageDialogWindow();
            base.OnMouseDoubleClick(e);
        }

        private void ShowImageDialogWindow()
        {
            this.ShowingImageDialogWindow?.Invoke(this, new EventArgs());
        }

    }
}
