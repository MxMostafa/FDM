namespace Client.UI.Forms.DialogForms
{
    partial class EditFileTypeGroupDialogForm
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
            mxActionGroup1 = new UserControls.Common.MxActionGroup();
            mxLabel1 = new UserControls.Common.MxLabel();
            mxLabel2 = new UserControls.Common.MxLabel();
            groumNameTextbox = new UserControls.Common.MxTextBox();
            mxDescriptionLabel1 = new UserControls.Common.MxDescriptionLabel();
            ExtensionsTextbox = new UserControls.Common.MxAreaTextBox();
            mxDescriptionLabel2 = new UserControls.Common.MxDescriptionLabel();
            DeleteFileTypeGroupButton = new UserControls.Common.MxButton();
            ChangeSavePathButton = new UserControls.Common.MxButton();
            FileTypeGroupSavePathTextBox = new UserControls.Common.MxTextBox();
            mxLabel3 = new UserControls.Common.MxLabel();
            xtraFolderBrowserDialog1 = new XtraFolderBrowserDialog(components);
            ((ISupportInitialize)groumNameTextbox.Properties).BeginInit();
            ((ISupportInitialize)ExtensionsTextbox.Properties).BeginInit();
            ((ISupportInitialize)FileTypeGroupSavePathTextBox.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxActionGroup1.Location = new Point(0, 280);
            mxActionGroup1.Name = "mxActionGroup1";
            mxActionGroup1.RightToLeft = RightToLeft.Yes;
            mxActionGroup1.Size = new Size(457, 39);
            mxActionGroup1.TabIndex = 0;
            mxActionGroup1.SaveButtonClick += mxActionGroup1_SaveButtonClick;
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Location = new Point(27, 22);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(43, 17);
            mxLabel1.TabIndex = 3;
            mxLabel1.Text = "نام گروه : ";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(27, 129);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(47, 17);
            mxLabel2.TabIndex = 3;
            mxLabel2.Text = "پسوند ها : ";
            // 
            // groumNameTextbox
            // 
            groumNameTextbox.Location = new Point(77, 17);
            groumNameTextbox.Name = "groumNameTextbox";
            groumNameTextbox.Size = new Size(268, 28);
            groumNameTextbox.TabIndex = 4;
            groumNameTextbox.ToolTipTitle = "مثال : فایل های فشرده";
            // 
            // mxDescriptionLabel1
            // 
            mxDescriptionLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxDescriptionLabel1.Appearance.Options.UseFont = true;
            mxDescriptionLabel1.Appearance.Options.UseTextOptions = true;
            mxDescriptionLabel1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            mxDescriptionLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            mxDescriptionLabel1.AutoSizeMode = LabelAutoSizeMode.None;
            mxDescriptionLabel1.LineLocation = LineLocation.Top;
            mxDescriptionLabel1.LineOrientation = LabelLineOrientation.Vertical;
            mxDescriptionLabel1.Location = new Point(77, 51);
            mxDescriptionLabel1.Name = "mxDescriptionLabel1";
            mxDescriptionLabel1.Size = new Size(368, 26);
            mxDescriptionLabel1.TabIndex = 5;
            mxDescriptionLabel1.Text = "مثال : فایل های صوتی";
            // 
            // ExtensionsTextbox
            // 
            ExtensionsTextbox.EditValue = "";
            ExtensionsTextbox.Location = new Point(77, 127);
            ExtensionsTextbox.Name = "ExtensionsTextbox";
            ExtensionsTextbox.Size = new Size(368, 105);
            ExtensionsTextbox.TabIndex = 6;
            // 
            // mxDescriptionLabel2
            // 
            mxDescriptionLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxDescriptionLabel2.Appearance.Options.UseFont = true;
            mxDescriptionLabel2.Appearance.Options.UseTextOptions = true;
            mxDescriptionLabel2.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            mxDescriptionLabel2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            mxDescriptionLabel2.AutoSizeMode = LabelAutoSizeMode.None;
            mxDescriptionLabel2.LineLocation = LineLocation.Top;
            mxDescriptionLabel2.LineOrientation = LabelLineOrientation.Vertical;
            mxDescriptionLabel2.Location = new Point(77, 238);
            mxDescriptionLabel2.Name = "mxDescriptionLabel2";
            mxDescriptionLabel2.Size = new Size(368, 26);
            mxDescriptionLabel2.TabIndex = 7;
            mxDescriptionLabel2.Text = "پسوندها را با فاصله از هم جدا کنید  مثال : mp3 wave";
            // 
            // DeleteFileTypeGroupButton
            // 
            DeleteFileTypeGroupButton.Appearance.BackColor = Color.Gainsboro;
            DeleteFileTypeGroupButton.Appearance.Options.UseBackColor = true;
            DeleteFileTypeGroupButton.Appearance.Options.UseTextOptions = true;
            DeleteFileTypeGroupButton.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            DeleteFileTypeGroupButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            DeleteFileTypeGroupButton.ImageOptions.SvgImage = Properties.Resources.Delete;
            DeleteFileTypeGroupButton.ImageOptions.SvgImageSize = new Size(15, 15);
            DeleteFileTypeGroupButton.Location = new Point(351, 15);
            DeleteFileTypeGroupButton.Name = "DeleteFileTypeGroupButton";
            DeleteFileTypeGroupButton.Size = new Size(94, 31);
            DeleteFileTypeGroupButton.TabIndex = 21;
            DeleteFileTypeGroupButton.Text = "حذف گروه";
            DeleteFileTypeGroupButton.Click += DeleteFileTypeGroupButton_Click;
            // 
            // ChangeSavePathButton
            // 
            ChangeSavePathButton.Appearance.BackColor = Color.Gainsboro;
            ChangeSavePathButton.Appearance.Options.UseBackColor = true;
            ChangeSavePathButton.Location = new Point(403, 85);
            ChangeSavePathButton.Name = "ChangeSavePathButton";
            ChangeSavePathButton.Size = new Size(42, 23);
            ChangeSavePathButton.TabIndex = 27;
            ChangeSavePathButton.Text = "...";
            ChangeSavePathButton.Click += ChangeSavePathButton_Click;
            // 
            // FileTypeGroupSavePathTextBox
            // 
            FileTypeGroupSavePathTextBox.Location = new Point(77, 83);
            FileTypeGroupSavePathTextBox.Name = "FileTypeGroupSavePathTextBox";
            FileTypeGroupSavePathTextBox.Properties.ReadOnly = true;
            FileTypeGroupSavePathTextBox.RightToLeft = RightToLeft.No;
            FileTypeGroupSavePathTextBox.Size = new Size(320, 28);
            FileTypeGroupSavePathTextBox.TabIndex = 26;
            // 
            // mxLabel3
            // 
            mxLabel3.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel3.Appearance.Options.UseFont = true;
            mxLabel3.Location = new Point(16, 89);
            mxLabel3.Name = "mxLabel3";
            mxLabel3.Size = new Size(55, 17);
            mxLabel3.TabIndex = 25;
            mxLabel3.Text = "محل ذخیره : ";
            // 
            // xtraFolderBrowserDialog1
            // 
            xtraFolderBrowserDialog1.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // EditFileTypeGroupDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 319);
            Controls.Add(ChangeSavePathButton);
            Controls.Add(FileTypeGroupSavePathTextBox);
            Controls.Add(mxLabel3);
            Controls.Add(DeleteFileTypeGroupButton);
            Controls.Add(mxDescriptionLabel2);
            Controls.Add(ExtensionsTextbox);
            Controls.Add(mxDescriptionLabel1);
            Controls.Add(groumNameTextbox);
            Controls.Add(mxLabel2);
            Controls.Add(mxLabel1);
            Controls.Add(mxActionGroup1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "EditFileTypeGroupDialogForm";
            Text = "ویرایش کردن گروه فایل";
            Load += EditFileTypeGroupDialogForm_Load;
            ((ISupportInitialize)groumNameTextbox.Properties).EndInit();
            ((ISupportInitialize)ExtensionsTextbox.Properties).EndInit();
            ((ISupportInitialize)FileTypeGroupSavePathTextBox.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Common.MxActionGroup mxActionGroup1;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxLabel mxLabel2;
        private UserControls.Common.MxTextBox groumNameTextbox;
        private UserControls.Common.MxDescriptionLabel mxDescriptionLabel1;
        private UserControls.Common.MxAreaTextBox ExtensionsTextbox;
        private UserControls.Common.MxDescriptionLabel mxDescriptionLabel2;
        private UserControls.Common.MxButton DeleteFileTypeGroupButton;
        private UserControls.Common.MxButton ChangeSavePathButton;
        private UserControls.Common.MxTextBox FileTypeGroupSavePathTextBox;
        private UserControls.Common.MxLabel mxLabel3;
        private XtraFolderBrowserDialog xtraFolderBrowserDialog1;
    }
}