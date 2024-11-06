namespace Client.UI.UserControls.Common
{
    partial class MxActionGroup_Help
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
            saveButton.ImageOptions.SvgImageSize = new Size(15, 15);
            saveButton.Location = new Point(439, 6);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 30);
            saveButton.TabIndex = 3;
            saveButton.Text = "کمک";
            // 
            // mxButton1
            // 
            mxButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mxButton1.DialogResult = DialogResult.OK;
            mxButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            mxButton1.Location = new Point(343, 6);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(90, 30);
            mxButton1.TabIndex = 2;
            mxButton1.Text = "باشه";
            // 
            // MxActionGroup_Help
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(saveButton);
            Controls.Add(mxButton1);
            Name = "MxActionGroup_Help";
            Size = new Size(545, 46);
            ResumeLayout(false);
        }

        #endregion

        private MxButton saveButton;
        private MxButton mxButton1;
    }
}
