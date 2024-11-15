

using Client.UI.Properties;

namespace Client.UI.Forms.MasterForms;

public partial class MasterForm : XtraForm
{
    public MasterForm()
    {
        InitializeComponent();
        SetTheme();
    }


    private void SetTheme()
    {
        try
        {
            //if (Properties.Settings.Default.Dark)
            //{
            //    LookAndFeel. = "DevExpress Dark Style";
            //}
            //else
            //{
            //    LookAndFeel.SkinName = "WXI";
            //}
            Refresh();
        }
        catch
        {
        }
    }
}
