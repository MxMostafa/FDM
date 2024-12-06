using Client.Domain.Enums;
using Client.Infrastructure.Helpers;
using System.IO;
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

        try
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
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    #region Events
    private async void Main_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
    {
        try
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
        catch (Exception ex)
        {

            ex.Handle(_logger);
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
        try
        {
            var appSettingDialogForm = _serviceProvider.GetRequiredService<AppSettingDialogForm>();
            appSettingDialogForm.ShowDialog();
            InitializeComponent();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void settingBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var appSettingDialogForm = _serviceProvider.GetRequiredService<AppSettingDialogForm>();
        appSettingDialogForm.ShowDialog();
    }

    private void dbarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            AddNewDownload();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void downloadGroupBarButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            GetForm<AddDownloadGroupDialogForm>().ShowDialog();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void aboutProgramButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            GetForm<AboutProgramDialogForm>().ShowDialog();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            GetForm<TestComponentForm>()?.ShowDialog();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            AddNewDownload();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void LoginMenuButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            GetForm<LoginFormDialogForm>()?.ShowDialog();
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
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
            FileIcon = FileIconHelper.GetIconByExtension(d.FileName),
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

                                    i = i + new Random().Next(1, 100000);
                                    download.DownloadedBytes += i;
                                    var percent = FormatHelper.GetPercent(download.DownloadedBytes, download.Size);
                                    _uiContext.Post(_ => download.Percent = percent, null);
                                    await Task.Delay(new Random().Next(1, 500));


                                }
                            }
                            finally
                            {

                                _semaphore.Release();
                                if (download.DownloadedBytes >= download.Size)
                                {
                                    await FinishedDownloadCommand(download.Id);
                                }
                            }


                        }, download.CancellationTokenSource.Token);
                        ContinueDownloadCommand(download.Id);
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
        try
        {
            var items = GetSelectedItems();
            items.ForEach(d => WaitingContinueDownloadCommand(d.Id));
            StopDownloadButton.Enabled = true;
            ContinueDownloadUrlButton.Enabled = false;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }



    #region DownloadActions
    private void WaitingContinueDownloadCommand(long? id)
    {
        ChangeStatus(id, DownloadStatus.WaitingToStart);
    }
    private void ContinueDownloadCommand(long? id)
    {
        ChangeStatus(id, DownloadStatus.Started);
    }
    private async Task PauseDownloadCommand(long? id)
    {
        ChangeStatus(id, DownloadStatus.Paused);
        if (id == null)
            await _downloadFileService.UpdateDownloadFileStatusAsync(_mainDownloadList.Select(d => d.Id).ToList(), DownloadStatus.Paused);
        else
            await _downloadFileService.UpdateDownloadFileStatusAsync(id.Value, DownloadStatus.Paused);
    }
    private async Task FinishedDownloadCommand(long? id)
    {
        ChangeStatus(id, DownloadStatus.Finished);
        if (id == null)
            await _downloadFileService.UpdateDownloadFileStatusAsync(_mainDownloadList.Select(d => d.Id).ToList(), DownloadStatus.Finished);
        else
            await _downloadFileService.UpdateDownloadFileStatusAsync(id.Value, DownloadStatus.Finished);
    }
    private void UpdateTopButButtonsStatus(DownloadViewModel selectedItem)
    {
        try
        {
            ContinueDownloadUrlButton.Enabled = selectedItem.DownloadStatus != DownloadStatus.Started;
            StopDownloadButton.Enabled = selectedItem.DownloadStatus == DownloadStatus.Started || selectedItem.DownloadStatus == DownloadStatus.Paused || selectedItem.DownloadStatus == DownloadStatus.WaitingToStart;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void ChangeStatus(long? id, DownloadStatus downloadStatus)
    {
        try
        {
            if (id == null) //change all
            {
                _mainDownloadList.ForEach(item => _uiContext.Post(_ =>
                {
                    item.DownloadStatus = downloadStatus;
                    item.Status = _languageService.GetString(downloadStatus.ToString());
                    if (downloadStatus == DownloadStatus.Paused)
                        item.CancellationTokenSource.Cancel();
                    else
                        item.CancellationTokenSource = new CancellationTokenSource();
                }, null));
            }
            else
            {
                var item = _mainDownloadList.FirstOrDefault(d => d.Id == id);
                if (item != null)
                {
                    _uiContext.Post(_ =>
                    {
                        item.DownloadStatus = downloadStatus;
                        item.Status = _languageService.GetString(downloadStatus.ToString());
                        if (downloadStatus == DownloadStatus.Paused)
                            item.CancellationTokenSource.Cancel();
                        else
                            item.CancellationTokenSource = new CancellationTokenSource();
                    }, null);
                }
            }
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
    #endregion

    private async void StopAllDownloadButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            await PauseDownloadCommand(null);
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void ContinueAllDownloadUrlButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            WaitingContinueDownloadCommand(null);
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }

    private void StopDownloadButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            var items = GetSelectedItems();
            items.ForEach(async d => await PauseDownloadCommand(d.Id));
            StopDownloadButton.Enabled = false;
            ContinueDownloadUrlButton.Enabled = true;
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }


    }

    private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
        try
        {
            var items = GetSelectedItems();
            if (items.Count == 1)
            {
                UpdateTopButButtonsStatus(items[0]);
            }
            else
            {
                StopDownloadButton.Enabled = true;
                ContinueDownloadUrlButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {

            ex.Handle(_logger);
        }
    }
}
