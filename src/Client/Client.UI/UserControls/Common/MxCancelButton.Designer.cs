namespace Client.UI.UserControls.Common
{
    partial class MxCancelButton
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MxCancelButton));
            SuspendLayout();
            // 
            // MxCancelButton
            // 
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DialogResult = DialogResult.Cancel;
            ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MxCancelButton.ImageOptions.SvgImage");
            ImageOptions.SvgImageSize = new Size(15, 15);
            Size = new Size(90, 30);
            Text = "انصراف";
            ResumeLayout(false);
        }

        #endregion
    }
}
