namespace Client.UI.UserControls.Common
{
    partial class MxAcctionGroup_Accept
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new MxButton();
            mxButton1 = new MxButton();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Appearance.BackColor = Color.FromArgb(224, 224, 224);
            saveButton.Appearance.Options.UseBackColor = true;
            saveButton.ImageOptions.SvgImageSize = new Size(15, 15);
            saveButton.Location = new Point(354, 23);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 30);
            saveButton.TabIndex = 5;
            saveButton.Text = "انصراف";
            // 
            // mxButton1
            // 
            mxButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mxButton1.Appearance.BackColor = Color.FromArgb(224, 224, 224);
            mxButton1.Appearance.Options.UseBackColor = true;
            mxButton1.DialogResult = DialogResult.OK;
            mxButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            mxButton1.Location = new Point(258, 23);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(90, 30);
            mxButton1.TabIndex = 4;
            mxButton1.Text = "تایید";
            // 
            // MxAcctionGroup_Accept
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(saveButton);
            Controls.Add(mxButton1);
            Name = "MxAcctionGroup_Accept";
            Size = new Size(462, 65);
            ResumeLayout(false);
        }

        #endregion

        private MxButton saveButton;
        private MxButton mxButton1;
    }
}
