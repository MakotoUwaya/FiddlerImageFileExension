using System;
using System.Drawing;
using System.IO;

namespace FiddlerImageFileExension
{
	public class SettingParameters : ISettingParameters
	{
		public void Save()
		{
			Properties.Settings.Default.Save();
		}

		public long MinimumFileSize
		{
			get => Properties.Settings.Default.MinimumFileSize;
			set => Properties.Settings.Default.MinimumFileSize = value;
		}
		public long MaximumFileSize
		{
			get => Properties.Settings.Default.MaximumFileSize;
			set => Properties.Settings.Default.MaximumFileSize = value;
		}
		public int ImagePreviewSize
		{
			get => Properties.Settings.Default.ImagePreviewSize;
			set => Properties.Settings.Default.ImagePreviewSize = value;
		}
		public bool IsSaveAndRemove
		{
			get => Properties.Settings.Default.IsSaveAndRemove;
			set => Properties.Settings.Default.IsSaveAndRemove = value;
		}
		public string SavePath
		{
			get
			{
				var saveDirectory = Properties.Settings.Default.SavePath;
				if (string.IsNullOrWhiteSpace(saveDirectory) || !Directory.Exists(saveDirectory))
				{
					saveDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Downloads";
				}
				return saveDirectory;
			}
			set => Properties.Settings.Default.SavePath = value;
		}
		public string UserAgent
		{
			get => Properties.Settings.Default.UserAgent;
			set => Properties.Settings.Default.UserAgent = value;
		}
		public Point ImageDialogLocation
		{
			get => Properties.Settings.Default.ImageDialogLocation;
			set => Properties.Settings.Default.ImageDialogLocation = value;
		}
		public Size ImageDialogSize
		{
			get => Properties.Settings.Default.ImageDialogSize;
			set => Properties.Settings.Default.ImageDialogSize = value;
		}
		public int ImageDialogWindowState
		{
			get => Properties.Settings.Default.ImageDialogWindowState;
			set => Properties.Settings.Default.ImageDialogWindowState = value;
		}
		public bool UsingOriginalSettings
		{
			get => Properties.Settings.Default.UsingOriginalSettings;
			set => Properties.Settings.Default.UsingOriginalSettings = value;
		}

	}
}
