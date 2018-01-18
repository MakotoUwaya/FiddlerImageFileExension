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

        private bool isCreateImage;
        public bool IsCreateImage
        {
            get { return this.isCreateImage; }
            set
            {
                this.isCreateImage = value;
                this.NotifyPropertyChanged(nameof(this.IsCreateImage));
            }
        }

        private string savePath;
        public string SavePath
        {
            get { return this.savePath; }
            set
            {
                this.savePath = value;
                this.NotifyPropertyChanged(nameof(this.SavePath));
            }
        }

        private string userAgent;
        public string UserAgent
        {
            get { return this.userAgent; }
            set
            {
                this.userAgent = value;
                this.NotifyPropertyChanged(nameof(this.UserAgent));
            }
        }

    }
}
