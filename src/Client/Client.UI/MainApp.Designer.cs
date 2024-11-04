namespace Client.UI
{
    partial class MainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            accordionControl2 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement6 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement7 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement8 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement10 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator4 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement11 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement12 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.CaptionBarItemLinks.Add(skinRibbonGalleryBarItem1);
            ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 39, 30, 39);
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { skinRibbonGalleryBarItem1, ribbon.ExpandCollapseItem, barButtonItem1, barButtonItem2, barLinkContainerItem1 });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ribbon.MaxItemId = 5;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2, ribbonPage3 });
            ribbon.Size = new System.Drawing.Size(1087, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 1;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "آدرس جدید";
            barButtonItem1.Id = 2;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "barButtonItem2";
            barButtonItem2.Id = 3;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barLinkContainerItem1
            // 
            barLinkContainerItem1.Caption = "barLinkContainerItem1";
            barLinkContainerItem1.Id = 4;
            barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup4 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "دانلود";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "تنظیمات";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup3 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "راهنما";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 594);
            ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new System.Drawing.Size(1087, 24);
            // 
            // accordionControl2
            // 
            accordionControl2.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement2, accordionControlSeparator2, accordionControlElement3, accordionControlElement10 });
            accordionControl2.Location = new System.Drawing.Point(0, 158);
            accordionControl2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            accordionControl2.Name = "accordionControl2";
            accordionControl2.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl2.Size = new System.Drawing.Size(260, 436);
            accordionControl2.TabIndex = 5;
            accordionControl2.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement2
            // 
            accordionControlElement2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement2.ImageOptions.SvgImage");
            accordionControlElement2.Name = "accordionControlElement2";
            accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement2.Text = "آدرس";
            // 
            // accordionControlSeparator2
            // 
            accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // accordionControlElement3
            // 
            accordionControlElement3.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlSeparator1, accordionControlElement4, accordionControlElement5, accordionControlElement6, accordionControlElement7, accordionControlElement8 });
            accordionControlElement3.Expanded = true;
            accordionControlElement3.Name = "accordionControlElement3";
            accordionControlElement3.Text = "همه دانلود ها";
            // 
            // accordionControlSeparator1
            // 
            accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // accordionControlElement4
            // 
            accordionControlElement4.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement4.ImageOptions.SvgImage");
            accordionControlElement4.Name = "accordionControlElement4";
            accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement4.Text = "فایل های فشرده";
            // 
            // accordionControlElement5
            // 
            accordionControlElement5.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement5.ImageOptions.SvgImage");
            accordionControlElement5.Name = "accordionControlElement5";
            accordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement5.Text = "اسناد";
            // 
            // accordionControlElement6
            // 
            accordionControlElement6.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement6.ImageOptions.SvgImage");
            accordionControlElement6.Name = "accordionControlElement6";
            accordionControlElement6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement6.Text = "موسیقی";
            // 
            // accordionControlElement7
            // 
            accordionControlElement7.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement7.ImageOptions.SvgImage");
            accordionControlElement7.Name = "accordionControlElement7";
            accordionControlElement7.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement7.Text = "برنامه ها";
            // 
            // accordionControlElement8
            // 
            accordionControlElement8.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElement8.ImageOptions.SvgImage");
            accordionControlElement8.Name = "accordionControlElement8";
            accordionControlElement8.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement8.Text = "تصویری";
            // 
            // accordionControlElement10
            // 
            accordionControlElement10.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlSeparator4, accordionControlElement1, accordionControlElement11, accordionControlElement12 });
            accordionControlElement10.Expanded = true;
            accordionControlElement10.Name = "accordionControlElement10";
            accordionControlElement10.Text = "صف ها";
            // 
            // accordionControlSeparator4
            // 
            accordionControlSeparator4.Name = "accordionControlSeparator4";
            // 
            // accordionControlElement1
            // 
            accordionControlElement1.Name = "accordionControlElement1";
            accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement1.Text = "صف اصلی دانلود";
            // 
            // accordionControlElement11
            // 
            accordionControlElement11.Name = "accordionControlElement11";
            accordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement11.Text = "صف تست";
            // 
            // accordionControlElement12
            // 
            accordionControlElement12.Name = "accordionControlElement12";
            accordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement12.Text = "صف تست 2";
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridControl1.Location = new System.Drawing.Point(260, 158);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbon;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(827, 436);
            gridControl1.TabIndex = 8;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // MainApp
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1087, 618);
            Controls.Add(gridControl1);
            Controls.Add(accordionControl2);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainApp";
            Ribbon = ribbon;
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            StatusBar = ribbonStatusBar;
            Text = "دانلود منیجر فارسی FDM";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement6;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement7;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement8;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement10;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement12;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}