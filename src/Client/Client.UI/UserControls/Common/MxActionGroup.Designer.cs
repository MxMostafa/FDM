namespace Client.UI.UserControls.Common
{
    partial class MxActionGroup
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MxActionGroup));
            mxButton1 = new MxButton();
            mxButton2 = new MxButton();
            SuspendLayout();
            // 
            // mxButton1
            // 
            mxButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            mxButton1.DialogResult = DialogResult.Cancel;
            mxButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxButton1.ImageOptions.SvgImage");
            mxButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            mxButton1.Location = new Point(3, 4);
            mxButton1.Name = "mxButton1";
            mxButton1.Size = new Size(90, 30);
            mxButton1.TabIndex = 0;
            mxButton1.Text = "لغو";
            // 
            // mxButton2
            // 
            mxButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            mxButton2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("mxButton2.ImageOptions.SvgImage");
            mxButton2.ImageOptions.SvgImageSize = new Size(15, 15);
            mxButton2.Location = new Point(99, 4);
            mxButton2.Name = "mxButton2";
            mxButton2.Size = new Size(90, 30);
            mxButton2.TabIndex = 1;
            mxButton2.Text = "ذخیره";
            // 
            // MxActionGroup
            // 
            AutoScaleDimensions = new SizeF(6F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mxButton2);
            Controls.Add(mxButton1);
            Font = new Font("B Yekan", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            Name = "MxActionGroup";
            Size = new Size(489, 39);
            ResumeLayout(false);
        }

        #endregion

        private MxButton mxButton1;
        private MxButton mxButton2;
    }
}
