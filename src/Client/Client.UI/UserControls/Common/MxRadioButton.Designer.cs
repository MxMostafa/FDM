namespace Client.UI.UserControls.Common
{
    partial class MxRadioButton
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
            fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((ISupportInitialize)fProperties).BeginInit();
            SuspendLayout();
            // 
            // fProperties
            // 
            fProperties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            fProperties.Name = "fProperties";
            // 
            // MxRadioButton
            // 
            Size = new Size(75, 20);
            ((ISupportInitialize)fProperties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit fProperties;
    }
}
