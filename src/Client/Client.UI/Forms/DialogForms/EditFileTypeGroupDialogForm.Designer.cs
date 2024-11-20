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
            mxDescriptionLabel2 = new UserControls.Common.MxDescriptionLabel();
            mxAreaTextBox1 = new UserControls.Common.MxAreaTextBox();
            bindingSource1 = new BindingSource(components);
            mxDescriptionLabel1 = new UserControls.Common.MxDescriptionLabel();
            mxTextBox1 = new UserControls.Common.MxTextBox();
            mxLabel2 = new UserControls.Common.MxLabel();
            mxLabel1 = new UserControls.Common.MxLabel();
            mxActionGroup1 = new UserControls.Common.MxActionGroup();
            ((ISupportInitialize)mxAreaTextBox1.Properties).BeginInit();
            ((ISupportInitialize)bindingSource1).BeginInit();
            ((ISupportInitialize)mxTextBox1.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxDescriptionLabel2
            // 
            mxDescriptionLabel2.Appearance.BackColor = Color.Gainsboro;
            mxDescriptionLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxDescriptionLabel2.Appearance.Options.UseBackColor = true;
            mxDescriptionLabel2.Appearance.Options.UseFont = true;
            mxDescriptionLabel2.Appearance.Options.UseTextOptions = true;
            mxDescriptionLabel2.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            mxDescriptionLabel2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            mxDescriptionLabel2.AutoSizeMode = LabelAutoSizeMode.None;
            mxDescriptionLabel2.LineLocation = LineLocation.Top;
            mxDescriptionLabel2.LineOrientation = LabelLineOrientation.Vertical;
            mxDescriptionLabel2.Location = new Point(71, 179);
            mxDescriptionLabel2.Name = "mxDescriptionLabel2";
            mxDescriptionLabel2.Size = new Size(384, 26);
            mxDescriptionLabel2.TabIndex = 13;
            mxDescriptionLabel2.Text = "پسوندها را با فاصله از هم جدا کنید  مثال : mp3 wave";
            // 
            // mxAreaTextBox1
            // 
            mxAreaTextBox1.DataBindings.Add(new Binding("Text", bindingSource1, "FileExtensions", true));
            mxAreaTextBox1.EditValue = "";
            mxAreaTextBox1.Location = new Point(71, 77);
            mxAreaTextBox1.Name = "mxAreaTextBox1";
            mxAreaTextBox1.Size = new Size(384, 96);
            mxAreaTextBox1.TabIndex = 12;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(ViewModel.FileTypeGroup.EditFileTypeGroupViewModel);
            // 
            // mxDescriptionLabel1
            // 
            mxDescriptionLabel1.Appearance.BackColor = Color.Gainsboro;
            mxDescriptionLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxDescriptionLabel1.Appearance.Options.UseBackColor = true;
            mxDescriptionLabel1.Appearance.Options.UseFont = true;
            mxDescriptionLabel1.Appearance.Options.UseTextOptions = true;
            mxDescriptionLabel1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            mxDescriptionLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            mxDescriptionLabel1.AutoSizeMode = LabelAutoSizeMode.None;
            mxDescriptionLabel1.LineLocation = LineLocation.Top;
            mxDescriptionLabel1.LineOrientation = LabelLineOrientation.Vertical;
            mxDescriptionLabel1.Location = new Point(71, 37);
            mxDescriptionLabel1.Name = "mxDescriptionLabel1";
            mxDescriptionLabel1.Size = new Size(384, 26);
            mxDescriptionLabel1.TabIndex = 11;
            mxDescriptionLabel1.Text = "مثال : فایل های صوتی";
            // 
            // mxTextBox1
            // 
            mxTextBox1.DataBindings.Add(new Binding("Text", bindingSource1, "Title", true));
            mxTextBox1.Location = new Point(71, 3);
            mxTextBox1.Name = "mxTextBox1";
            mxTextBox1.Size = new Size(384, 28);
            mxTextBox1.TabIndex = 10;
            mxTextBox1.ToolTipTitle = "مثال : فایل های فشرده";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(18, 84);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(47, 17);
            mxLabel2.TabIndex = 8;
            mxLabel2.Text = "پسوند ها : ";
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Location = new Point(18, 10);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(43, 17);
            mxLabel1.TabIndex = 9;
            mxLabel1.Text = "نام گروه : ";
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxActionGroup1.Location = new Point(0, 311);
            mxActionGroup1.Name = "mxActionGroup1";
            mxActionGroup1.RightToLeft = RightToLeft.Yes;
            mxActionGroup1.Size = new Size(467, 39);
            mxActionGroup1.TabIndex = 14;
            // 
            // EditFileTypeGroupDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 350);
            Controls.Add(mxActionGroup1);
            Controls.Add(mxDescriptionLabel2);
            Controls.Add(mxAreaTextBox1);
            Controls.Add(mxDescriptionLabel1);
            Controls.Add(mxTextBox1);
            Controls.Add(mxLabel2);
            Controls.Add(mxLabel1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "EditFileTypeGroupDialogForm";
            Text = "ویرایش گروه فایل";
            Load += EditFileTypeGroupDialogForm_Load;
            ((ISupportInitialize)mxAreaTextBox1.Properties).EndInit();
            ((ISupportInitialize)bindingSource1).EndInit();
            ((ISupportInitialize)mxTextBox1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Common.MxDescriptionLabel mxDescriptionLabel2;
        private UserControls.Common.MxAreaTextBox mxAreaTextBox1;
        private UserControls.Common.MxDescriptionLabel mxDescriptionLabel1;
        private UserControls.Common.MxTextBox mxTextBox1;
        private UserControls.Common.MxLabel mxLabel2;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxActionGroup mxActionGroup1;
        private BindingSource bindingSource1;
    }
}