namespace Client.UI.Forms.DialogForms
{
    partial class TestComponentForm
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
            mxRadioButton1 = new UserControls.Common.MxRadioButton();
            mxRadioButton2 = new UserControls.Common.MxRadioButton();
            mxRadioButton3 = new UserControls.Common.MxRadioButton();
            groupControl1 = new GroupControl();
            ((ISupportInitialize)mxRadioButton1.Properties).BeginInit();
            ((ISupportInitialize)mxRadioButton2.Properties).BeginInit();
            ((ISupportInitialize)mxRadioButton3.Properties).BeginInit();
            ((ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            SuspendLayout();
            // 
            // mxRadioButton1
            // 
            mxRadioButton1.Location = new Point(18, 50);
            mxRadioButton1.Name = "mxRadioButton1";
            mxRadioButton1.Properties.Caption = "mxRadioButton1";
            mxRadioButton1.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            mxRadioButton1.Size = new Size(239, 22);
            mxRadioButton1.TabIndex = 0;
            // 
            // mxRadioButton2
            // 
            mxRadioButton2.Location = new Point(18, 78);
            mxRadioButton2.Name = "mxRadioButton2";
            mxRadioButton2.Properties.Caption = "mxRadioButton1";
            mxRadioButton2.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            mxRadioButton2.Size = new Size(239, 22);
            mxRadioButton2.TabIndex = 0;
            // 
            // mxRadioButton3
            // 
            mxRadioButton3.Location = new Point(18, 106);
            mxRadioButton3.Name = "mxRadioButton3";
            mxRadioButton3.Properties.Caption = "mxRadioButton1";
            mxRadioButton3.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            mxRadioButton3.Size = new Size(239, 22);
            mxRadioButton3.TabIndex = 0;
            // 
            // groupControl1
            // 
            groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            groupControl1.Controls.Add(mxRadioButton1);
            groupControl1.Controls.Add(mxRadioButton3);
            groupControl1.Controls.Add(mxRadioButton2);
            groupControl1.Location = new Point(480, 29);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new Size(293, 327);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "groupControl1";
            // 
            // TestComponentForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 659);
            Controls.Add(groupControl1);
            LookAndFeel.SkinName = "WXI";
            LookAndFeel.UseDefaultLookAndFeel = false;
            Name = "TestComponentForm";
            Text = "TestComponentForm";
            ((ISupportInitialize)mxRadioButton1.Properties).EndInit();
            ((ISupportInitialize)mxRadioButton2.Properties).EndInit();
            ((ISupportInitialize)mxRadioButton3.Properties).EndInit();
            ((ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Common.MxRadioButton mxRadioButton1;
        private UserControls.Common.MxRadioButton mxRadioButton2;
        private UserControls.Common.MxRadioButton mxRadioButton3;
        private GroupControl groupControl1;
    }
}