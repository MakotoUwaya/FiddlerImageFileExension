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

        private TabPage oPage;
        private Settings oView;
        private ImageDialog oImageDialog;
        private Size oImageDialogScreenSize;
        private Point oImageDialogScreenLocation;
        private FormWindowState oImageDialogWindowState;

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

        public void OnBeforeReturningError(Session oSession)
        {
        }

        public void OnBeforeUnload()
        {
            this.oImageDialog?.Close();

            Properties.Settings.Default.MinimumFileSize = this.oView?.DataContext?.MinimumFileSize ?? 25;
            Properties.Settings.Default.MaximumFileSize = this.oView?.DataContext?.MaximumFileSize ?? 999999;
            Properties.Settings.Default.ImagePreviewSize = this.oView?.DataContext?.ImagePreviewSizeValue ?? 150;
            Properties.Settings.Default.IsSaveAndRemove = this.oView?.DataContext?.IsSaveAndRemove ?? true;
            Properties.Settings.Default.SavePath = this.oView?.DataContext?.SavePath;
            Properties.Settings.Default.UserAgent = this.oView?.DataContext?.UserAgent;
            Properties.Settings.Default.ImageDialogLocation = this.oImageDialogScreenLocation;
            Properties.Settings.Default.ImageDialogSize = this.oImageDialogScreenSize;
            Properties.Settings.Default.ImageDialogWindowState = (int)this.oImageDialogWindowState;
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
                    ImagePreviewSizeValue = GetImagePreviewSize(),
                    IsSaveAndRemove = GetIsSaveAndRemove(),
                    SavePath = GetSaveDirectory(),
                    UserAgent = GetUserAgent(),
                },
                Dock = DockStyle.Fill
            };

            this.oImageDialogScreenLocation = Properties.Settings.Default.ImageDialogLocation;
            this.oImageDialogScreenSize = Properties.Settings.Default.ImageDialogSize;
            this.oImageDialogWindowState = (FormWindowState)Properties.Settings.Default.ImageDialogWindowState;

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

        private static int GetImagePreviewSize()
        {
            return Properties.Settings.Default.ImagePreviewSize;
        }

        private static bool GetIsSaveAndRemove()
        {
            return Properties.Settings.Default.IsSaveAndRemove;
        }

    }
}
