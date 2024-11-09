

using Client.UI.ViewModel;

namespace Client.UI.Forms.DialogForms;

public partial class AppSettingDialogForm : MasterFixedDialogForm
{
    public AppSettingDialogForm()
    {
        InitializeComponent();
        xtraTabControl1.SelectedTabPageIndex = 0;
    }




    private void AppSettingDialogForm_Load(object sender, EventArgs e)
    {
        siteInfoViewModelBindingSource.DataSource = new List<SiteInfoViewModel>()
        {
            new SiteInfoViewModel() {Address="http:\\test.com",User="سبس",pass="1234" }
        };
    }

    private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "pass")
        {
            e.DisplayText = new string('*', e.Value?.ToString().Length ?? 0);
        }
    }

    private void ManulaProxySettingRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ProxySettingPanel.Enabled = ManulaProxySettingRadioButton.Checked;
    }
}
