using System.Drawing;

namespace FiddlerImageFileExension
{
    public interface ISettingParameters
    {
        void Save();

        long MinimumFileSize { get; set; }
        long MaximumFileSize { get; set; }
        int ImagePreviewSize { get; set; }
        bool IsSaveAndRemove { get; set; }
        string SavePath { get; set; }
        string UserAgent { get; set; }
        Point ImageDialogLocation { get; set; }
        Size ImageDialogSize { get; set; }
        int ImageDialogWindowState { get; set; }
        bool UsingOriginalSettings { get; set; }
    }
}
