using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiddlerImageFileExension
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string savePath;
        public string SavePath
        {
            get { return this.savePath; }
            set
            {
                if (this.savePath == value)
                {
                    return;
                }
                this.savePath = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool iSaveAndRemove;
        public bool IsSaveAndRemove
        {
            get { return this.iSaveAndRemove; }
            set
            {
                if (this.iSaveAndRemove == value)
                {
                    return;
                }
                this.iSaveAndRemove = value;
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


        private string userAgent;
        public string UserAgent
        {
            get { return this.userAgent; }
            set
            {
                if (this.userAgent == value)
                {
                    return;
                }
                this.userAgent = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool usingOriginalSettings;
        public bool UsingOriginalSettings
        {
            get { return this.usingOriginalSettings; }
            set
            {
                if (this.usingOriginalSettings == value)
                {
                    return;
                }
                this.usingOriginalSettings = value;
                this.NotifyPropertyChanged();
            }
        }

        private long minimumFileSize = 25;
        public long MinimumFileSize
        {
            get { return this.minimumFileSize; }
            set
            {
                if (this.minimumFileSize == value)
                {
                    return;
                }
                this.minimumFileSize = value;
                this.NotifyPropertyChanged();
            }
        }

        private long maximumFileSize = 999999;
        public long MaximumFileSize
        {
            get { return this.maximumFileSize; }
            set
            {
                if (this.maximumFileSize == value)
                {
                    return;
                }
                this.maximumFileSize = value;
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

        private int imagePreviewSizeValue = 150;
        public int ImagePreviewSizeValue
        {
            get { return this.imagePreviewSizeValue; }
            set
            {
                if (this.imagePreviewSizeValue == value)
                {
                    return;
                }
                this.imagePreviewSizeValue = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
