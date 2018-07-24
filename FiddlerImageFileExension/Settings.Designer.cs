namespace FiddlerImageFileExension
{
    partial class Settings
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.SaveDirectoryPathTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FileImageListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.MinimumFileSize = new System.Windows.Forms.NumericUpDown();
            this.MaximumFileSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearSelectedImagesButton = new System.Windows.Forms.Button();
            this.SaveSelectedImagesButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.UnSelectAllButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedImageCount = new System.Windows.Forms.Label();
            this.PreviewImageSizeSlider = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.IsSaveAndRemoveCheckBox = new System.Windows.Forms.CheckBox();
            this.ChangeCaptureStatusButton = new System.Windows.Forms.Button();
            this.StatusButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SelectDirectoryButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MinimumFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageSizeSlider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destination directory path";
            // 
            // SaveDirectoryPathTextbox
            // 
            this.SaveDirectoryPathTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "SavePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveDirectoryPathTextbox.Location = new System.Drawing.Point(251, 50);
            this.SaveDirectoryPathTextbox.Name = "SaveDirectoryPathTextbox";
            this.SaveDirectoryPathTextbox.Size = new System.Drawing.Size(445, 19);
            this.SaveDirectoryPathTextbox.TabIndex = 3;
            this.SaveDirectoryPathTextbox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Http user agent";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "UserAgent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(251, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 19);
            this.textBox1.TabIndex = 1;
            // 
            // FileImageListPanel
            // 
            this.FileImageListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileImageListPanel.AutoScroll = true;
            this.FileImageListPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FileImageListPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileImageListPanel.Location = new System.Drawing.Point(3, 149);
            this.FileImageListPanel.Margin = new System.Windows.Forms.Padding(3, 200, 3, 200);
            this.FileImageListPanel.Name = "FileImageListPanel";
            this.FileImageListPanel.Size = new System.Drawing.Size(924, 25);
            this.FileImageListPanel.TabIndex = 6;
            this.FileImageListPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.FileImageListPanel_ControlAdded);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Minimum file size(KB)";
            // 
            // MinimumFileSize
            // 
            this.MinimumFileSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingsViewModelBindingSource, "MinimumFileSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.MinimumFileSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MinimumFileSize.Location = new System.Drawing.Point(251, 84);
            this.MinimumFileSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MinimumFileSize.Name = "MinimumFileSize";
            this.MinimumFileSize.Size = new System.Drawing.Size(86, 19);
            this.MinimumFileSize.TabIndex = 8;
            this.MinimumFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MaximumFileSize
            // 
            this.MaximumFileSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingsViewModelBindingSource, "MaximumFileSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.MaximumFileSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaximumFileSize.Location = new System.Drawing.Point(479, 84);
            this.MaximumFileSize.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.MaximumFileSize.Name = "MaximumFileSize";
            this.MaximumFileSize.Size = new System.Drawing.Size(79, 19);
            this.MaximumFileSize.TabIndex = 10;
            this.MaximumFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaximumFileSize.Value = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Maximum file size(KB)";
            // 
            // ClearSelectedImagesButton
            // 
            this.ClearSelectedImagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearSelectedImagesButton.Location = new System.Drawing.Point(774, 120);
            this.ClearSelectedImagesButton.Name = "ClearSelectedImagesButton";
            this.ClearSelectedImagesButton.Size = new System.Drawing.Size(153, 23);
            this.ClearSelectedImagesButton.TabIndex = 0;
            this.ClearSelectedImagesButton.Text = "Clear Selected Images";
            this.ClearSelectedImagesButton.UseVisualStyleBackColor = true;
            this.ClearSelectedImagesButton.Click += new System.EventHandler(this.ClearImagesButton_Click);
            // 
            // SaveSelectedImagesButton
            // 
            this.SaveSelectedImagesButton.Location = new System.Drawing.Point(13, 120);
            this.SaveSelectedImagesButton.Name = "SaveSelectedImagesButton";
            this.SaveSelectedImagesButton.Size = new System.Drawing.Size(142, 23);
            this.SaveSelectedImagesButton.TabIndex = 11;
            this.SaveSelectedImagesButton.Text = "Save Selected Images";
            this.SaveSelectedImagesButton.UseVisualStyleBackColor = true;
            this.SaveSelectedImagesButton.Click += new System.EventHandler(this.SaveSelectedImagesButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(264, 120);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(106, 23);
            this.SelectAllButton.TabIndex = 12;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // UnSelectAllButton
            // 
            this.UnSelectAllButton.Location = new System.Drawing.Point(376, 120);
            this.UnSelectAllButton.Name = "UnSelectAllButton";
            this.UnSelectAllButton.Size = new System.Drawing.Size(106, 23);
            this.UnSelectAllButton.TabIndex = 13;
            this.UnSelectAllButton.Text = "UnSelect All";
            this.UnSelectAllButton.UseVisualStyleBackColor = true;
            this.UnSelectAllButton.Click += new System.EventHandler(this.UnSelectAllButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selected Image";
            // 
            // SelectedImageCount
            // 
            this.SelectedImageCount.AutoSize = true;
            this.SelectedImageCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "SelectedCountText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SelectedImageCount.Location = new System.Drawing.Point(577, 125);
            this.SelectedImageCount.Name = "SelectedImageCount";
            this.SelectedImageCount.Size = new System.Drawing.Size(71, 12);
            this.SelectedImageCount.TabIndex = 15;
            this.SelectedImageCount.Text = "1,987 / 9,999";
            // 
            // PreviewImageSizeSlider
            // 
            this.PreviewImageSizeSlider.AutoSize = false;
            this.PreviewImageSizeSlider.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingsViewModelBindingSource, "ImagePreviewSizeValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PreviewImageSizeSlider.LargeChange = 10;
            this.PreviewImageSizeSlider.Location = new System.Drawing.Point(639, 84);
            this.PreviewImageSizeSlider.Maximum = 500;
            this.PreviewImageSizeSlider.Minimum = 20;
            this.PreviewImageSizeSlider.Name = "PreviewImageSizeSlider";
            this.PreviewImageSizeSlider.Size = new System.Drawing.Size(192, 45);
            this.PreviewImageSizeSlider.SmallChange = 5;
            this.PreviewImageSizeSlider.TabIndex = 16;
            this.PreviewImageSizeSlider.TickFrequency = 50;
            this.PreviewImageSizeSlider.Value = 150;
            this.PreviewImageSizeSlider.ValueChanged += new System.EventHandler(this.PreviewImageSizeSlider_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Preview size";
            // 
            // IsSaveAndRemoveCheckBox
            // 
            this.IsSaveAndRemoveCheckBox.AutoSize = true;
            this.IsSaveAndRemoveCheckBox.Checked = true;
            this.IsSaveAndRemoveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsSaveAndRemoveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.settingsViewModelBindingSource, "IsSaveAndRemove", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsSaveAndRemoveCheckBox.Location = new System.Drawing.Point(160, 124);
            this.IsSaveAndRemoveCheckBox.Name = "IsSaveAndRemoveCheckBox";
            this.IsSaveAndRemoveCheckBox.Size = new System.Drawing.Size(75, 16);
            this.IsSaveAndRemoveCheckBox.TabIndex = 18;
            this.IsSaveAndRemoveCheckBox.Text = "With clear";
            this.IsSaveAndRemoveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChangeCaptureStatusButton
            // 
            this.ChangeCaptureStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ChangeCaptureStatusButton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "CaptureButtonText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ChangeCaptureStatusButton.DataBindings.Add(new System.Windows.Forms.Binding("ImageIndex", this.settingsViewModelBindingSource, "CaptureButtonImageIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ChangeCaptureStatusButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ChangeCaptureStatusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ChangeCaptureStatusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ChangeCaptureStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeCaptureStatusButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChangeCaptureStatusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeCaptureStatusButton.ImageIndex = 0;
            this.ChangeCaptureStatusButton.ImageList = this.StatusButtonImageList;
            this.ChangeCaptureStatusButton.Location = new System.Drawing.Point(13, 3);
            this.ChangeCaptureStatusButton.Name = "ChangeCaptureStatusButton";
            this.ChangeCaptureStatusButton.Size = new System.Drawing.Size(142, 26);
            this.ChangeCaptureStatusButton.TabIndex = 19;
            this.ChangeCaptureStatusButton.Text = " Caputure Start";
            this.ChangeCaptureStatusButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangeCaptureStatusButton.UseVisualStyleBackColor = false;
            this.ChangeCaptureStatusButton.Click += new System.EventHandler(this.ChangeCaptureStatusButton_Click);
            // 
            // StatusButtonImageList
            // 
            this.StatusButtonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StatusButtonImageList.ImageStream")));
            this.StatusButtonImageList.TransparentColor = System.Drawing.Color.White;
            this.StatusButtonImageList.Images.SetKeyName(0, "Rec.png");
            this.StatusButtonImageList.Images.SetKeyName(1, "Stop.png");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.settingsViewModelBindingSource, "UsingOriginalSettings", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(702, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 16);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Use original settings";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SelectDirectoryButton
            // 
            this.SelectDirectoryButton.Location = new System.Drawing.Point(702, 48);
            this.SelectDirectoryButton.Name = "SelectDirectoryButton";
            this.SelectDirectoryButton.Size = new System.Drawing.Size(129, 23);
            this.SelectDirectoryButton.TabIndex = 21;
            this.SelectDirectoryButton.Text = "Select Directory";
            this.SelectDirectoryButton.UseVisualStyleBackColor = true;
            this.SelectDirectoryButton.Click += new System.EventHandler(this.SelectDirectoryButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ChangeCaptureStatusButton);
            this.panel1.Controls.Add(this.FileImageListPanel);
            this.panel1.Controls.Add(this.SelectDirectoryButton);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.SaveDirectoryPathTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IsSaveAndRemoveCheckBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SelectedImageCount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MinimumFileSize);
            this.panel1.Controls.Add(this.UnSelectAllButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.SelectAllButton);
            this.panel1.Controls.Add(this.MaximumFileSize);
            this.panel1.Controls.Add(this.SaveSelectedImagesButton);
            this.panel1.Controls.Add(this.ClearSelectedImagesButton);
            this.panel1.Controls.Add(this.PreviewImageSizeSlider);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 278);
            this.panel1.TabIndex = 22;
            // 
            // settingsViewModelBindingSource
            // 
            this.settingsViewModelBindingSource.DataSource = typeof(FiddlerImageFileExension.SettingsViewModel);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(936, 284);
            ((System.ComponentModel.ISupportInitialize)(this.MinimumFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageSizeSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SaveDirectoryPathTextbox;
        private System.Windows.Forms.BindingSource settingsViewModelBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel FileImageListPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown MinimumFileSize;
        private System.Windows.Forms.NumericUpDown MaximumFileSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ClearSelectedImagesButton;
        private System.Windows.Forms.Button SaveSelectedImagesButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button UnSelectAllButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SelectedImageCount;
        private System.Windows.Forms.TrackBar PreviewImageSizeSlider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox IsSaveAndRemoveCheckBox;
        private System.Windows.Forms.Button ChangeCaptureStatusButton;
        private System.Windows.Forms.ImageList StatusButtonImageList;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button SelectDirectoryButton;
        private System.Windows.Forms.Panel panel1;
    }
}
