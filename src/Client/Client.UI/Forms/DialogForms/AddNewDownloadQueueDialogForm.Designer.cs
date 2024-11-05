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
            SuspendLayout();
            // 
            // mxActionGroup1
            // 
            mxActionGroup1.Dock = DockStyle.Bottom;
            mxActionGroup1.Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            mxActionGroup1.Location = new Point(0, 220);
            mxActionGroup1.Name = "mxActionGroup1";
            mxActionGroup1.Size = new Size(349, 39);
            mxActionGroup1.TabIndex = 0;
            // 
            // mxLabel1
            // 
            mxLabel1.Location = new Point(282, 39);
            mxLabel1.Name = "mxLabel1";
            mxLabel1.Size = new Size(45, 13);
            mxLabel1.TabIndex = 1;
            mxLabel1.Text = "mxLabel1";
            // 
            // AddNewDownloadQueueDialogForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 259);
            Controls.Add(mxLabel1);
            Controls.Add(mxActionGroup1);
            Name = "AddNewDownloadQueueDialogForm";
            Text = "ساخت صف جدید";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Common.MxActionGroup mxActionGroup1;
        private UserControls.Common.MxLabel mxLabel1;
    }
}