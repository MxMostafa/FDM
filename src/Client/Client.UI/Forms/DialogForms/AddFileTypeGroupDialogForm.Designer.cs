namespace Client.UI.Forms.DialogForms
{
    partial class AddFileTypeGroupDialogForm
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
            mxActionGroup1 = new UserControls.Common.MxActionGroup();
            mxLabel1 = new UserControls.Common.MxLabel();
            mxLabel2 = new UserControls.Common.MxLabel();
            groumNameTextbox = new UserControls.Common.MxTextBox();
            mxDescriptionLabel1 = new UserControls.Common.MxDescriptionLabel();
            ExtensionsTextbox = new UserControls.Common.MxAreaTextBox();
            mxDescriptionLabel2 = new UserControls.Common.MxDescriptionLabel();
            ((ISupportInitialize)groumNameTextbox.Properties).BeginInit();
            ((ISupportInitialize)ExtensionsTextbox.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxActionGroup1.Location = new Point(0, 245);
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
            mxLabel1.Location = new Point(11, 24);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(43, 17);
            mxLabel1.TabIndex = 3;
            mxLabel1.Text = "نام گروه : ";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(11, 98);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(47, 17);
            mxLabel2.TabIndex = 3;
            mxLabel2.Text = "پسوند ها : ";
            // 
            // groumNameTextbox
            // 
            groumNameTextbox.Location = new Point(61, 17);
            groumNameTextbox.Name = "groumNameTextbox";
            groumNameTextbox.Size = new Size(384, 28);
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
            mxDescriptionLabel1.Location = new Point(61, 51);
            mxDescriptionLabel1.Name = "mxDescriptionLabel1";
            mxDescriptionLabel1.Size = new Size(384, 26);
            mxDescriptionLabel1.TabIndex = 5;
            mxDescriptionLabel1.Text = "مثال : فایل های صوتی";
            // 
            // ExtensionsTextbox
            // 
            ExtensionsTextbox.EditValue = "";
            ExtensionsTextbox.Location = new Point(61, 91);
            ExtensionsTextbox.Name = "ExtensionsTextbox";
            ExtensionsTextbox.Size = new Size(384, 96);
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
            mxDescriptionLabel2.Location = new Point(61, 193);
            mxDescriptionLabel2.Name = "mxDescriptionLabel2";
            mxDescriptionLabel2.Size = new Size(384, 26);
            mxDescriptionLabel2.TabIndex = 7;
            mxDescriptionLabel2.Text = "پسوندها را با فاصله از هم جدا کنید  مثال : mp3 wave";
            // 
            // AddFileTypeGroupDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 284);
            Controls.Add(mxDescriptionLabel2);
            Controls.Add(ExtensionsTextbox);
            Controls.Add(mxDescriptionLabel1);
            Controls.Add(groumNameTextbox);
            Controls.Add(mxLabel2);
            Controls.Add(mxLabel1);
            Controls.Add(mxActionGroup1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "AddFileTypeGroupDialogForm";
            Text = "اضافه کردن گروه فایل";
            ((ISupportInitialize)groumNameTextbox.Properties).EndInit();
            ((ISupportInitialize)ExtensionsTextbox.Properties).EndInit();
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
    }
}