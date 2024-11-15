namespace Client.UI.Forms.DialogForms
{
    partial class AddDownloadNewAddressDialogForm
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
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            mxLabel1 = new UserControls.Common.MxLabel();
            urlCombobox = new UserControls.Common.MxComboBoxEdit();
            mxButton15 = new UserControls.Common.MxButton();
            mxAcceptActionGroup1 = new UserControls.Common.MxAcceptActionGroup();
            ((ISupportInitialize)urlCombobox.Properties).BeginInit();
            SuspendLayout();
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = null;
            barDockControlTop.Size = new Size(582, 0);
            // 
            // barDockControl1
            // 
            barDockControl1.CausesValidation = false;
            barDockControl1.Dock = DockStyle.Top;
            barDockControl1.Location = new Point(0, 0);
            barDockControl1.Manager = null;
            barDockControl1.Size = new Size(582, 0);
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Location = new Point(12, 48);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(35, 17);
            mxLabel1.TabIndex = 2;
            mxLabel1.Text = "آدرس : ";
            // 
            // urlCombobox
            // 
            urlCombobox.Location = new Point(50, 42);
            urlCombobox.Name = "urlCombobox";
            urlCombobox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            urlCombobox.RightToLeft = RightToLeft.Yes;
            urlCombobox.Size = new Size(520, 28);
            urlCombobox.TabIndex = 5;
            // 
            // mxButton15
            // 
            mxButton15.Appearance.BackColor = Color.Gainsboro;
            mxButton15.Appearance.Options.UseBackColor = true;
            mxButton15.Location = new Point(50, 76);
            mxButton15.Name = "mxButton15";
            mxButton15.Size = new Size(82, 23);
            mxButton15.TabIndex = 49;
            mxButton15.Text = "از کلیپ بورد";
            mxButton15.Click += mxButton15_Click;
            // 
            // mxAcceptActionGroup1
            // 
            mxAcceptActionGroup1.Dock = DockStyle.Bottom;
            mxAcceptActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxAcceptActionGroup1.Location = new Point(0, 106);
            mxAcceptActionGroup1.Name = "mxAcceptActionGroup1";
            mxAcceptActionGroup1.RightToLeft = RightToLeft.Yes;
            mxAcceptActionGroup1.Size = new Size(582, 39);
            mxAcceptActionGroup1.TabIndex = 52;
            mxAcceptActionGroup1.ConfirmButtonClick += mxAcceptActionGroup1_ConfirmButtonClick;
            // 
            // AddDownloadNewAddressDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 145);
            Controls.Add(mxAcceptActionGroup1);
            Controls.Add(mxButton15);
            Controls.Add(urlCombobox);
            Controls.Add(mxLabel1);
            Controls.Add(barDockControlTop);
            Controls.Add(barDockControl1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "AddDownloadNewAddressDialogForm";
            Text = "آدرس جدیدی برای دانلود وارد کنید";
            Load += AddDownloadNewAddressDialogForm_Load;
            ((ISupportInitialize)urlCombobox.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxComboBoxEdit urlCombobox;
        private UserControls.Common.MxButton mxButton15;
        private UserControls.Common.MxAcceptActionGroup mxAcceptActionGroup1;
    }
}