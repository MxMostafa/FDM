



namespace Client.UI.Forms.MasterForms;

public partial class MasterForm : XtraForm
{
    public MasterForm()
    {
        InitializeComponent();
    }


    public void ShowPleaseWait()
    {
        splashScreenManager1.ShowWaitForm();
    }
    public void HidePleaseWait()
    {
        if (!splashScreenManager1.IsSplashFormVisible) return;
            splashScreenManager1.CloseWaitForm();
    }
}
