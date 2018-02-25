using System;

namespace FiddlerImageFileExension
{
    public class SelectablePictureEventArgs : EventArgs
    {
        public bool IsSelect { get; set; }

        public SelectablePictureEventArgs(bool isSelect)
        {
            this.IsSelect = isSelect;
        }
    }
}
