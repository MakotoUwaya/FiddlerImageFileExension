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

        private int imageSizeValue = 150;
        public int ImageSizeValue
        {
            get { return this.imageSizeValue; }
            set
            {
                this.imageSizeValue = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
