




using Client.Domain.Dtos.Response.DownloadFile;
using Client.UI.Properties;
using DevExpress.Dialogs.Core.View;
using DevExpress.Mvvm.Native;
using DevExpress.Office.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraSpreadsheet.Model;
using System.Threading;

namespace Client.UI;

public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
{
    private readonly IDownloadQueueService _downloadQueueService;
    private readonly IDownloadFileService _downloadFileService;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Main> _logger;
    private readonly List<DownloadFileResDto> mainDownloadQueue;
    private BindingList<DownloadViewModel> dataList = new BindingList<DownloadViewModel>();
    private SynchronizationContext _uiContext;
    public Main(IDownloadQueueService downloadQueueService, IServiceProvider serviceProvider, ILogger<Main> logger, IDownloadFileService downloadFileService)
    {
        InitializeComponent();
        _downloadQueueService = downloadQueueService;
        DownloadQueueElement.ContextButtons.First().Click += Main_Click;
        _serviceProvider = serviceProvider;
        _logger = logger;

        System.Windows.Forms.Application.ThreadException += (sender, e) => e.Exception.Handle(_logger);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => (e.ExceptionObject as Exception).Handle(_logger);
        _downloadFileService = downloadFileService;
        mainDownloadQueue = new List<DownloadFileResDto>();
        _uiContext = SynchronizationContext.Current;
    }

    private async void Main_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
    {
        var frm = GetForm<AddNewDownloadQueueDialogForm>();
        if (frm.ShowDialog() != DialogResult.OK) return;
        var result = await _downloadQueueService.CreateNewDownloadQueueAsync(frm.DowanloadQueueTitle);
        if (result.IsSucceed)
        {
            await LoadAllQueuesIntoSideMenuAsync();
        }
        else
        {
            MessageBox.Show(result.ErrorMessage);
        }
    }



    private async void Main_Load(object sender, EventArgs e)
    {
        try
        {
            await LoadAllQueuesIntoSideMenuAsync();
            await LoadAllDownloadFilesIntoGridAsync();
            var task = LoadAllDownloadFileIntoQueue();

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }

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
        AddNewDownload();
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
        AddNewDownload();
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


    #region Private Methods
    private async void AddNewDownload()
    {
        var frm = GetForm<AddDownloadNewAddressDialogForm>();
        if (frm.ShowDialog() != DialogResult.OK) return;

        await LoadAllDownloadFilesIntoGridAsync();
    }

    private async Task LoadAllQueuesIntoSideMenuAsync()
    {
        try
        {
            var request = await _downloadQueueService.GetAllDownloadQueuesAsync();

            if (request.IsSucceed == false)
            {
                request.Handle();
                return;
            }


            DownloadQueueElement.Elements.Clear();
            foreach (var menu in request.Data)
            {
                DownloadQueueElement.Elements.Add(new DevExpress.XtraBars.Navigation.AccordionControlElement()
                {
                    Text = menu.Title,
                    Tag = menu
                });
            }

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private async Task LoadAllDownloadFilesIntoGridAsync()
    {
        var request = await _downloadFileService.GetDownloadFilesAsync(null);
        if (request.IsSucceed == false)
        {
            request.Handle();
            return;
        }

        var result = request.Data;
        result.ForEach(d => dataList.Add(new DownloadViewModel()
        {
            Description = d.Description,
            DownloadQueue = d.DownloadQueue.Title,
            FileName = d.FileName,
            Percent = 0,
            Id = d.Id,
            LatestDownloadDateTime = DateTime.Now,
            Remain = 5,
            Size = d.Size,
            Speed = 100,
            Status = d.DownloadStatus.ToString()
        }));

        downloadViewModelBindingSource.DataSource = dataList;
        return;
        downloadViewModelBindingSource.DataSource = result.Select(d => new DownloadViewModel()
        {
            Description = d.Description,
            DownloadQueue = d.DownloadQueue.Title,
            FileName = d.FileName,
            Percent = 0,
            Id = d.Id,
            LatestDownloadDateTime = DateTime.Now,
            Remain = 5,
            Size = d.Size,
            Speed = 100,
            Status = d.DownloadStatus.ToString()
        }).ToList();
    }

    private async Task LoadAllDownloadFileIntoQueue()
    {
        //var request = await _downloadFileService.GetAllStartedDownloadFilesAsync();
       // mainDownloadQueue.AddRange(request.Data);
        //  if (request.Data.Any())
        //  request.Data.ForEach(d => mainDownloadQueue.Enqueue(d, false));

        foreach (var item in dataList)
        {
            var download = item;
            var task = new Task(async () =>
            {
                var i = 0;
                while (i < 1000)
                {
                    i=i+ new Random().Next(1, 10);
                    _uiContext.Post(_ => download.Description = $"{i}%", null);
                  //  download.Description = i.ToString();
                    await Task.Delay(new Random().Next(1, 500));
                }

            });

            task.Start();
        }


    }

    private void UpdateGrid()
    {
       if (!(downloadViewModelBindingSource.List is List<DownloadViewModel> list)) return;
        Task.Run(() =>
        {
            while (true)
            {
                foreach (var item in list)
                {
                    item.Description = dataList.FirstOrDefault(p => p.Id == item.Id)?.Description;

                }
                //if (gridControl1.InvokeRequired)
                //{
                //    gridControl1.Invoke(new Action(() =>
                //    {
                //        gridView1.RefreshData();
                //    }));
                //}

            }
        });


    }
    #endregion
}
