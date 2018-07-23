using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;

[assembly: RequiredVersion("2.3.5.0")]
namespace FiddlerImageFileExension
{
    public sealed class ImageDownloader : IAutoTamper
    {
        private const int Thousand = 1000;

        public ImageDownloader()
        {
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (oSession == null || (this.oView?.DataContext.UsingOriginalSettings ?? true))
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
            if (!this.oView.DataContext.Capturing || !Directory.Exists(this.oView.DataContext.SavePath))
            {
                return;
            }

            if (oSession?.responseCode != 200 || oSession.oResponse?.headers == null)
            {
                return;
            }

            if (!oSession.oResponse.headers.ExistsAndContains("Content-Type", "image/") ||
                oSession.oResponse.headers.ExistsAndContains("Content-Type", "image/svg"))
            {
                return;
            }

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

                var oStream = new MemoryStream(oSession.responseBodyBytes);
                var image = Image.FromStream(oStream);
                
                this.oView.Invoke(new Action(() => 
                {
                    var pictureBox = new PopupPictureBox
                    {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(this.oView.DataContext.ImagePreviewSizeValue, this.oView.DataContext.ImagePreviewSizeValue),
                        SaveAction = () =>
                        {
                            // ファイル拡張子から余分な記述を削除
                            var actualFileName = Regex.Replace(fileName, @"^(.+)\.(.+?)(?:|-.+)$", "$1.$2");

                            var loopCount = 0;
                            while (File.Exists($@"{this.oView.DataContext.SavePath}\{actualFileName}"))
                            {
                                actualFileName = Regex.Replace(actualFileName, @"^(.+)(?:|\(\d{0,2}\))\.(.+)$", $"$1({++loopCount}).$2");
                            }
                            image.Save($@"{this.oView.DataContext.SavePath}\{actualFileName}");
                        },
                    };

                    pictureBox.SelectionChanged += this.PictureBox_SelectionChanged;
                    pictureBox.SelectionAllChanged += this.PictureBox_SelectionAllChanged;
                    pictureBox.SaveAll += this.PictureBox_SaveAll;
                    pictureBox.Delete += this.PictureBox_Delete;
                    pictureBox.DeleteAllSelected += this.PictureBox_DeleteAllSelected;
                    pictureBox.ShowingImageDialogWindow += this.PictureBox_ShowingImageDialogWindow;

                    this.oView.ImageFiles.Add(pictureBox);
                }));
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ExternalException)
            {
                FiddlerApplication.Log.LogString($"ImageExtention Failed {ex.ToString()}");
            }
        }

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
        }

        public void OnLoad()
        {
            this.oView = new Settings
            {
                DataContext = new SettingsViewModel(new SettingParameters()),
                Dock = DockStyle.Fill
            };

            var tabPage = new TabPage("ImageExtention")
            {
                ImageIndex = (int)SessionIcons.Downloading
            };
            tabPage.Controls.Add(this.oView);
            FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
        }


    }
}
