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

        public Settings()
        {
            this.InitializeComponent();
        }
    }
}
