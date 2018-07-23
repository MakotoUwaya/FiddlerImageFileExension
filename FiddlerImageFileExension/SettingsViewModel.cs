using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    public class SettingsViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ISettingParameters settingParameters;

        private ImageDialog imageDialog;
        private ImageDialog oImageDialog
        {
            get { return this.imageDialog; }
            set
            {
                if (this.imageDialog == value)
                {
                    return;
                }
                this.imageDialog = value;
                this.NotifyPropertyChanged();
            }
        }
        private Size oImageDialogScreenSize
        {
            get { return Properties.Settings.Default.ImageDialogSize; }
            set
            {
                if (this.oImageDialogScreenSize == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogSize = value;
                this.NotifyPropertyChanged();
            }
        }
        private Point oImageDialogScreenLocation
        {
            get { return Properties.Settings.Default.ImageDialogLocation; }
            set
            {
                if (this.oImageDialogScreenLocation == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogLocation = value;
                this.NotifyPropertyChanged();
            }
        }
        private FormWindowState oImageDialogWindowState
        {
            get { return (FormWindowState)Properties.Settings.Default.ImageDialogWindowState; }
            set
            {
                if (this.oImageDialogWindowState == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogWindowState = (int)value;
                this.NotifyPropertyChanged();
            }
        }

        public string SavePath
        {
            get { return this.settingParameters.SavePath; }
            set
            {
                if (this.SavePath == value)
                {
                    return;
                }
                this.settingParameters.SavePath = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool IsSaveAndRemove
        {
            get { return this.settingParameters.IsSaveAndRemove; }
            set
            {
                if (this.IsSaveAndRemove == value)
                {
                    return;
                }
                this.settingParameters.IsSaveAndRemove = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool capturing;
        public bool Capturing
        {
            get { return this.capturing; }
            set
            {
                if (this.capturing == value)
                {
                    return;
                }
                this.capturing = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(this.CaptureButtonText));
                this.NotifyPropertyChanged(nameof(this.CaptureButtonImageIndex));
            }
        }

        public string CaptureButtonText
        {
            get { return this.Capturing ? " Stop Capture" : " Start Capture"; }
        }

        public int CaptureButtonImageIndex
        {
            get { return this.Capturing ? 1 : 0; }
        }


        public string UserAgent
        {
            get { return this.settingParameters.UserAgent; }
            set
            {
                if (this.UserAgent == value)
                {
                    return;
                }
                this.settingParameters.UserAgent = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool UsingOriginalSettings
        {
            get { return this.settingParameters.UsingOriginalSettings; }
            set
            {
                if (this.UsingOriginalSettings == value)
                {
                    return;
                }
                this.settingParameters.UsingOriginalSettings = value;
                this.NotifyPropertyChanged();
            }
        }

        public long MinimumFileSize
        {
            get { return this.settingParameters.MinimumFileSize; }
            set
            {
                if (this.MinimumFileSize == value)
                {
                    return;
                }
                this.settingParameters.MinimumFileSize = value;
                this.NotifyPropertyChanged();
            }
        }

        public long MaximumFileSize
        {
            get { return this.settingParameters.MaximumFileSize; }
            set
            {
                if (this.MaximumFileSize == value)
                {
                    return;
                }
                this.settingParameters.MaximumFileSize = value;
                this.NotifyPropertyChanged();
            }
        }

        public string SelectedCountText
        {
            get { return $"{this.SelectedCount:#,0} / {this.SelectedTotalCount:#,0}"; }
        }

        private int selectedCount;
        public int SelectedCount
        {
            get { return this.selectedCount; }
            set
            {
                if (this.selectedCount == value)
                {
                    return;
                }
                this.selectedCount = value;
                this.NotifyPropertyChanged(nameof(this.SelectedCountText));
            }
        }

        private int selectedTotalCount;
        public int SelectedTotalCount
        {
            get { return this.selectedTotalCount; }
            set
            {
                if (this.selectedTotalCount == value)
                {
                    return;
                }
                this.selectedTotalCount = value;
                this.NotifyPropertyChanged(nameof(this.SelectedCountText));
            }
        }

        public int ImagePreviewSizeValue
        {
            get { return this.settingParameters.ImagePreviewSize; }
            set
            {
                if (this.ImagePreviewSizeValue == value)
                {
                    return;
                }
                this.settingParameters.ImagePreviewSize = value;
                this.NotifyPropertyChanged();
            }
        }

        public SettingsViewModel(ISettingParameters parameters)
        {
            this.settingParameters = parameters;
        }
        
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PictureBox_ShowingImageDialogWindow(object sender, EventArgs e)
        {
            var popupPictureBox = (PopupPictureBox)sender;
            var images = popupPictureBox.Parent.Controls.Cast<PopupPictureBox>().Select(p => p.Image).ToList();
            if (this.oImageDialog == null || this.oImageDialog.IsDisposed)
            {
                this.oImageDialog = new ImageDialog(images);
                this.oImageDialog.FormClosing += this.ImageDialog_FormClosing;
                this.oImageDialog.Show();
                this.oImageDialog.Location = this.oImageDialogScreenLocation;
                this.oImageDialog.Size = this.oImageDialogScreenSize;
                this.oImageDialog.WindowState = this.oImageDialogWindowState;
            }
            else
            {
                if (!ReferenceEquals(this.oImageDialog.Images, images))
                {
                    this.oImageDialog.Images = images;
                }

                this.oImageDialog.Show();
                if (this.oImageDialog.WindowState == FormWindowState.Minimized)
                {
                    this.oImageDialog.WindowState = FormWindowState.Normal;
                }
            }

            this.oImageDialog.SetImage(popupPictureBox.Image);
            this.oImageDialog.Activate();
        }

        private void ImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (Form)sender;
            this.oImageDialogScreenLocation = form.Bounds.Location;
            this.oImageDialogScreenSize = form.Bounds.Size;
            this.oImageDialogWindowState = form.WindowState == FormWindowState.Minimized
                ? FormWindowState.Maximized
                : form.WindowState;
        }

        private void PictureBox_SelectionAllChanged(object sender, SelectablePictureEventArgs e)
        {
            this.oView.SelectionAllChange(e.IsSelect);
        }

        private void PictureBox_SaveAll(object sender, EventArgs e)
        {
            this.oView.SaveSelectedImages();
        }

        private void PictureBox_Delete(object sender, EventArgs e)
        {
            this.oView.RemoveFileImage((PictureBox)sender);
        }

        private void PictureBox_DeleteAllSelected(object sender, EventArgs e)
        {
            this.oView.RemoveSelectedImages();
        }

        private void PictureBox_SelectionChanged(object sender, SelectablePictureEventArgs e)
        {
            this.oView.SelectedCountUpdate();
        }

        public void CloseImageDialog()
        {
            this.oImageDialog?.Close();
        }

        public void Dispose()
        {
            this.CloseImageDialog();
        }
    }
}
