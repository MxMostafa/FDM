




using Client.UI.Properties;
using DevExpress.XtraBars;

namespace Client.UI;

public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
{
    private readonly IDownloadQueueService _downloadQueueService;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Main> _logger;
    public Main(IDownloadQueueService downloadQueueService, IServiceProvider serviceProvider, ILogger<Main> logger)
    {
        InitializeComponent();
        _downloadQueueService = downloadQueueService;
        DownloadQueueElement.ContextButtons.First().Click += Main_Click;
        _serviceProvider = serviceProvider;
        _logger = logger;

        System.Windows.Forms.Application.ThreadException += (sender, e) => e.Exception.Handle(_logger);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => (e.ExceptionObject as Exception).Handle(_logger);
    }

    private async void Main_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
    {
        var frm = GetForm<AddNewDownloadQueueDialogForm>();
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
                    Text = menu.Title,
                    Tag = menu
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

    }

    private void SettingMenuButton_Click(object sender, EventArgs e)
    {
        var appSettingDialogForm = _serviceProvider.GetRequiredService<AppSettingDialogForm>();
        appSettingDialogForm.ShowDialog();
    }

    private void settingBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var appSettingDialogForm = _serviceProvider.GetRequiredService<AppSettingDialogForm>();
        appSettingDialogForm.ShowDialog();
    }

    private void dbarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        GetForm<AddDownloadNewAddressDialogForm>().ShowDialog();
    }

    private void downloadGroupBarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        GetForm<AddDownloadGroupDialogForm>().ShowDialog();

    }

    private void aboutProgramButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        GetForm<AboutProgramDialogForm>().ShowDialog();

    }

    private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        GetForm<TestComponentForm>()?.ShowDialog();
    }

    private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        GetForm<AddDownloadNewAddressDialogForm>()?.ShowDialog();
    }

    private void darkLightButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            if (Properties.Settings.Default.Dark)
            {

                Properties.Settings.Default.Dark = false;
                darkLightButton.ImageOptions.SvgImage = Resources.Brightness;
            }
            else
            {
                Properties.Settings.Default.Dark = true;
                darkLightButton.ImageOptions.SvgImage = Resources.QuietHours;

            }

        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
        }
    }

    private void LoginMenuButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        GetForm<LoginFormDialogForm>()?.ShowDialog();
    }

    private TForm GetForm<TForm>() where TForm : Form
    {
        try
        {
            return _serviceProvider.GetRequiredService<TForm>();
        }
        catch (Exception ex)
        {
            ex.Handle(_logger);
            return null;
        }

    }


}
