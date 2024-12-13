
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
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    public DownloadManagerService(IAppSettingService appSettingService,
        ILogger<DownloadManagerService> logger, IDownloadFileService downloadFileService, IEventManager eventManager, IEventAggregator eventAggregator)
    {
        _appSettingService = appSettingService;
        _logger = logger;
        _downloadFileService = downloadFileService;
        _eventManager = eventManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.Subscribe<AddFileToQueueEvent>(AddFileToQueueAction);
        _eventAggregator.Subscribe<DownloadFileStatusEvent>(UpdateDownloadFileStatus);
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
            var readyforDownloads = _activeDownloads.Where(a => a.TaskId == null || a.DownloadStatus == DownloadStatus.WaitingToStart).ToList();

            foreach (var download in readyforDownloads)
            {

                await _semaphore!.WaitAsync();

                _ = Task.Run(async () =>
                {
                    try
                    {
                        if (download.TaskId == null)
                        {
                            download.TaskId = Task.CurrentId;
                        }

                        var i = 0;
                        _eventManager.Publish(async () =>
                        {
                            await _downloadFileService.UpdateDownloadFileStatusAsync(download.Id, DownloadStatus.Started);
                        });

                        while (download.DownloadedBytes < download.Size && !download.CancellationTokenSource.Token.IsCancellationRequested)
                        {
                            i = i + new Random().Next(1, 500000);
                            download.DownloadedBytes += i;
                            await Task.Delay(new Random().Next(1, 500));
                            _eventManager.Publish(async () =>
                            {
                                if (download.DownloadedBytes > download.Size)
                                    download.DownloadedBytes = download.Size;

                                await _downloadFileService.UpdateDownloadFileAsync(new UpdateDownloadFileReqDto(download.Id, download.DownloadedBytes));
                            });
                        }


                        if (download.DownloadedBytes >= download.Size)
                        {
                            _eventManager.Publish(async () =>
                            {
                                await _downloadFileService.UpdateDownloadFileStatusAsync(download.Id, DownloadStatus.Finished);
                            });
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

    public async void UpdateDownloadFileStatus(DownloadFileStatusEvent download)
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

    public void AddFileToQueueAction(AddFileToQueueEvent addFileToQueueEvent)
    {
        _eventManager.Publish(async () => await AddOrUpdateAllWaitingToStartDownloadFilesAsync());
    }
    #endregion
}
