using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    public partial class Settings : UserControl
    {
        public SettingsViewModel DataContext
        {
            get => this.settingsViewModelBindingSource.DataSource as SettingsViewModel;
	        set => this.settingsViewModelBindingSource.DataSource = value;
        }

        public ControlCollection ImageFiles => this.FileImageListPanel.Controls;

	    private List<SelectablePictureBox> PicutureBoxList => this.FileImageListPanel.Controls.Cast<SelectablePictureBox>().ToList();

	    public Settings()
        {
            this.InitializeComponent();
        }

        public void SelectedCountUpdate()
        {
            this.DataContext.SelectedCount = this.PicutureBoxList.Count(p => p.Selected);
            this.DataContext.SelectedTotalCount = this.FileImageListPanel.Controls.Count;
        }

        private void ClearImagesButton_Click(object sender, EventArgs e)
        {
            this.RemoveSelectedImages();
        }

        public void RemoveSelectedImages()
        {
            this.PicutureBoxList.ForEach(x =>
            {
                if (x.Selected)
                {
                    this.RemoveFileImage(x);
                }
            });
        }

        private void SaveSelectedImagesButton_Click(object sender, EventArgs e)
        {
            this.SaveSelectedImages();
        }

        public void SaveSelectedImages()
        {
            this.PicutureBoxList.ForEach(x =>
            {
                if (x.Selected)
                {
                    x.SaveAction();
                }
            });

            if (!this.IsSaveAndRemoveCheckBox.Checked)
            {
                return;
            }
            this.RemoveSelectedImages();
        }

        public void SelectionAllChange(bool selected)
        {
            this.PicutureBoxList.ForEach(p => p.Selected = selected);
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            this.SelectionAllChange(true);
        }

        private void UnSelectAllButton_Click(object sender, EventArgs e)
        {
            this.SelectionAllChange(false);
        }

        private void FileImageListPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            this.SelectedCountUpdate();
        }

        private void PreviewImageSizeSlider_ValueChanged(object sender, EventArgs e)
        {
            var size = new Size(this.PreviewImageSizeSlider.Value, this.PreviewImageSizeSlider.Value);
            this.PicutureBoxList.ForEach(p => p.Size = size);
        }

        public void RemoveFileImage(PictureBox pictureBox)
        {
            var removeItemIndex = this.FileImageListPanel.Controls.IndexOf(pictureBox);
            this.FileImageListPanel.Controls.Remove(pictureBox);
            pictureBox.Image?.Dispose();
            pictureBox.Dispose();

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

        private void ChangeCaptureStatusButton_Click(object sender, EventArgs e)
        {
            this.DataContext.Capturing = !this.DataContext.Capturing;
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Please select destination directory.",
                SelectedPath = this.DataContext.SavePath,
            };
            
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK &&
                Directory.Exists(folderBrowserDialog.SelectedPath))
            {
                this.DataContext.SavePath = folderBrowserDialog.SelectedPath;
            }            
        }
    }
}
