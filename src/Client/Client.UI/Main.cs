using Client.Domain.Enums;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace Client.UI;

public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
{
    private readonly IDownloadQueueService _downloadQueueService;
    private readonly IDownloadFileService _downloadFileService;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Main> _logger;
    private readonly BindingList<DownloadViewModel> _mainDownloadList;
    private readonly SynchronizationContext _uiContext;
    private readonly LanguageService _languageService;
    public Main(IDownloadQueueService downloadQueueService, IServiceProvider serviceProvider, ILogger<Main> logger, IDownloadFileService downloadFileService, LanguageService languageService)
    {
        InitializeComponent();
        _downloadQueueService = downloadQueueService;
        DownloadQueueElement.ContextButtons.First().Click += Main_Click;
        _serviceProvider = serviceProvider;
        _logger = logger;

        System.Windows.Forms.Application.ThreadException += (sender, e) => e.Exception.Handle(_logger);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => (e.ExceptionObject as Exception).Handle(_logger);
        _downloadFileService = downloadFileService;
        _mainDownloadList = new BindingList<DownloadViewModel>();
        _uiContext = SynchronizationContext.Current;
        _languageService = languageService;

        _languageService.SetLanguage("fa");
        gridView1.OptionsBehavior.Editable = false;
        gridView1.OptionsSelection.MultiSelect = true;
    }

    #region Events
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
            await LoadAllDownloadFilesAndUpdateMainGridAsync();
            var task = RunDownladMainTask();

        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }

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

    private void LoginMenuButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        GetForm<LoginFormDialogForm>()?.ShowDialog();
    }
    #endregion


    #region Private Methods
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

    private async void AddNewDownload()
    {
        var frm = GetForm<AddDownloadNewAddressDialogForm>();
        if (frm.ShowDialog() != DialogResult.OK) return;

        await LoadAllDownloadFilesAndUpdateMainGridAsync();
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

    private async Task LoadAllDownloadFilesAndUpdateMainGridAsync()
    {
        var request = await _downloadFileService.GetDownloadFilesAsync(null);
        if (request.IsSucceed == false)
        {
            request.Handle();
            return;
        }

        PreparedDataIntoGridView(request.Data);
        LoadFilteredMainDownloadList(null);
    }


    private void PreparedDataIntoGridView(List<DownloadFileResDto> downloadFileResDtos)
    {
        downloadFileResDtos.ForEach(d => _mainDownloadList.Add(new DownloadViewModel()
        {
            DownloadQueueId = d.DownloadQueue.Id,
            Description = d.Description,
            DownloadQueue = d.DownloadQueue.Title,
            FileName = d.FileName,
            Percent = 0,
            Id = d.Id,
            LatestDownloadDateTime = DateTime.Now,
            Remain = 5,
            Size = d.Size,
            Speed = 100,
            Status = _languageService.GetString(d.DownloadStatus.ToString()),
            DownloadStatus = d.DownloadStatus,
            DownloadedBytes = d.DownloadedBytes
        }));
    }
    private void LoadFilteredMainDownloadList(int? downloadQueueId)
    {
        var filteredList = _mainDownloadList
          .Where(d => downloadQueueId == null || d.DownloadQueueId == downloadQueueId).ToList();

        downloadViewModelBindingSource.DataSource = downloadViewModelBindingSource.DataSource = new BindingList<DownloadViewModel>(filteredList);
    }

    private BindingList<DownloadViewModel> GetSelectedItems()
    {
        var items = new BindingList<DownloadViewModel>();

        foreach (int i in gridView1.GetSelectedRows())
        {
            if (!(gridView1.GetRow(i) is DownloadViewModel selectedItem)) continue;

            items.Add(selectedItem);
        }

        return items;
    }

    #region Always RUN
    private SemaphoreSlim _semaphore = new SemaphoreSlim(100); // حداکثر 100 تسک همزمان
    private Task RunDownladMainTask()
    {
        return Task.Run(async () =>
        {
            while (true)
            {
                try
                {
                    var downloadItems = _mainDownloadList.Where(d => d.DownloadStatus == Domain.Enums.DownloadStatus.WaitingToStart).ToList();
                    if (downloadItems.Count == 0)
                    {
                        await Task.Delay(1000);
                        continue;
                    }
                    foreach (var download in downloadItems)
                    {
                        await _semaphore.WaitAsync();

                        _ = Task.Run(async () =>
                        {
                            try
                            {
                                var i = 0;
                                while (download.DownloadedBytes < download.Size && !download.CancellationTokenSource.Token.IsCancellationRequested)
                                {
                                    try
                                    {
                                        i = i + new Random().Next(1, 100000);
                                        download.DownloadedBytes += i;
                                        var percent = FormatHelper.GetPercent(download.DownloadedBytes, download.Size);
                                        _uiContext.Post(_ => download.Percent = percent, null);
                                        await Task.Delay(new Random().Next(1, 500));
                                    }
                                    catch (OperationCanceledException)
                                    {
                                        PauseDownloadCommand(new BindingList<DownloadViewModel> { download });
                                    }

                                }
                            }
                            finally
                            {
                                _semaphore.Release();
                            }


                        }, download.CancellationTokenSource.Token);
                        ContinueDownloadCommand(new BindingList<DownloadViewModel> { download });
                    }
                }
                catch (Exception ex)
                {

                }

            }
        });
    }
    #endregion


    #endregion

    private void ContinueDownloadUrlButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        var items = GetSelectedItems();
        WaitingContinueDownloadCommand(items);
    }



    #region DownloadActions
    private void WaitingContinueDownloadCommand(BindingList<DownloadViewModel> items)
    {
        foreach (var item in items)
        {
            _uiContext.Post(_ => item.DownloadStatus = Domain.Enums.DownloadStatus.WaitingToStart, null);
            item.CancellationTokenSource = new CancellationTokenSource();
        }

    }
    private void ContinueDownloadCommand(BindingList<DownloadViewModel> items)
    {
        foreach (var item in items)
        {
            _uiContext.Post(_ => item.DownloadStatus = Domain.Enums.DownloadStatus.Started, null);
            _uiContext.Post(_ => item.Status = _languageService.GetString(DownloadStatus.Started.ToString()), null);
        }

    }

    private void PauseDownloadCommand(BindingList<DownloadViewModel> items)
    {
        foreach (var item in items)
        {
            item.CancellationTokenSource.Cancel();
            _uiContext.Post(_ => item.DownloadStatus = Domain.Enums.DownloadStatus.Paused, null);
            _uiContext.Post(_ => item.Status = _languageService.GetString(DownloadStatus.Paused.ToString()), null);
        }
    }
    #endregion

    private void StopAllDownloadButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        PauseDownloadCommand(_mainDownloadList);
    }

    private void ContinueAllDownloadUrlButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        WaitingContinueDownloadCommand(_mainDownloadList);
    }

    private void StopDownloadButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        var items = GetSelectedItems();
        PauseDownloadCommand(items);
    }
}
