namespace Client.UI.Forms.DialogForms
{
    partial class ErrorDialogForm
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
            errorContentLabel = new UserControls.Common.MxLabel();
            mxButton1 = new UserControls.Common.MxButton();
            mxLabel1 = new UserControls.Common.MxLabel();
            SuspendLayout();
            // 
            // errorContentLabel
            // 
            errorContentLabel.Appearance.Font = new Font("B Yekan", 12F, FontStyle.Regular, GraphicsUnit.Point, 178);
            errorContentLabel.Appearance.Options.UseFont = true;
            errorContentLabel.Appearance.Options.UseTextOptions = true;
            errorContentLabel.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            errorContentLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            errorContentLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            errorContentLabel.AutoSizeMode = LabelAutoSizeMode.None;
            errorContentLabel.Location = new Point(43, 12);
            errorContentLabel.Name = "errorContentLabel";
            errorContentLabel.Size = new Size(433, 169);
            errorContentLabel.TabIndex = 0;
            errorContentLabel.Text = "mxLabel1";
            // 
            // mxButton1
            // 
            mxButton1.DialogResult = DialogResult.Cancel;
            mxButton1.ImageOptions.SvgImage = Properties.Resources.thankyounote;
            mxButton1.Location = new Point(482, 145);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(117, 36);
            mxButton1.TabIndex = 1;
            mxButton1.Text = "متوجه شدم";
            // 
            // mxLabel1
            // 
            mxLabel1.Appearance.Font = new Font("B Yekan", 12F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxLabel1.Appearance.ForeColor = Color.Red;
            mxLabel1.Appearance.Options.UseFont = true;
            mxLabel1.Appearance.Options.UseForeColor = true;
            mxLabel1.Appearance.Options.UseTextOptions = true;
            mxLabel1.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            mxLabel1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            mxLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            mxLabel1.AutoSizeMode = LabelAutoSizeMode.None;
            mxLabel1.ImageOptions.SvgImage = Properties.Resources.StatusErrorFull1;
            mxLabel1.ImageOptions.SvgImageSize = new Size(50, 50);
            mxLabel1.Location = new Point(482, 12);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(117, 127);
            mxLabel1.TabIndex = 2;
            // 
            // ErrorDialogForm
            // 
            AccessibleRole = AccessibleRole.Alert;
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = mxButton1;
            ClientSize = new Size(611, 193);
            Controls.Add(mxLabel1);
            Controls.Add(mxButton1);
            Controls.Add(errorContentLabel);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "ErrorDialogForm";
            Text = "خطا";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Common.MxLabel errorContentLabel;
        private UserControls.Common.MxButton mxButton1;
        private UserControls.Common.MxLabel mxLabel1;
    }
}