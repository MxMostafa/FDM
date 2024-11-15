namespace Client.UI.UserControls.Common
{
    partial class MxAcceptActionGroup
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MxAcceptActionGroup));
            saveButton = new MxButton();
            mxCancelButton1 = new MxCancelButton();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.ImageOptions.SvgImage = Properties.Resources.CompletedSolid1;
            saveButton.ImageOptions.SvgImageSize = new Size(15, 15);
            saveButton.Location = new Point(89, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 30);
            saveButton.TabIndex = 1;
            saveButton.Text = "تائید";
            // 
            // mxCancelButton1
            // 
            mxCancelButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            mxCancelButton1.DialogResult = DialogResult.Cancel;
            mxCancelButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxCancelButton1.ImageOptions.SvgImage");
            mxCancelButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            mxCancelButton1.Location = new Point(13, 5);
            mxCancelButton1.Name = "mxCancelButton1";
            mxCancelButton1.Size = new Size(70, 30);
            mxCancelButton1.TabIndex = 41;
            mxCancelButton1.Text = "انصراف";
            // 
            // MxAcceptActionGroup
            // 
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mxCancelButton1);
            Controls.Add(saveButton);
            Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            Name = "MxAcceptActionGroup";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(489, 39);
            ResumeLayout(false);
        }

        #endregion
        private MxButton saveButton;
        private MxCancelButton mxCancelButton1;
    }
}
