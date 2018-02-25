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
                this.userAgent = value;
                this.NotifyPropertyChanged();
            }
        }

        private long minimumFileSize = 25;
        public long MinimumFileSize
        {
            get { return this.minimumFileSize; }
            set
            {
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
                this.imagePreviewSizeValue = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
