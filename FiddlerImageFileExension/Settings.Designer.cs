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
            this.label1 = new System.Windows.Forms.Label();
            this.SaveDirectoryPathTextbox = new System.Windows.Forms.TextBox();
            this.settingsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.IsSaveImagesCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.SaveDirectoryPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDirectoryPathTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "SavePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SaveDirectoryPathTextbox.Location = new System.Drawing.Point(165, 47);
            this.SaveDirectoryPathTextbox.Name = "SaveDirectoryPathTextbox";
            this.SaveDirectoryPathTextbox.Size = new System.Drawing.Size(628, 19);
            this.SaveDirectoryPathTextbox.TabIndex = 3;
            // 
            // settingsViewModelBindingSource
            // 
            this.settingsViewModelBindingSource.DataSource = typeof(FiddlerImageFileExension.SettingsViewModel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Save images";
            // 
            // IsSaveImagesCheckbox
            // 
            this.IsSaveImagesCheckbox.AutoSize = true;
            this.IsSaveImagesCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.settingsViewModelBindingSource, "IsCreateImage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsSaveImagesCheckbox.Location = new System.Drawing.Point(165, 86);
            this.IsSaveImagesCheckbox.Name = "IsSaveImagesCheckbox";
            this.IsSaveImagesCheckbox.Size = new System.Drawing.Size(15, 14);
            this.IsSaveImagesCheckbox.TabIndex = 5;
            this.IsSaveImagesCheckbox.UseVisualStyleBackColor = true;
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
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsViewModelBindingSource, "UserAgent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(165, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(628, 19);
            this.textBox1.TabIndex = 1;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.IsSaveImagesCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveDirectoryPathTextbox);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(808, 120);
            ((System.ComponentModel.ISupportInitialize)(this.settingsViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SaveDirectoryPathTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsSaveImagesCheckbox;
        private System.Windows.Forms.BindingSource settingsViewModelBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}
