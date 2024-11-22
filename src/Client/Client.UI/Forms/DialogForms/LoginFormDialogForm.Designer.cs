namespace Client.UI.Forms.DialogForms
{
    partial class LoginFormDialogForm
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
            mxButton1 = new UserControls.Common.MxButton();
            mxTextBox1 = new UserControls.Common.MxTextBox();
            mxLabel1 = new UserControls.Common.MxLabel();
            NextButton = new UserControls.Common.MxButton();
            navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            mxButton3 = new UserControls.Common.MxButton();
            mxLabel2 = new UserControls.Common.MxLabel();
            mxTextBox2 = new UserControls.Common.MxTextBox();
            ((ISupportInitialize)mxTextBox1.Properties).BeginInit();
            ((ISupportInitialize)navigationFrame1).BeginInit();
            navigationFrame1.SuspendLayout();
            navigationPage1.SuspendLayout();
            navigationPage2.SuspendLayout();
            ((ISupportInitialize)mxTextBox2.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxButton1
            // 
            mxButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mxButton1.ImageOptions.Image = Properties.Resources.google_50px;
            mxButton1.ImageOptions.ImageToTextAlignment = ImageAlignToText.RightCenter;
            mxButton1.Location = new Point(138, 330);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(78, 65);
            mxButton1.TabIndex = 0;
            mxButton1.ToolTip = "ورود از طریق گوگل";
            // 
            // mxTextBox1
            // 
            mxTextBox1.EditValue = "";
            mxTextBox1.Location = new Point(31, 43);
            mxTextBox1.Name = "mxTextBox1";
            mxTextBox1.Properties.Appearance.Font = new Font("Tahoma", 20F);
            mxTextBox1.Properties.Appearance.Options.UseFont = true;
            mxTextBox1.Properties.Appearance.Options.UseTextOptions = true;
            mxTextBox1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            mxTextBox1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            mxTextBox1.Properties.CharacterCasing = CharacterCasing.Lower;
            mxTextBox1.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            mxTextBox1.Size = new Size(282, 48);
            mxTextBox1.TabIndex = 1;
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Location = new Point(145, 15);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(180, 17);
            mxLabel1.TabIndex = 2;
            mxLabel1.Text = "برای ادامه شماره موبایل خود را وارد نمائید";
            // 
            // NextButton
            // 
            NextButton.Appearance.BackColor = Color.White;
            NextButton.Appearance.Options.UseBackColor = true;
            NextButton.Appearance.Options.UseTextOptions = true;
            NextButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            NextButton.ImageOptions.ImageToTextAlignment = ImageAlignToText.RightCenter;
            NextButton.ImageOptions.SvgImage = Properties.Resources.Back1;
            NextButton.ImageOptions.SvgImageSize = new Size(18, 18);
            NextButton.Location = new Point(81, 99);
            NextButton.Name = "NextButton";
            NextButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            NextButton.Size = new Size(158, 48);
            NextButton.TabIndex = 3;
            NextButton.Text = "ادامه";
            NextButton.Click += NextButton_Click;
            // 
            // navigationFrame1
            // 
            navigationFrame1.Controls.Add(navigationPage1);
            navigationFrame1.Controls.Add(navigationPage2);
            navigationFrame1.Location = new Point(12, 63);
            navigationFrame1.Name = "navigationFrame1";
            navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { navigationPage1, navigationPage2 });
            navigationFrame1.SelectedPage = navigationPage1;
            navigationFrame1.Size = new Size(339, 162);
            navigationFrame1.TabIndex = 4;
            navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            navigationPage1.Controls.Add(NextButton);
            navigationPage1.Controls.Add(mxTextBox1);
            navigationPage1.Controls.Add(mxLabel1);
            navigationPage1.Name = "navigationPage1";
            navigationPage1.Size = new Size(339, 162);
            // 
            // navigationPage2
            // 
            navigationPage2.Controls.Add(mxTextBox2);
            navigationPage2.Controls.Add(mxButton3);
            navigationPage2.Controls.Add(mxLabel2);
            navigationPage2.Name = "navigationPage2";
            navigationPage2.Size = new Size(339, 162);
            // 
            // mxButton3
            // 
            mxButton3.Appearance.BackColor = Color.White;
            mxButton3.Appearance.Options.UseBackColor = true;
            mxButton3.Appearance.Options.UseTextOptions = true;
            mxButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            mxButton3.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            mxButton3.ImageOptions.SvgImage = Properties.Resources.CheckMark;
            mxButton3.ImageOptions.SvgImageSize = new Size(18, 18);
            mxButton3.Location = new Point(90, 96);
            mxButton3.Name = "mxButton3";
            mxButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            mxButton3.Size = new Size(158, 48);
            mxButton3.TabIndex = 6;
            mxButton3.Text = "ورود";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(139, 17);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(191, 17);
            mxLabel2.TabIndex = 5;
            mxLabel2.Text = "کد ارسال شده به شماره موبایل را وارد نمائید";
            // 
            // mxTextBox2
            // 
            mxTextBox2.EditValue = "";
            mxTextBox2.Location = new Point(90, 42);
            mxTextBox2.Name = "mxTextBox2";
            mxTextBox2.Properties.Appearance.Font = new Font("Tahoma", 20F);
            mxTextBox2.Properties.Appearance.Options.UseFont = true;
            mxTextBox2.Properties.Appearance.Options.UseTextOptions = true;
            mxTextBox2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            mxTextBox2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            mxTextBox2.Properties.CharacterCasing = CharacterCasing.Lower;
            mxTextBox2.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            mxTextBox2.Size = new Size(158, 48);
            mxTextBox2.TabIndex = 7;
            // 
            // LoginFormDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 421);
            Controls.Add(navigationFrame1);
            Controls.Add(mxButton1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "LoginFormDialogForm";
            Text = "ورود به حساب کاربری";
            ((ISupportInitialize)mxTextBox1.Properties).EndInit();
            ((ISupportInitialize)navigationFrame1).EndInit();
            navigationFrame1.ResumeLayout(false);
            navigationPage1.ResumeLayout(false);
            navigationPage1.PerformLayout();
            navigationPage2.ResumeLayout(false);
            navigationPage2.PerformLayout();
            ((ISupportInitialize)mxTextBox2.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Common.MxButton mxButton1;
        private UserControls.Common.MxTextBox mxTextBox1;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxButton NextButton;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private UserControls.Common.MxButton mxButton3;
        private UserControls.Common.MxLabel mxLabel2;
        private UserControls.Common.MxTextBox mxTextBox2;
    }
}