namespace Client.UI.Forms.DialogForms
{
    partial class DownloadFileInfoDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DownloadFileInfoDialogForm));
            mxLabel1 = new UserControls.Common.MxLabel();
            mxLabel2 = new UserControls.Common.MxLabel();
            mxLabel3 = new UserControls.Common.MxLabel();
            downloadURLTextbox = new UserControls.Common.MxTextBox();
            mxTextBox2 = new UserControls.Common.MxTextBox();
            mxButton15 = new UserControls.Common.MxButton();
            mxButton1 = new UserControls.Common.MxButton();
            fileTypeImage = new PictureEdit();
            mxButton2 = new UserControls.Common.MxButton();
            mxButton3 = new UserControls.Common.MxButton();
            mxCancelButton1 = new UserControls.Common.MxCancelButton();
            FileSizeLabel = new UserControls.Common.MxLabel();
            FileTypeGroupComboBox = new UserControls.Common.MxComboBox();
            fileTypeGroupViewModelBindingSource = new BindingSource(components);
            ((ISupportInitialize)downloadURLTextbox.Properties).BeginInit();
            ((ISupportInitialize)mxTextBox2.Properties).BeginInit();
            ((ISupportInitialize)fileTypeImage.Properties).BeginInit();
            ((ISupportInitialize)FileTypeGroupComboBox.Properties).BeginInit();
            ((ISupportInitialize)fileTypeGroupViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Location = new Point(51, 23);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(35, 17);
            mxLabel1.TabIndex = 0;
            mxLabel1.Text = "آدرس : ";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(58, 61);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(28, 17);
            mxLabel2.TabIndex = 0;
            mxLabel2.Text = "گروه : ";
            // 
            // mxLabel3
            // 
            mxLabel3.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel3.Appearance.Options.UseFont = true;
            mxLabel3.Location = new Point(31, 99);
            mxLabel3.Name = "mxLabel3";
            mxLabel3.Size = new Size(55, 17);
            mxLabel3.TabIndex = 0;
            mxLabel3.Text = "محل ذخیره : ";
            // 
            // downloadURLTextbox
            // 
            downloadURLTextbox.Enabled = false;
            downloadURLTextbox.Location = new Point(92, 16);
            downloadURLTextbox.Name = "downloadURLTextbox";
            downloadURLTextbox.Size = new Size(477, 28);
            downloadURLTextbox.TabIndex = 1;
            // 
            // mxTextBox2
            // 
            mxTextBox2.Location = new Point(92, 92);
            mxTextBox2.Name = "mxTextBox2";
            mxTextBox2.Size = new Size(428, 28);
            mxTextBox2.TabIndex = 2;
            // 
            // mxButton15
            // 
            mxButton15.Appearance.BackColor = Color.Gainsboro;
            mxButton15.Appearance.Options.UseBackColor = true;
            mxButton15.Location = new Point(527, 56);
            mxButton15.Name = "mxButton15";
            mxButton15.Size = new Size(42, 23);
            mxButton15.TabIndex = 20;
            mxButton15.Text = "+";
            mxButton15.Click += mxButton15_Click;
            // 
            // mxButton1
            // 
            mxButton1.Appearance.BackColor = Color.Gainsboro;
            mxButton1.Appearance.Options.UseBackColor = true;
            mxButton1.Location = new Point(527, 94);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(42, 23);
            mxButton1.TabIndex = 21;
            mxButton1.Text = "...";
            // 
            // fileTypeImage
            // 
            fileTypeImage.EditValue = resources.GetObject("fileTypeImage.EditValue");
            fileTypeImage.Location = new Point(593, 12);
            fileTypeImage.Name = "fileTypeImage";
            fileTypeImage.Properties.ErrorImageOptions.Image = (Image)resources.GetObject("fileTypeImage.Properties.ErrorImageOptions.Image");
            fileTypeImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            fileTypeImage.Size = new Size(165, 108);
            fileTypeImage.TabIndex = 22;
            // 
            // mxButton2
            // 
            mxButton2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxButton2.ImageOptions.SvgImage");
            mxButton2.ImageOptions.SvgImageSize = new Size(16, 16);
            mxButton2.Location = new Point(227, 152);
            mxButton2.Name = "mxButton2";
            mxButton2.Size = new Size(129, 30);
            mxButton2.TabIndex = 23;
            mxButton2.Text = "بعدا دانلود شود";
            // 
            // mxButton3
            // 
            mxButton3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxButton3.ImageOptions.SvgImage");
            mxButton3.ImageOptions.SvgImageSize = new Size(16, 16);
            mxButton3.Location = new Point(92, 152);
            mxButton3.Name = "mxButton3";
            mxButton3.Size = new Size(129, 30);
            mxButton3.TabIndex = 24;
            mxButton3.Text = "شروع دانلود";
            // 
            // mxCancelButton1
            // 
            mxCancelButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            mxCancelButton1.DialogResult = DialogResult.Cancel;
            mxCancelButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxCancelButton1.ImageOptions.SvgImage");
            mxCancelButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            mxCancelButton1.Location = new Point(499, 152);
            mxCancelButton1.Name = "mxCancelButton1";
            mxCancelButton1.Size = new Size(70, 30);
            mxCancelButton1.TabIndex = 25;
            mxCancelButton1.Text = "انصراف";
            // 
            // FileSizeLabel
            // 
            FileSizeLabel.Appearance.Font = new Font("B Yekan", 12F, FontStyle.Regular, GraphicsUnit.Point, 178);
            FileSizeLabel.Appearance.Options.UseFont = true;
            FileSizeLabel.Location = new Point(593, 126);
            FileSizeLabel.Name = "FileSizeLabel";
            FileSizeLabel.Size = new Size(68, 24);
            FileSizeLabel.TabIndex = 26;
            FileSizeLabel.Text = "20 مگابایت";
            // 
            // FileTypeGroupComboBox
            // 
            FileTypeGroupComboBox.Location = new Point(92, 54);
            FileTypeGroupComboBox.Name = "FileTypeGroupComboBox";
            FileTypeGroupComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FileTypeGroupComboBox.Properties.DataSource = fileTypeGroupViewModelBindingSource;
            FileTypeGroupComboBox.Properties.DisplayMember = "Title";
            FileTypeGroupComboBox.Properties.PopupFilterMode = PopupFilterMode.Contains;
            FileTypeGroupComboBox.Properties.ValueMember = "Id";
            FileTypeGroupComboBox.Size = new Size(429, 28);
            FileTypeGroupComboBox.TabIndex = 27;
            // 
            // fileTypeGroupViewModelBindingSource
            // 
            fileTypeGroupViewModelBindingSource.DataSource = typeof(ViewModel.FileTypeGroup.FileTypeGroupViewModel);
            // 
            // DownloadFileInfoDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 199);
            Controls.Add(FileTypeGroupComboBox);
            Controls.Add(FileSizeLabel);
            Controls.Add(mxCancelButton1);
            Controls.Add(mxButton3);
            Controls.Add(mxButton2);
            Controls.Add(fileTypeImage);
            Controls.Add(mxButton1);
            Controls.Add(mxButton15);
            Controls.Add(mxTextBox2);
            Controls.Add(downloadURLTextbox);
            Controls.Add(mxLabel3);
            Controls.Add(mxLabel2);
            Controls.Add(mxLabel1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "DownloadFileInfoDialogForm";
            Text = "مشخصات فایل دانلود";
            Load += DownloadFileInfoDialogForm_Load;
            ((ISupportInitialize)downloadURLTextbox.Properties).EndInit();
            ((ISupportInitialize)mxTextBox2.Properties).EndInit();
            ((ISupportInitialize)fileTypeImage.Properties).EndInit();
            ((ISupportInitialize)FileTypeGroupComboBox.Properties).EndInit();
            ((ISupportInitialize)fileTypeGroupViewModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxLabel mxLabel2;
        private UserControls.Common.MxLabel mxLabel3;
        private UserControls.Common.MxTextBox downloadURLTextbox;
        private UserControls.Common.MxTextBox mxTextBox2;
        private UserControls.Common.MxButton mxButton15;
        private UserControls.Common.MxButton mxButton1;
        private PictureEdit fileTypeImage;
        private UserControls.Common.MxButton mxButton2;
        private UserControls.Common.MxButton mxButton3;
        private UserControls.Common.MxCancelButton mxCancelButton1;
        private UserControls.Common.MxLabel FileSizeLabel;
        private UserControls.Common.MxComboBox FileTypeGroupComboBox;
        private BindingSource fileTypeGroupViewModelBindingSource;
    }
}