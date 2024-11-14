namespace Client.UI.Forms.MasterForms
{
    partial class MasterSizableDialogform
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
            SuspendLayout();
            // 
            // MasterSizableDialogform
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 510);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Margin = new Padding(3, 5, 3, 5);
            Name = "MasterSizableDialogform";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MasterSizableDialogform";
            ResumeLayout(false);
        }

        #endregion
    }
}