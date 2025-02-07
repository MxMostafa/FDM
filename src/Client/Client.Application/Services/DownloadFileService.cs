

using Client.Application.General.Errors;
using Client.Domain.Dtos.Request.DownloadFile;
using Client.Domain.Dtos.Response.DownloadFile;
using Client.Domain.Entites;
using Client.Domain.EventModels;
using Client.Domain.Interfaces.General.Errors;

namespace Client.Application.Services;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHttpRepository _httpRepository;
    private readonly IDownloadFileWriteRepository _downloadFileWriteRepo;
    private readonly IDownloadFileReadRepository _downloadFileReadRepo;
    private readonly IDownloadQueueRepository _downloadQueueRepo;
    private readonly IFileTypeGroupRepository _fileTypeGroupRepo;
    private readonly IEventAggregator _eventAggregator;
    private readonly IAppErrors _appErrors;

    public DownloadFileService(IHttpRepository httpRepository, 
        IDownloadFileWriteRepository downloadFileWriteRepo,
        IDownloadFileReadRepository downloadFileReadRepo,
        IDownloadQueueRepository downloadQueueRepo,
        IFileTypeGroupRepository fileTypeGroupRepo,
        IAppErrors appErrors,
        IEventAggregator eventAggregator)
    {
        _httpRepository = httpRepository;
        _downloadFileWriteRepo = downloadFileWriteRepo;
        _downloadFileReadRepo= downloadFileReadRepo;
        _downloadQueueRepo = downloadQueueRepo;
        _fileTypeGroupRepo = fileTypeGroupRepo;
        _appErrors = appErrors;
        _eventAggregator = eventAggregator;
    }

    public async Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFilesAsync(int? downloadQueueId)
    {
        var downloads = await _downloadFileReadRepo.GetAsync(downloadQueueId);

        var items = downloads.Select(d => new DownloadFileResDto()
        {
            DownloadQueue = d.DownloadQueue,
            FileName = d.FileName,
            Description = d.Description,
            DownloadStatus = d.DownloadStatus,
            Id = d.Id,
            Size = d.Size,
            DownloadedBytes = d.DownloadedBytes,
        }).ToList();

        var index = 1;
        items.ForEach(i =>
        {
            i.Row = index++;
        });
        return items;
    }

    public async Task<ResultPattern<DownloadFileResDto?>> GetDownloadFileByIdAsync(long downloadFileId)
    {
        var download = await _downloadFileReadRepo.GetByIdAsync(downloadFileId);

        if (download == null) return new ResultPattern<DownloadFileResDto?>(_appErrors.NotFound);

        return new DownloadFileResDto()
        {
            DownloadQueue = download.DownloadQueue,
            FileName = download.FileName,
            Description = download.Description,
            DownloadStatus = download.DownloadStatus,
            Id = download.Id,
            Size = download.Size,
            DownloadedBytes = download.DownloadedBytes,
        };
    }

    public async Task<ResultPattern<List<DownloadFileResDto>>> GetAllWaitingToStartDownloadFilesAsync()
    {
        var downloads = await _downloadFileReadRepo.GetsStartedAsync(DownloadStatus.WaitingToStart);

        return downloads.Select(d => new DownloadFileResDto()
        {
            DownloadQueue = d.DownloadQueue,
            FileName = d.FileName,
            Description = d.Description,
            DownloadStatus = d.DownloadStatus,
            DownloadedBytes = d.DownloadedBytes,
            Id = d.Id,
            Size = d.Size
        }).ToList();
    }

    public async Task<ResultPattern<List<DownloadFileResDto>>> GetAllStartedDownloadFilesAsync()
    {
        var downloads = await _downloadFileReadRepo.GetsStartedAsync(DownloadStatus.Started);

        return downloads.Select(d => new DownloadFileResDto()
        {
            DownloadQueue = d.DownloadQueue,
            FileName = d.FileName,
            Description = d.Description,
            DownloadStatus = d.DownloadStatus,
            Id = d.Id,
            Size = d.Size
        }).ToList();
    }

    public async Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFileByStatusAsync(DownloadStatus downloadStatus)
    {
        var downloads = await _downloadFileReadRepo.GetByStatusAsync(downloadStatus);

        return downloads.Select(d => new DownloadFileResDto()
        {
            DownloadQueue = d.DownloadQueue,
            FileName = d.FileName,
            Description = d.Description,
            DownloadStatus = d.DownloadStatus,
            Id = d.Id,
            Size = d.Size
        }).ToList();
    }

    public async Task UpdateDownloadFileAsync(UpdateDownloadFileReqDto updateDownloadFileReqDto)
    {
        var downloadFile = await _downloadFileReadRepo.GetByIdAsync(updateDownloadFileReqDto.Id);
        if (downloadFile == null) return;
        downloadFile.DownloadedBytes = updateDownloadFileReqDto.DownloadedBytes;
        await _downloadFileWriteRepo.UpdateAsync(downloadFile);
    }

    public async Task UpdateDownloadFileStatusAsync(long downloadFileId, DownloadStatus downloadStatus)
    {
        var downloadFile = await _downloadFileReadRepo.GetByIdAsync(downloadFileId);
        if (downloadFile == null) return;
        if (downloadFile.DownloadStatus == DownloadStatus.Finished) return;
        downloadFile.DownloadStatus = downloadStatus;
        await _downloadFileWriteRepo.UpdateAsync(downloadFile);
        _eventAggregator.Publish(new DownloadFileStatusEvent(downloadFileId, downloadStatus));
    }

    public async Task UpdateDownloadFileStatusAsync(List<long> downloadFileIds, DownloadStatus downloadStatus)
    {
        var downloadFiles = await _downloadFileReadRepo.GetByIdsAsync(downloadFileIds);
        downloadFiles.ForEach(d => d.DownloadStatus = downloadStatus);
        await _downloadFileWriteRepo.UpdateAsync(downloadFiles);
    }

    public async Task<ResultPattern<bool>> AddFileToQueueAsync(AddFileToQueueReqDto model)
    {
        var downloadFile = await _downloadFileReadRepo.GetAsync(model.FileName, model.DownloadURL);
        downloadFile = null;
        if (downloadFile == null)
        {
            var downloadQueue = await _downloadQueueRepo.GetByIdAsync(model.downloadQueueId);

            if (downloadQueue == null)
            {
                downloadQueue = await GetMainDowanloadQueueAsync();
            }

            var fileTypeGroup = await _fileTypeGroupRepo.GetByFileExtensionAsync(model.FileExtension!);
            downloadFile = await _downloadFileWriteRepo.AddAsync(new DownloadFile()
            {
                DownloadQueueId= downloadQueue.Id,
                DownloadPath = model.DownloadURL,
                FileName = model.FileName,
                Id = 0,
                LocalSavePath = model.SavePath,
                DownloadStatus = model.DownloadStatus,
                Size = model.SizeInBytes,
                FileTypeGroupId = fileTypeGroup?.Id
            });

            _eventAggregator.Publish(new AddFileToQueueEvent(downloadFile.Id));

            return true;
        }
        return new ResultPattern<bool>(_appErrors.DuplicatedDownloadFile, ErrorCodes.DownloadFileExist);
    }

    public Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url)
    {
        return _httpRepository.GetFileInfoAsync(url);
    }

    private async Task<DownloadQueue> GetMainDowanloadQueueAsync()
    {
        var queue = await _downloadQueueRepo.GetMainQueueAsync();

        if (queue != null) return queue;

        queue = await _downloadQueueRepo.CreateMainQueueAsync();
        return queue;
    }


    public async Task ResetStartedItemsToPausedItemsAsync()
    {
        var request = await GetDownloadFileByStatusAsync(DownloadStatus.Started);
        if (!request.IsSucceed) return;

        var ids = request.Data!.Select(d => d.Id).ToList();

        request = await GetDownloadFileByStatusAsync(DownloadStatus.WaitingToStart);
        if (!request.IsSucceed) return;
        ids.AddRange(request.Data!.Select(d => d.Id).ToList());

        await UpdateDownloadFileStatusAsync(ids, DownloadStatus.Paused);
    }

    public async Task ResetItemsAsync()
    {
        var downloads = await _downloadFileReadRepo.GetAsync(null);
        foreach (var item in downloads)
        {
            item.DownloadStatus = DownloadStatus.NotStarted;
            item.DownloadedBytes = 0;
        }
        await _downloadFileWriteRepo.UpdateAsync(downloads);
    }

}
