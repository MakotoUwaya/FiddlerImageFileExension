﻿namespace FiddlerImageFileExension
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
            this.IsSaveWithImageClear = new System.Windows.Forms.CheckBox();
            this.settingsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MinimumFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageSizeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destination directory path";
            // 
            // SaveDirectoryPathTextbox
            // 
            this.SaveDirectoryPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDirectoryPathTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "SavePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveDirectoryPathTextbox.Location = new System.Drawing.Point(165, 47);
            this.SaveDirectoryPathTextbox.Name = "SaveDirectoryPathTextbox";
            this.SaveDirectoryPathTextbox.Size = new System.Drawing.Size(756, 19);
            this.SaveDirectoryPathTextbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Http user agent";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "UserAgent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(165, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(756, 19);
            this.textBox1.TabIndex = 1;
            // 
            // FileImageListPanel
            // 
            this.FileImageListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileImageListPanel.AutoScroll = true;
            this.FileImageListPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.FileImageListPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FileImageListPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileImageListPanel.Location = new System.Drawing.Point(15, 146);
            this.FileImageListPanel.Name = "FileImageListPanel";
            this.FileImageListPanel.Size = new System.Drawing.Size(906, 131);
            this.FileImageListPanel.TabIndex = 6;
            this.FileImageListPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.FileImageListPanel_ControlAdded);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 86);
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
            this.MinimumFileSize.Location = new System.Drawing.Point(165, 81);
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
            this.MaximumFileSize.Location = new System.Drawing.Point(399, 81);
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
            this.label5.Location = new System.Drawing.Point(273, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Maximum file size(KB)";
            // 
            // ClearSelectedImagesButton
            // 
            this.ClearSelectedImagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearSelectedImagesButton.Location = new System.Drawing.Point(768, 117);
            this.ClearSelectedImagesButton.Name = "ClearSelectedImagesButton";
            this.ClearSelectedImagesButton.Size = new System.Drawing.Size(153, 23);
            this.ClearSelectedImagesButton.TabIndex = 0;
            this.ClearSelectedImagesButton.Text = "Clear Selected Images";
            this.ClearSelectedImagesButton.UseVisualStyleBackColor = true;
            this.ClearSelectedImagesButton.Click += new System.EventHandler(this.ClearImagesButton_Click);
            // 
            // SaveSelectedImagesButton
            // 
            this.SaveSelectedImagesButton.Location = new System.Drawing.Point(15, 117);
            this.SaveSelectedImagesButton.Name = "SaveSelectedImagesButton";
            this.SaveSelectedImagesButton.Size = new System.Drawing.Size(153, 23);
            this.SaveSelectedImagesButton.TabIndex = 11;
            this.SaveSelectedImagesButton.Text = "Save Selected Images";
            this.SaveSelectedImagesButton.UseVisualStyleBackColor = true;
            this.SaveSelectedImagesButton.Click += new System.EventHandler(this.SaveSelectedImagesButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(324, 117);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(106, 23);
            this.SelectAllButton.TabIndex = 12;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // UnSelectAllButton
            // 
            this.UnSelectAllButton.Location = new System.Drawing.Point(436, 117);
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
            this.label2.Location = new System.Drawing.Point(560, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selected Image";
            // 
            // SelectedImageCount
            // 
            this.SelectedImageCount.AutoSize = true;
            this.SelectedImageCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "SelectedCountText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SelectedImageCount.Location = new System.Drawing.Point(661, 122);
            this.SelectedImageCount.Name = "SelectedImageCount";
            this.SelectedImageCount.Size = new System.Drawing.Size(71, 12);
            this.SelectedImageCount.TabIndex = 15;
            this.SelectedImageCount.Text = "1,987 / 9,999";
            // 
            // PreviewImageSizeSlider
            // 
            this.PreviewImageSizeSlider.AutoSize = false;
            this.PreviewImageSizeSlider.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingsViewModelBindingSource, "ImageSizeValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PreviewImageSizeSlider.LargeChange = 10;
            this.PreviewImageSizeSlider.Location = new System.Drawing.Point(589, 81);
            this.PreviewImageSizeSlider.Maximum = 500;
            this.PreviewImageSizeSlider.Minimum = 20;
            this.PreviewImageSizeSlider.Name = "PreviewImageSizeSlider";
            this.PreviewImageSizeSlider.Size = new System.Drawing.Size(151, 45);
            this.PreviewImageSizeSlider.SmallChange = 5;
            this.PreviewImageSizeSlider.TabIndex = 16;
            this.PreviewImageSizeSlider.TickFrequency = 50;
            this.PreviewImageSizeSlider.Value = 150;
            this.PreviewImageSizeSlider.ValueChanged += new System.EventHandler(this.PreviewImageSizeSlider_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(514, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Preview size";
            // 
            // IsSaveWithImageClear
            // 
            this.IsSaveWithImageClear.AutoSize = true;
            this.IsSaveWithImageClear.Checked = true;
            this.IsSaveWithImageClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsSaveWithImageClear.Location = new System.Drawing.Point(174, 121);
            this.IsSaveWithImageClear.Name = "IsSaveWithImageClear";
            this.IsSaveWithImageClear.Size = new System.Drawing.Size(75, 16);
            this.IsSaveWithImageClear.TabIndex = 18;
            this.IsSaveWithImageClear.Text = "With clear";
            this.IsSaveWithImageClear.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.IsSaveWithImageClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SelectedImageCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnSelectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.SaveSelectedImagesButton);
            this.Controls.Add(this.ClearSelectedImagesButton);
            this.Controls.Add(this.MaximumFileSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MinimumFileSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FileImageListPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveDirectoryPathTextbox);
            this.Controls.Add(this.PreviewImageSizeSlider);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(936, 280);
            ((System.ComponentModel.ISupportInitialize)(this.MinimumFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewImageSizeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox IsSaveWithImageClear;
    }
}
