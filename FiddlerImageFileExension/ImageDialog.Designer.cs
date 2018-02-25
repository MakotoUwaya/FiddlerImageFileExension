namespace FiddlerImageFileExension
{
    partial class ImageDialog
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureImage
            // 
            this.PictureImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureImage.Location = new System.Drawing.Point(0, 0);
            this.PictureImage.Margin = new System.Windows.Forms.Padding(0);
            this.PictureImage.Name = "PictureImage";
            this.PictureImage.Size = new System.Drawing.Size(380, 237);
            this.PictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureImage.TabIndex = 0;
            this.PictureImage.TabStop = false;
            // 
            // ImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 237);
            this.Controls.Add(this.PictureImage);
            this.KeyPreview = true;
            this.Name = "ImageDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageDialog";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ImageDialog_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureImage;
    }
}
