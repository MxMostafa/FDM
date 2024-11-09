

using Client.Domain.Interfaces.Services;
using Client.UI.Forms.DialogForms;

namespace Client.UI;

public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
{
    private readonly IDownloadQueueService _downloadQueueService;
    public Main(IDownloadQueueService downloadQueueService)
    {
        InitializeComponent();
        _downloadQueueService = downloadQueueService;
        DownloadQueueElement.ContextButtons.First().Click += Main_Click;
    }

    private async void Main_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
    {
        var frm = new AddNewDownloadQueueDialogForm();
        if (frm.ShowDialog() != DialogResult.OK) return;
        var result = await _downloadQueueService.AddDownloadQueueAsync(frm.DowanloadQueueTitle);
        if (result.IsSucceed)
        {
            await LoadAllQueuesIntoSideMenuAsync();
        }
        else
        {
            MessageBox.Show(result.ErrorMessage);
        }
    }

    private async Task LoadAllQueuesIntoSideMenuAsync()
    {
        try
        {
            var downloadQueues = await _downloadQueueService.GetAllDownloadQueuesAsync();
            DownloadQueueElement.Elements.Clear();
            foreach (var menu in downloadQueues)
            {
                DownloadQueueElement.Elements.Add(new DevExpress.XtraBars.Navigation.AccordionControlElement()
                {
                    Text = menu.Title
                });
            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    private async void Main_Load(object sender, EventArgs e)
    {
        await LoadAllQueuesIntoSideMenuAsync();
    }







    private void settingButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            AppSettingDialogForm fr = new AppSettingDialogForm();
            fr.ShowDialog();
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void SettingMenuButton_Click(object sender, EventArgs e)
    {

    }

    private void settingBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new AppSettingDialogForm().ShowDialog();
    }

    private void dbarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new AddDownloadNewAddressDialogForm().ShowDialog();
    }

    private void downloadGroupBarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new AddDownloadGroupDialogForm().ShowDialog();

    }

    private void aboutProgramButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new AboutProgramDialogForm().ShowDialog();

    }

    private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new TestComponentForm().ShowDialog();
    }
}
