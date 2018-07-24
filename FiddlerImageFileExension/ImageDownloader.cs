using System.Windows.Forms;
using Fiddler;

[assembly: RequiredVersion("2.3.5.0")]
namespace FiddlerImageFileExension
{
    public sealed class ImageDownloader : IAutoTamper
    {
	    private SettingsViewModel settingsViewModel;

		public void AutoTamperRequestAfter(Session oSession)
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (oSession == null || (this.settingsViewModel?.UsingOriginalSettings ?? true))
            {
                return;
            }
            oSession.oRequest["User-Agent"] = this.settingsViewModel?.UserAgent;
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
			this.settingsViewModel.AutoTamperResponseBefore(oSession);
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
            this.settingsViewModel.Dispose();
        }

        public void OnLoad()
        {
			var view = new Settings
            {
                Dock = DockStyle.Fill,
            };

            this.settingsViewModel = new SettingsViewModel(new SettingParameters(), view);
            view.DataContext = this.settingsViewModel;

            var tabPage = new TabPage("ImageExtention")
            {
                ImageIndex = (int)SessionIcons.Downloading
            };
            tabPage.Controls.Add(view);
            FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
        }

    }
}
