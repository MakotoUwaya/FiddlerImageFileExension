using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Fiddler;
using System.Text.RegularExpressions;

[assembly: RequiredVersion("2.3.5.0")]
namespace FiddlerImageFileExension
{
    public sealed class ImageDownloader : IAutoTamper
    {
        private const int Thousand = 1000;

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
            if (!Directory.Exists(this.oView.DataContext.SavePath))
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

                var fileName = oSession.SuggestedFilename;
                if (this.oView.DataContext.MinimumFileSize != this.oView.DataContext.MaximumFileSize)
                {
                    if (oSession.responseBodyBytes.Length < this.oView.DataContext.MinimumFileSize * Thousand ||
                        this.oView.DataContext.MaximumFileSize * Thousand < oSession.responseBodyBytes.Length)
                    {
                        return;
                    }
                }                                

                oStream = new MemoryStream(oSession.responseBodyBytes);
                var image = Image.FromStream(oStream);
                this.oView.Invoke(new Action(() => 
                {
                    var pictureBox = new PopupPictureBox
                    {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(this.oView.DataContext.ImageSizeValue, this.oView.DataContext.ImageSizeValue),
                        SaveAction = () =>
                        {
                            var loopCount = 0;
                            while (File.Exists($@"{this.oView.DataContext.SavePath}\{fileName}"))
                            {
                                fileName = Regex.Replace(fileName, @"^(.+)(?:|\(\d{0,2}\))\.(.+)$", $"$1({++loopCount}).$2");
                            }
                            image.Save($@"{this.oView.DataContext.SavePath}\{fileName}");
                        },
                    };

                    pictureBox.SelectedChanged += this.PictureBox_SelectedChanged;
                    pictureBox.Deleted += this.PictureBox_Deleted;

                    this.oView.ImageFiles.Add(pictureBox);
                }));
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ExternalException)
            {
                FiddlerApplication.Log.LogString($"ImageExtention Failed {ex.ToString()}");
            }
        }

        private void PictureBox_Deleted(object sender, EventArgs e)
        {
            this.oView.RemoveFileImage((Control)sender);
        }

        private void PictureBox_SelectedChanged(object sender, EventArgs e)
        {
            this.oView.SelectedCountUpdate();
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
            Properties.Settings.Default.MinimumFileSize = this.oView?.DataContext?.MinimumFileSize ?? 25;
            Properties.Settings.Default.MaximumFileSize = this.oView?.DataContext?.MaximumFileSize ?? 999999;
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
                    MinimumFileSize = GetMinimumFileSize(),
                    MaximumFileSize = GetMaximumFileSize(),
                    SavePath = GetSaveDirectory(),
                    UserAgent = GetUserAgent(),
                },
                Dock = DockStyle.Fill
            };

            this.oPage.Controls.Add(this.oView);
            FiddlerApplication.UI.tabsViews.TabPages.Add(this.oPage);
        }

        private static long GetMinimumFileSize()
        {
            return Properties.Settings.Default.MinimumFileSize;
        }

        private static long GetMaximumFileSize()
        {
            return Properties.Settings.Default.MaximumFileSize;
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
