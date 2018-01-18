using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Fiddler;

[assembly: RequiredVersion("2.3.5.0")]
namespace FiddlerImageFileExension
{
    public sealed class ImageDownloader : IAutoTamper
    {
        private TabPage oPage;
        private Settings oView;

        public ImageDownloader()
        {
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (oSession == null)
            {
                return;
            }
            oSession.oRequest["User-Agent"] = this.oView?.DataContext?.UserAgent;
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            if (!this.oView.DataContext.IsCreateImage || 
                !Directory.Exists(this.oView.DataContext.SavePath))
            {
                return;
            }

            if (oSession?.responseCode != 200 || oSession.oResponse?.headers == null)
            {
                return;
            }

            if (!oSession.oResponse.headers.ExistsAndContains("Content-Type", "image/"))
            {
                return;
            }
            
            MemoryStream oStream = null;
            try
            {
                oSession.utilDecodeResponse();
                oStream = new MemoryStream(oSession.responseBodyBytes);
                Image.FromStream(oStream).Save($@"{this.oView.DataContext.SavePath}\{oSession.SuggestedFilename}");
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ExternalException)
            {
                Trace.WriteLine(ex.ToString(), "ImageExtention Failed");
            }
            finally
            {
                oStream?.Dispose();
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
            Properties.Settings.Default.IsCreateImage = this.oView?.DataContext?.IsCreateImage ?? false;
            Properties.Settings.Default.SavePath = this.oView?.DataContext?.SavePath;
            Properties.Settings.Default.UserAgent = this.oView?.DataContext?.UserAgent;
            Properties.Settings.Default.Save();
        }

        public void OnLoad()
        {
            this.oPage = new TabPage("ImageExtention")
            {
                ImageIndex = (int)SessionIcons.Downloading
            };

            this.oView = new Settings
            {
                DataContext = new SettingsViewModel
                {
                    IsCreateImage = GetIsCreateImage(),
                    SavePath = GetSaveDirectory(),
                    UserAgent = GetUserAgent(),
                }
            };

            this.oPage.Controls.Add(this.oView);
            this.oView.Dock = DockStyle.Fill;
            FiddlerApplication.UI.tabsViews.TabPages.Add(this.oPage);
        }

        private static bool GetIsCreateImage()
        {
            return Properties.Settings.Default.IsCreateImage;
        }

        private static string GetSaveDirectory()
        {
            var saveDirectory = Properties.Settings.Default.SavePath;
            if (string.IsNullOrWhiteSpace(saveDirectory) || !Directory.Exists(saveDirectory))
            {
                saveDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Downloads";
            }
            return saveDirectory;
        }

        private static string GetUserAgent()
        {
            return Properties.Settings.Default.UserAgent;
        }

    }
}
