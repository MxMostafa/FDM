


using Client.Domain.Helpers;

namespace Client.Application.Services;

public class DownloadManagement : IDownloadManagment
{

    #region Ctor
    private SemaphoreSlim? _semaphore;
    private readonly IAppSettingService _appSettingService;
    private readonly ILogger<DownloadManagement> _logger;
    private readonly IDownloadFileService _downloadFileService;
    private readonly IDownloadFileChunkService _downloadFileChunkService;
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public DownloadManagement(IAppSettingService appSettingService,
        ILogger<DownloadManagement> logger, IDownloadFileService downloadFileService, IEventManager eventManager, IEventAggregator eventAggregator, IDownloadFileChunkService downloadFileChunkService = null, IServiceScopeFactory serviceScopeFactory = null, IServiceProvider serviceProvider = null)
    {
        _appSettingService = appSettingService;
        _logger = logger;
        _downloadFileService = downloadFileService;
        _eventManager = eventManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.Subscribe<AddFileToQueueEvent>(AddFileToQueueAction);
        _eventAggregator.Subscribe<DownloadFileStatusEvent>(UpdateDownloadFileStatus);
        _eventAggregator.Subscribe<DownloadFileChunkStatusEvent>(UpdateDownloadFileChunkStatus);
        _downloadFileChunkService = downloadFileChunkService;
        _serviceScopeFactory = serviceScopeFactory;
        _serviceProvider = serviceProvider;

    }
    #endregion

    private readonly List<ActiveDownloadItemModel> _activeDownloads = new();

    public async Task InitialAsync()
    {

        if (_semaphore == null)
        {
            var initialCountResult = await _appSettingService.GetAppSettingByKeyAsync<int>(AppSettingConfigs.ParallelDownloadLimit, 30);
            _semaphore = new SemaphoreSlim(initialCountResult.Data); // حداکثر 100 تسک همزمان
        }

        await AddOrUpdateAllWaitingToStartDownloadFilesAsync();
    }


    private async Task AddOrUpdateAllWaitingToStartDownloadFilesAsync()
    {
        var downloadItems = await _downloadFileService.GetAllWaitingToStartDownloadFilesAsync();
        if (!downloadItems.IsSucceed)
        {
            _logger.LogInformation(downloadItems.ErrorMessage);
            return;
        }


        if (downloadItems.Data!.Any())
        {
            foreach (var d in downloadItems.Data!)
            {
                var activeDownload = _activeDownloads.FirstOrDefault(x => x.Id == d.Id);

                if (activeDownload == null)
                {
                    _activeDownloads.Add(new ActiveDownloadItemModel()
                    {
                        DownloadQueue = d.DownloadQueue,
                        FileName = d.FileName,
                        CancellationTokenSource = new CancellationTokenSource(),
                        DownloadedBytes = d.DownloadedBytes,
                        DownloadStatus = d.DownloadStatus,
                        Id = d.Id,
                        Size = d.Size
                    });
                }
                else
                {
                    activeDownload.DownloadQueue = d.DownloadQueue;
                    activeDownload.FileName = d.FileName;
                    activeDownload.CancellationTokenSource = new CancellationTokenSource();
                    activeDownload.DownloadedBytes = d.DownloadedBytes;
                    activeDownload.DownloadStatus = d.DownloadStatus;
                    activeDownload.Id = d.Id;
                    activeDownload.Size = d.Size;
                }
            }


        }
    }


    private async Task ProcessDownloadAsync()
    {
        try
        {
            var readyforDownloads = _activeDownloads.Where(a => a.TaskId == null && a.DownloadStatus == DownloadStatus.WaitingToStart).ToList();

            if (readyforDownloads.Count == 0) return;
            foreach (var download in readyforDownloads)
            {

                var chunksRequest = await _downloadFileChunkService.CheckAndCreateChunkFilesAsync(download.Id);

                if (!chunksRequest.IsSucceed)
                {
                    //TODO:
                    continue;
                }

                var chunks = chunksRequest.Data;

                await _semaphore!.WaitAsync();


                await _downloadFileService.UpdateDownloadFileStatusAsync(download.Id, DownloadStatus.Started);


                _ = Task.Run(async () =>
                {
                    try
                    {

                        if (download.TaskId == null)
                        {
                            download.TaskId = Task.CurrentId;
                        }

                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var downloadFileChunkService = scope.ServiceProvider.GetRequiredService<IDownloadFileChunkService>();
                            await downloadFileChunkService.StartDownloadAsync(chunks!);
                        }


                        //  await _downloadFileChunkService.StartDownloadAsync(chunks!);


                    }
                    finally
                    {
                        _semaphore.Release();
                    }


                }, download.CancellationTokenSource.Token);
            }
        }
        catch (Exception ex)
        {

        }
    }


    #region Events



    private async void UpdateDownloadedBytes(DownloadFileChunkStatusEvent download)
    {
        try
        {
            _eventAggregator.Publish(new DownloadFileDownloadedBytesEvent(download.DownloadFileId, download.ChunkSize));
            return;
            var complatedFilesRequest = await _downloadFileChunkService.GetComplatedChunkFilesAsync(download.DownloadFileId);
            if (complatedFilesRequest.IsSucceed)
            {
                var downloadedBytes = complatedFilesRequest.Data!.Sum(d => d.Size);
                await _downloadFileService.UpdateDownloadFileAsync(new UpdateDownloadFileReqDto(download.DownloadFileId, downloadedBytes));
                _eventAggregator.Publish(new DownloadFileDownloadedBytesEvent(download.DownloadFileId, download.ChunkSize));
            }
        }
        catch (Exception ex)
        {

        }
       

    }

    public async void UpdateDownloadFileStatus(DownloadFileStatusEvent download)
    {
        var find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        if (find == null)
        {
            await AddOrUpdateAllWaitingToStartDownloadFilesAsync();
            find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        }
        if (find == null) return;
        find.DownloadStatus = download.DownloadStatus;
        switch (download.DownloadStatus)
        {
            case DownloadStatus.NotStarted:
                break;
            case DownloadStatus.WaitingToStart:
                if (find.CancellationTokenSource.IsCancellationRequested)
                    find.CancellationTokenSource = new CancellationTokenSource();
                _eventManager.Publish(() => _ = ProcessDownloadAsync());
                break;
            case DownloadStatus.Started:
                break;
            case DownloadStatus.Paused:
                find.CancellationTokenSource.Cancel();
                break;
            case DownloadStatus.Finished:
                break;
            case DownloadStatus.Error:
                break;
            case DownloadStatus.Cancelling:
                break;
            case DownloadStatus.Cancelled:
                break;
            case DownloadStatus.Retrying:
                break;
            default:
                break;
        }

    }

    public void UpdateDownloadFileChunkStatus(DownloadFileChunkStatusEvent download)
    {
        if (download.DownloadFileChunkStatus == DownloadFileChunkStatus.Complated)
        {
            _eventManager.Publish(() => UpdateDownloadedBytes(download));

        }
        else
        {

        }
        //var find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        //if (find == null)
        //    return;



    }
    public void AddFileToQueueAction(AddFileToQueueEvent addFileToQueueEvent)
    {
        _eventManager.Publish( async () => await AddOrUpdateAllWaitingToStartDownloadFilesAsync());
    }
    #endregion
}
