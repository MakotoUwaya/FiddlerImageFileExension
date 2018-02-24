using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    public partial class Settings : UserControl
    {
        public SettingsViewModel DataContext
        {
            get { return this.settingsViewModelBindingSource.DataSource as SettingsViewModel; }
            set { this.settingsViewModelBindingSource.DataSource = value; }
        }

        public ControlCollection ImageFiles
        {
            get { return this.FileImageListPanel.Controls; }
        }

        private List<SelectablePictureBox> PicutureBoxList
        {
            get
            {
                return this.FileImageListPanel.Controls.Cast<SelectablePictureBox>().ToList();
            }
        }

        public Settings()
        {
            this.InitializeComponent();
        }

        public void SelectedCountUpdate()
        {
            this.DataContext.SelectedCount = this.PicutureBoxList.Count(p => p.Selected);
            this.DataContext.SelectedTotalCount = this.FileImageListPanel.Controls.Count;
        }

        private void ClearImagesButton_Click(object sender, System.EventArgs e)
        {
            if (this.DataContext.SelectedCount == this.DataContext.SelectedTotalCount)
            {
                this.FileImageListPanel.Controls.Clear();
                this.SelectedCountUpdate();
                return;
            }

            this.PicutureBoxList.ForEach(x =>
            {
                if (x.Selected)
                {
                    this.RemoveFileImage(x);
                }
            });            
        }

        private void SaveSelectedImagesButton_Click(object sender, System.EventArgs e)
        {
            this.PicutureBoxList.ForEach(x => 
            {
                if (x.Selected)
                {
                    x.SaveAction();

                    if (this.IsSaveWithImageClear.Checked)
                    {
                        this.RemoveFileImage(x);
                    }
                }
            });
        }

        private void SelectAllButton_Click(object sender, System.EventArgs e)
        {
            this.PicutureBoxList.ForEach(p => p.Selected = true);
        }

        private void UnSelectAllButton_Click(object sender, System.EventArgs e)
        {
            this.PicutureBoxList.ForEach(p => p.Selected = false);
        }

        private void FileImageListPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            this.SelectedCountUpdate();
        }

        private void PreviewImageSizeSlider_ValueChanged(object sender, System.EventArgs e)
        {
            var size = new Size(this.PreviewImageSizeSlider.Value, this.PreviewImageSizeSlider.Value);
            this.PicutureBoxList.ForEach(p => p.Size = size);
        }

        public void RemoveFileImage(Control pictureBox)
        {
            var removeItemIndex = this.FileImageListPanel.Controls.IndexOf(pictureBox);
            this.FileImageListPanel.Controls.Remove(pictureBox);
            this.SelectedCountUpdate();

            var focusIndex = removeItemIndex < this.FileImageListPanel.Controls.Count
                ? removeItemIndex
                : this.FileImageListPanel.Controls.Count - 1;

            this.SelectedCountUpdate();
            if (focusIndex < 0)
            {
                return;
            }
            this.FileImageListPanel.Controls[focusIndex].Focus();
            
        }
    }
}
