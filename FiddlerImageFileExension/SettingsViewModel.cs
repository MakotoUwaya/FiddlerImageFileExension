using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;

namespace FiddlerImageFileExension
{
    /// <summary>
    /// ViewModel on setting screen
    /// </summary>
    public class SettingsViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Amount of kiloBytes
        /// </summary>
	    private const int Kilobytes = 1000;

        /// <summary>
        /// INotifyPropertyChanged implement
        /// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Target view class reference
        /// TODO: 2018-07-24 OiChan Eliminate dependency on View
        /// </summary>
        private readonly Settings targetView;

        /// <summary>
        /// Configuration parameter to be persisted
        /// </summary>
        private readonly ISettingParameters settingParameters;

        private ImageDialog imageDialog;
        /// <summary>
        /// Dialog for displaying images
        /// </summary>
        private ImageDialog ImageDialog
        {
            get => this.imageDialog;
	        set
            {
                if (this.imageDialog == value)
                {
                    return;
                }
                this.imageDialog = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Size of <c>ImageDialog</c>
        /// </summary>
        private Size ImageDialogScreenSize
        {
            get => Properties.Settings.Default.ImageDialogSize;
	        set
            {
                if (this.ImageDialogScreenSize == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogSize = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Location of <c>ImageDialog</c>
        /// </summary>
        private Point ImageDialogScreenLocation
        {
            get => Properties.Settings.Default.ImageDialogLocation;
	        set
            {
                if (this.ImageDialogScreenLocation == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogLocation = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Window state of <c>ImageDialog</c> 
        /// </summary>
        private FormWindowState ImageDialogWindowState
        {
            get => (FormWindowState)Properties.Settings.Default.ImageDialogWindowState;
	        set
            {
                if (this.ImageDialogWindowState == value)
                {
                    return;
                }
                this.settingParameters.ImageDialogWindowState = (int)value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Destination directory path of the image file
        /// </summary>
        public string SavePath
        {
            get => this.settingParameters.SavePath;
	        set
            {
                if (this.SavePath == value)
                {
                    return;
                }
                this.settingParameters.SavePath = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Remove images from list when saving
        /// </summary>
        public bool IsSaveAndRemove
        {
            get => this.settingParameters.IsSaveAndRemove;
	        set
            {
                if (this.IsSaveAndRemove == value)
                {
                    return;
                }
                this.settingParameters.IsSaveAndRemove = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool capturing;
        /// <summary>
        /// Switch capture state
        /// </summary>
        public bool Capturing
        {
            get => this.capturing;
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

        /// <summary>
        /// String to be displayed on the capture button
        /// </summary>
        public string CaptureButtonText => this.Capturing ? " Stop Capture" : " Start Capture";

        /// <summary>
        /// Icon's image index to be displayed on the capture button
        /// </summary>
	    public int CaptureButtonImageIndex => this.Capturing ? 1 : 0;

        /// <summary>
        /// UserAgent during communication
        /// </summary>
	    public string UserAgent
        {
            get => this.settingParameters.UserAgent;
		    set
            {
                if (this.UserAgent == value)
                {
                    return;
                }
                this.settingParameters.UserAgent = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Use original setting for UserAgent
        /// </summary>
        public bool UsingOriginalSettings
        {
            get => this.settingParameters.UsingOriginalSettings;
	        set
            {
                if (this.UsingOriginalSettings == value)
                {
                    return;
                }
                this.settingParameters.UsingOriginalSettings = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Lower limit of target image size
        /// </summary>
        public long MinimumFileSize
        {
            get => this.settingParameters.MinimumFileSize;
	        set
            {
                if (this.MinimumFileSize == value)
                {
                    return;
                }
                this.settingParameters.MinimumFileSize = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Upper limit of target image size
        /// </summary>
        public long MaximumFileSize
        {
            get => this.settingParameters.MaximumFileSize;
	        set
            {
                if (this.MaximumFileSize == value)
                {
                    return;
                }
                this.settingParameters.MaximumFileSize = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// A character string representing the number of selected image files
        /// </summary>
        public string SelectedCountText => $"{this.SelectedCount:#,0} / {this.SelectedTotalCount:#,0}";

	    private int selectedCount;
        /// <summary>
        /// Number of selected image files
        /// </summary>
        public int SelectedCount
        {
            get => this.selectedCount;
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
        /// <summary>
        /// Total number of image files
        /// </summary>
        public int SelectedTotalCount
        {
            get => this.selectedTotalCount;
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

        /// <summary>
        /// Image preview display size
        /// </summary>
        public int ImagePreviewSizeValue
        {
            get => this.settingParameters.ImagePreviewSize;
	        set
            {
                if (this.ImagePreviewSizeValue == value)
                {
                    return;
                }
                this.settingParameters.ImagePreviewSize = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">Configuration parameter to be persisted</param>
        /// <param name="view">Target view class reference</param>
        public SettingsViewModel(ISettingParameters parameters, Settings view)
        {
            this.settingParameters = parameters;
            this.targetView = view;
        }

        /// <summary>
        /// Notify property change
        /// </summary>
        /// <param name="propertyName">Property name of target</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Showing image display dialog
        /// </summary>
        private void PictureBox_ShowingImageDialogWindow(object sender, EventArgs e)
        {
            var popupPictureBox = (PopupPictureBox)sender;
            var images = popupPictureBox.Parent.Controls.Cast<PopupPictureBox>().Select(p => p.Image).ToList();
            if (this.ImageDialog == null || this.ImageDialog.IsDisposed)
            {
                this.ImageDialog = new ImageDialog(images);
                this.ImageDialog.FormClosing += this.ImageDialog_FormClosing;
                this.ImageDialog.Show();
                this.ImageDialog.Location = this.ImageDialogScreenLocation;
                this.ImageDialog.Size = this.ImageDialogScreenSize;
                this.ImageDialog.WindowState = this.ImageDialogWindowState;
            }
            else
            {
                if (!ReferenceEquals(this.ImageDialog.Images, images))
                {
                    this.ImageDialog.Images = images;
                }

                this.ImageDialog.Show();
                if (this.ImageDialog.WindowState == FormWindowState.Minimized)
                {
                    this.ImageDialog.WindowState = FormWindowState.Normal;
                }
            }

            this.ImageDialog.SetImage(popupPictureBox.Image);
            this.ImageDialog.Activate();
        }

        /// <summary>
        /// Closing image display dialog
        /// </summary>
        private void ImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (Form)sender;
            this.ImageDialogScreenLocation = form.Bounds.Location;
            this.ImageDialogScreenSize = form.Bounds.Size;
            this.ImageDialogWindowState = form.WindowState == FormWindowState.Minimized
                ? FormWindowState.Maximized
                : form.WindowState;
        }

        /// <summary>
        /// Switch image selection state
        /// </summary>
        private void PictureBox_SelectionAllChanged(object sender, SelectablePictureEventArgs e)
        {

            this.targetView.SelectionAllChange(e.IsSelect);
        }

        /// <summary>
        /// Save all selected images
        /// </summary>
        private void PictureBox_SaveAll(object sender, EventArgs e)
        {
            this.targetView.SaveSelectedImages();
        }

        /// <summary>
        /// Remove all images
        /// </summary>
        private void PictureBox_Delete(object sender, EventArgs e)
        {
            this.targetView.RemoveFileImage((PictureBox)sender);
        }

        /// <summary>
        /// Remove all selected images
        /// </summary>
        private void PictureBox_DeleteAllSelected(object sender, EventArgs e)
        {
            this.targetView.RemoveSelectedImages();
        }

        /// <summary>
        /// Change selected state of image
        /// </summary>
        private void PictureBox_SelectionChanged(object sender, SelectablePictureEventArgs e)
        {
            this.targetView.SelectedCountUpdate();
        }

        /// <summary>
        /// Continuation judgment of image file processing
        /// </summary>
        /// <param name="session">session</param>
        /// <returns>Continuation judgment result</returns>
        private bool IsContinue(Session session)
        {
            if (!this.Capturing || !Directory.Exists(this.SavePath))
            {
                return false;
            }

            if (session?.responseCode != 200 || session.oResponse?.headers == null)
            {
                return false;
            }

            return session.oResponse.headers.ExistsAndContains("Content-Type", "image/") &&
                   !session.oResponse.headers.ExistsAndContains("Content-Type", "image/svg");
        }

        /// <summary>
        /// Add image file to list
        /// </summary>
        /// <param name="fileName">Image file name</param>
        /// <param name="imageBytes">Byte array of image file</param>
        private void AddImageFile(string fileName, byte[] imageBytes)
        {
            var stream = new MemoryStream(imageBytes);
            var image = Image.FromStream(stream);

            this.targetView.Invoke(new Action(() =>
            {
                var pictureBox = new PopupPictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(this.ImagePreviewSizeValue, this.ImagePreviewSizeValue),
                    SaveAction = () =>
                    {
                        // Remove extra description from file extension
                        var actualFileName = Regex.Replace(fileName, @"^(.+)\.(.+?)(?:|-.+)$", "$1.$2");

                        var loopCount = 0;
                        while (File.Exists($@"{this.SavePath}\{actualFileName}"))
                        {
                            actualFileName = Regex.Replace(actualFileName, @"^(.+)(?:|\(\d{0,2}\))\.(.+)$", $"$1({++loopCount}).$2");
                        }
                        image.Save($@"{this.SavePath}\{actualFileName}");
                    },
                };

                pictureBox.SelectionChanged += this.PictureBox_SelectionChanged;
                pictureBox.SelectionAllChanged += this.PictureBox_SelectionAllChanged;
                pictureBox.SaveAll += this.PictureBox_SaveAll;
                pictureBox.Delete += this.PictureBox_Delete;
                pictureBox.DeleteAllSelected += this.PictureBox_DeleteAllSelected;
                pictureBox.ShowingImageDialogWindow += this.PictureBox_ShowingImageDialogWindow;

                this.targetView.ImageFiles.Add(pictureBox);
            }));
        }

        /// <summary>
        /// Response modification
        /// </summary>
        /// <param name="session">session</param>
		public void AutoTamperResponseBefore(Session session)
		{
		    if (!this.IsContinue(session))
		    {
                return;
		    }

			try
			{
				session.utilDecodeResponse();

				if (this.MinimumFileSize != this.MaximumFileSize)
				{
					if (session.responseBodyBytes.Length < this.MinimumFileSize * Kilobytes ||
							this.MaximumFileSize * Kilobytes < session.responseBodyBytes.Length)
					{
						return;
					}
				}

			    this.AddImageFile(session.SuggestedFilename, session.responseBodyBytes);
			}
			catch (Exception ex) when (ex is ArgumentNullException || ex is ExternalException)
			{
				FiddlerApplication.Log.LogString($"ImageExtention Failed {ex}");
			}
		}

        /// <summary>
        /// IDisposable implement
        /// </summary>
        public void Dispose()
        {
            this.ImageDialog?.Dispose();
            this.settingParameters.Save();
        }
    }
}
