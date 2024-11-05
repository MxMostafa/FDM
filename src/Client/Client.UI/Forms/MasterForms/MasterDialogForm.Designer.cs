namespace Client.UI.Forms.MasterForms
{
    partial class MasterDialogForm
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
            // MasterDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 586);
            Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MasterDialogForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MasterDialogForm";
            ResumeLayout(false);
        }

        #endregion
    }
}