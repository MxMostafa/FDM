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
            mxComboBoxEdit1 = new UserControls.Common.MxComboBoxEdit();
            mxButton16 = new UserControls.Common.MxButton();
            groupControl1 = new GroupControl();
            panelControl1 = new PanelControl();
            mxTextBox1 = new UserControls.Common.MxTextBox();
            mxLabel3 = new UserControls.Common.MxLabel();
            mxLabel2 = new UserControls.Common.MxLabel();
            mxTextBox2 = new UserControls.Common.MxTextBox();
            UseAuthorizationCheckBox = new UserControls.Common.MxCheckBox();
            mxButton1 = new UserControls.Common.MxButton();
            ((ISupportInitialize)mxComboBoxEdit1.Properties).BeginInit();
            ((ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((ISupportInitialize)mxTextBox1.Properties).BeginInit();
            ((ISupportInitialize)mxTextBox2.Properties).BeginInit();
            ((ISupportInitialize)UseAuthorizationCheckBox.Properties).BeginInit();
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
            mxLabel1.Location = new Point(533, 12);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(26, 17);
            mxLabel1.TabIndex = 2;
            mxLabel1.Text = "آدرس";
            // 
            // mxComboBoxEdit1
            // 
            mxComboBoxEdit1.Location = new Point(95, 6);
            mxComboBoxEdit1.Name = "mxComboBoxEdit1";
            mxComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            mxComboBoxEdit1.Properties.Items.AddRange(new object[] { "https://download.visualstudio.microsoft.com/download/pr/6224f00f-08da-4e7f-85b1-00d42c2bb3d3/b775de636b91e023574a0bbc291f705a/dotnet-sdk-8.0.403-win-x64.exe", "https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.403-windows-x64-installer", "https://dl2.soft98.ir/soft/n/NET.Desktop.Runtime.8.0.10.x64.rar?1730113279" });
            mxComboBoxEdit1.RightToLeft = RightToLeft.No;
            mxComboBoxEdit1.Size = new Size(432, 28);
            mxComboBoxEdit1.TabIndex = 5;
            // 
            // mxButton16
            // 
            mxButton16.Appearance.BackColor = Color.Gainsboro;
            mxButton16.Appearance.Options.UseBackColor = true;
            mxButton16.Location = new Point(11, 8);
            mxButton16.Name = "mxButton16";
            mxButton16.Size = new Size(76, 23);
            mxButton16.TabIndex = 31;
            mxButton16.Text = "تایید";
            // 
            // groupControl1
            // 
            groupControl1.CaptionImageOptions.SvgImage = Properties.Resources.SmallErase;
            groupControl1.Controls.Add(panelControl1);
            groupControl1.Controls.Add(UseAuthorizationCheckBox);
            groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            groupControl1.Location = new Point(95, 38);
            groupControl1.Name = "groupControl1";
            groupControl1.RightToLeft = RightToLeft.No;
            groupControl1.Size = new Size(464, 66);
            groupControl1.TabIndex = 32;
            groupControl1.Text = "Use authorization";
            // 
            // panelControl1
            // 
            panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl1.Controls.Add(mxTextBox1);
            panelControl1.Controls.Add(mxLabel3);
            panelControl1.Controls.Add(mxLabel2);
            panelControl1.Controls.Add(mxTextBox2);
            panelControl1.Enabled = false;
            panelControl1.Location = new Point(32, 27);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new Size(410, 37);
            panelControl1.TabIndex = 9;
            // 
            // mxTextBox1
            // 
            mxTextBox1.Location = new Point(47, 5);
            mxTextBox1.Name = "mxTextBox1";
            mxTextBox1.Size = new Size(121, 28);
            mxTextBox1.TabIndex = 5;
            // 
            // mxLabel3
            // 
            mxLabel3.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel3.Appearance.Options.UseFont = true;
            mxLabel3.Location = new Point(199, 12);
            mxLabel3.Name = "mxLabel3";
            mxLabel3.Size = new Size(48, 17);
            mxLabel3.TabIndex = 4;
            mxLabel3.Text = "Password";
            // 
            // mxLabel2
            // 
            mxLabel2.Appearance.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel2.Appearance.Options.UseFont = true;
            mxLabel2.Location = new Point(11, 12);
            mxLabel2.Name = "mxLabel2";
            mxLabel2.Size = new Size(30, 17);
            mxLabel2.TabIndex = 7;
            mxLabel2.Text = "Login";
            // 
            // mxTextBox2
            // 
            mxTextBox2.Location = new Point(253, 5);
            mxTextBox2.Name = "mxTextBox2";
            mxTextBox2.Size = new Size(121, 28);
            mxTextBox2.TabIndex = 6;
            // 
            // UseAuthorizationCheckBox
            // 
            UseAuthorizationCheckBox.Location = new Point(22, 5);
            UseAuthorizationCheckBox.Name = "UseAuthorizationCheckBox";
            UseAuthorizationCheckBox.Properties.Caption = "";
            UseAuthorizationCheckBox.Size = new Size(75, 22);
            UseAuthorizationCheckBox.TabIndex = 8;
            UseAuthorizationCheckBox.CheckedChanged += UseAuthorizationCheckBox_CheckedChanged;
            // 
            // mxButton1
            // 
            mxButton1.Appearance.BackColor = Color.Gainsboro;
            mxButton1.Appearance.Options.UseBackColor = true;
            mxButton1.Location = new Point(11, 40);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(76, 23);
            mxButton1.TabIndex = 33;
            mxButton1.Text = "انصراف";
            // 
            // AddDownloadNewAddressDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 111);
            Controls.Add(mxButton1);
            Controls.Add(mxButton16);
            Controls.Add(groupControl1);
            Controls.Add(mxComboBoxEdit1);
            Controls.Add(mxLabel1);
            Controls.Add(barDockControlTop);
            Controls.Add(barDockControl1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "AddDownloadNewAddressDialogForm";
            Text = "آدرس جدید برای دانلود وارد کنید";
            ((ISupportInitialize)mxComboBoxEdit1.Properties).EndInit();
            ((ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((ISupportInitialize)mxTextBox1.Properties).EndInit();
            ((ISupportInitialize)mxTextBox2.Properties).EndInit();
            ((ISupportInitialize)UseAuthorizationCheckBox.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxComboBoxEdit mxComboBoxEdit1;
        private UserControls.Common.MxButton mxButton16;
        private GroupControl groupControl1;
        private UserControls.Common.MxButton mxButton1;
        private UserControls.Common.MxLabel mxLabel2;
        private UserControls.Common.MxTextBox mxTextBox2;
        private UserControls.Common.MxTextBox mxTextBox1;
        private UserControls.Common.MxLabel mxLabel3;
        private UserControls.Common.MxCheckBox UseAuthorizationCheckBox;
        private PanelControl panelControl1;
    }
}