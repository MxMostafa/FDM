namespace Client.UI.Forms.DialogForms
{
    partial class AddNewDownloadQueueDialogForm
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
            mxActionGroup1 = new UserControls.Common.MxActionGroup();
            mxLabel1 = new UserControls.Common.MxLabel();
            mxTextBox1 = new UserControls.Common.MxTextBox();
            ((ISupportInitialize)mxTextBox1.Properties).BeginInit();
            SuspendLayout();
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxActionGroup1.Location = new Point(0, 55);
            mxActionGroup1.Margin = new Padding(3, 4, 3, 4);
            mxActionGroup1.Name = "mxActionGroup1";
            mxActionGroup1.Size = new Size(349, 56);
            mxActionGroup1.TabIndex = 0;
            mxActionGroup1.SaveButtonClick += mxActionGroup1_SaveButtonClick;
            // 
            // mxLabel1
            // 
            mxLabel1.Location = new Point(12, 28);
            mxLabel1.Margin = new Padding(3, 4, 3, 4);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(58, 13);
            mxLabel1.TabIndex = 1;
            mxLabel1.Text = "عنوان صف : ";
            // 
            // mxTextBox1
            // 
            mxTextBox1.Location = new Point(76, 25);
            mxTextBox1.Name = "mxTextBox1";
            mxTextBox1.Size = new Size(261, 20);
            mxTextBox1.TabIndex = 2;
            // 
            // AddNewDownloadQueueDialogForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 111);
            Controls.Add(mxTextBox1);
            Controls.Add(mxLabel1);
            Controls.Add(mxActionGroup1);
            Margin = new Padding(3, 7, 3, 7);
            Name = "AddNewDownloadQueueDialogForm";
            Text = "ساخت صف جدید";
            ((ISupportInitialize)mxTextBox1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Common.MxActionGroup mxActionGroup1;
        private UserControls.Common.MxLabel mxLabel1;
        private UserControls.Common.MxTextBox mxTextBox1;
    }
}