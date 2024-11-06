namespace Client.UI.UserControls.Common
{
    partial class MxSearch
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
            mxTextBox1 = new MxTextBox();
            mxButton5 = new MxButton();
            ((ISupportInitialize)mxTextBox1.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxTextBox1
            // 
            mxTextBox1.Location = new Point(13, 9);
            mxTextBox1.Name = "mxTextBox1";
            mxTextBox1.Size = new Size(377, 20);
            mxTextBox1.TabIndex = 0;
            // 
            // mxButton5
            // 
            mxButton5.Appearance.BackColor = Color.Gainsboro;
            mxButton5.Appearance.Options.UseBackColor = true;
            mxButton5.Location = new Point(396, 9);
            mxButton5.Name = "mxButton5";
            mxButton5.Size = new Size(84, 23);
            mxButton5.TabIndex = 19;
            mxButton5.Text = "...جستجو";
            // 
            // MxSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mxButton5);
            Controls.Add(mxTextBox1);
            Name = "MxSearch";
            Size = new Size(517, 38);
            ((ISupportInitialize)mxTextBox1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MxTextBox mxTextBox1;
        private MxButton mxButton5;
    }
}
