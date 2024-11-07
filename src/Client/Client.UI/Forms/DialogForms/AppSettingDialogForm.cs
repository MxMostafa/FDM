

using Client.UI.ViewModel;

namespace Client.UI.Forms.DialogForms;

public partial class AppSettingDialogForm : MasterFixedDialogForm
{
    public AppSettingDialogForm()
    {
        InitializeComponent();
        richTextBox1.Text = "3GP 7Z AAC ACE AIF APK ARJ ASF AVI BIN BZ2 EXE GZ GZIP IMG ISO LZH M4A M4V MKV MOV MP3 MP4 MPA MPE MPEG MPG MSI MSU OGG OGV PDF PLJ PPS PPT QT R0* R1* RA RAR RM RMVB SEA SIT SITX TAR TIF TIFF WAV WMA WMV Z ZIP";
        richTextBox2.Text = "*.update.microsoft.com download.windowsupdate.com *.download.windowsupdate.com siteseal.thawte.com ecom.cimetz.com *.voice2page.com";
    }

    private void panelControl1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void mxLabel25_Click(object sender, EventArgs e)
    {

    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton3.Checked)
            panelControl8.Enabled = true;
        else
            panelControl8.Enabled = false;
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton4.Checked)
        {
            panelControl9.Enabled = true;
            groupControl4.Visible = true;

        }

        else
        {
            panelControl9.Enabled = false;
            groupControl4.Visible = false;
        }

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
}
