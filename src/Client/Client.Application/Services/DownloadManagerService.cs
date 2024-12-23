
using Client.Application.Helpers;
using Client.Application.Models;
using Client.Domain.Dtos.Request.DownloadFile;
using Client.Domain.Dtos.Response.DownloadFile;
using Client.Domain.EventModels;
using Client.Domain.Interfaces.Services;
using Mapster;
using Microsoft.Extensions.Logging;
namespace Client.Application.Services;

public class DownloadManagerService : IDownloadManagerService
{

    #region Ctor
    private SemaphoreSlim? _semaphore;
    private readonly IAppSettingService _appSettingService;
    private readonly ILogger<DownloadManagerService> _logger;
    private readonly IDownloadFileService _downloadFileService;
    private readonly IDownloadFileChunkService _downloadFileChunkService;
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly IServiceProvider _serviceProvider;

    public DownloadManagerService(IAppSettingService appSettingService,
        ILogger<DownloadManagerService> logger, IDownloadFileService downloadFileService, IEventManager eventManager, IEventAggregator eventAggregator, IDownloadFileChunkService downloadFileChunkService = null, IServiceProvider serviceProvider = null)
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

                _ = Task.Run(async () =>
                {
                    try
                    {
                        if (download.TaskId == null)
                        {
                            download.TaskId = Task.CurrentId;
                        }

                        _eventManager.Publish(async () =>
                        {
                            await _downloadFileService.UpdateDownloadFileStatusAsync(download.Id, DownloadStatus.Started);
                        });

                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var downloadFileChunkService = scope.ServiceProvider.GetRequiredService<IDownloadFileChunkService>();
                            await downloadFileChunkService.StartDownloadAsync(chunks!);
                        }




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
    private void FinishDownload(long downloadId)
    {
        _eventManager.Publish(async () =>
        {
            await _downloadFileService.UpdateDownloadFileStatusAsync(downloadId, DownloadStatus.Finished);
        });
    }

    private void UpdateDownloadedBytes(long downloadId, long downloadedBytes, long downloadSize)
    {
        _eventManager.Publish(async () =>
        {
            if (downloadedBytes > downloadSize)
                downloadedBytes = downloadSize;

            await _downloadFileService.UpdateDownloadFileAsync(new UpdateDownloadFileReqDto(downloadId, downloadedBytes));
        });
    }

    public async void UpdateDownloadFileStatus(DownloadFileStatusEvent download )
    {
        var find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        if (find == null)
        {
            await AddOrUpdateAllWaitingToStartDownloadFilesAsync();
            find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        }
        if (find == null) return;

        switch (download.DownloadStatus)
        {
            case DownloadStatus.NotStarted:
                break;
            case DownloadStatus.WaitingToStart:
                if (find.CancellationTokenSource.IsCancellationRequested)
                    find.CancellationTokenSource = new CancellationTokenSource();
                _eventManager.Publish(async () => await ProcessDownloadAsync());
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

    public async void UpdateDownloadFileChunkStatus(DownloadFileChunkStatusEvent download)
    {
        var find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        if (find == null)
        {
            await AddOrUpdateAllWaitingToStartDownloadFilesAsync();
            find = _activeDownloads.FirstOrDefault(d => d.Id == download.DownloadFileId);
        }
        if (find == null)
            return;

        FinishDownload(download.DownloadFileId);

    }
    public void AddFileToQueueAction(AddFileToQueueEvent addFileToQueueEvent)
    {
        _eventManager.Publish(async () => await AddOrUpdateAllWaitingToStartDownloadFilesAsync());
    }
    #endregion
}
