namespace Client.UI.Forms.DialogForms
{
    partial class AppSettingDialogForm
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
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            mxActionGroup1 = new UserControls.Common.MxActionGroup();
            ((ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 0);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(544, 551);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(mxActionGroup1);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(542, 526);
            xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(542, 526);
            xtraTabPage2.Text = "xtraTabPage2";
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Location = new Point(0, 487);
            mxActionGroup1.Name = "mxActionGroup1";
            mxActionGroup1.Size = new Size(542, 39);
            mxActionGroup1.TabIndex = 0;
            // 
            // AppSettingDialogForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 551);
            Controls.Add(xtraTabControl1);
            Name = "AppSettingDialogForm";
            Text = "تنظیمات";
            ((ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private UserControls.Common.MxActionGroup mxActionGroup1;
    }
}