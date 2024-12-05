﻿using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

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
        downloadViewModelBindingSource.DataSource = _mainDownloadList
            .Where(d => downloadQueueId == null || d.DownloadQueueId == downloadQueueId).ToList();
    }


    private Task RunDownladMainTask()
    {
        return Task.Run(async () =>
           {
               while (true)
               {
                   var downloadItems = _mainDownloadList.Where(d => d.DownloadStatus == Domain.Enums.DownloadStatus.Started).ToList();
                   if (downloadItems.Count == 0)
                   {
                       await Task.Delay(1000);
                       continue;
                   }
                   foreach (var item in downloadItems)
                   {
                       var download = item;
                       var task = new Task(async () =>
                       {
                           var i = 0;
                           while (i < 1000)
                           {
                               i = i + new Random().Next(1, 10);
                               _uiContext.Post(_ => download.Description = $"{i}%", null);
                               //  download.Description = i.ToString();
                               await Task.Delay(new Random().Next(1, 500));
                           }

                       });

                       task.Start();
                   }
               }
           });







    }

    #endregion

    private void ContinueDownloadUrlButton_ItemClick(object sender, ItemClickEventArgs e)
    {
        foreach (int i in gridView1.GetSelectedRows())
        {
            if (!(gridView1.GetRow(i) is DownloadViewModel selectedItem)) continue;

            ContinueDownloadCommand(selectedItem);



        }
    }



    #region DownloadActions

    private void ContinueDownloadCommand(DownloadViewModel item)
    {
        _uiContext.Post(_ => item.DownloadStatus =Domain.Enums.DownloadStatus.Started, null);
    }
    #endregion
}
