

using Client.Application.General.Errors;
using Client.Domain.Dtos.Request.DownloadFile;
using Client.Domain.Dtos.Response.DownloadFile;
using Client.Domain.Interfaces.General.Errors;

namespace Client.Application.Services;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHttpRepository _httpRepository;
    private readonly IDownloadFileRepository _downloadFileRepo;
    private readonly IDownloadQueueRepository _downloadQueueRepo;
    private readonly IFileTypeGroupRepository _fileTypeGroupRepo;
    private readonly IAppErrors _appErrors;

    public DownloadFileService(IHttpRepository httpRepository, IDownloadFileRepository downloadFileRepository, IDownloadQueueRepository downloadQueueRepo, IFileTypeGroupRepository fileTypeGroupRepo, IAppErrors appErrors)
    {
        _httpRepository = httpRepository;
        _downloadFileRepo = downloadFileRepository;
        _downloadQueueRepo = downloadQueueRepo;
        _fileTypeGroupRepo = fileTypeGroupRepo;
        _appErrors = appErrors;
    }

    public async Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFilesAsync(int? downloadQueueId)
    {
        var downloads = await _downloadFileRepo.GetAsync(downloadQueueId);

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


    public async Task<ResultPattern<List<DownloadFileResDto>>> GetAllStartedDownloadFilesAsync()
    {
        var downloads = await _downloadFileRepo.GetsStartedAsync();

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


    public async Task<ResultPattern<bool>> AddFileToQueueAsync(AddFileToQueueReqDto model)
    {
        var downloadFile = await _downloadFileRepo.GetAsync(model.FileName, model.DownloadURL);
        downloadFile = null;
        if (downloadFile == null)
        {
            var downloadQueue = await _downloadQueueRepo.GetByIdAsync(model.downloadQueueId);

            if (downloadQueue == null)
            {
                downloadQueue = await GetMainDowanloadQueueAsync();
            }

            var fileTypeGroup = await _fileTypeGroupRepo.GetByFileExtensionAsync(model.FileExtension!);
            downloadFile = await _downloadFileRepo.AddAsync(new DownloadFile()
            {

                DownloadPath = model.DownloadURL,
                DownloadQueue = downloadQueue,
                FileName = model.FileName,
                Id = 0,
                LocalSavePath = model.SavePath,
                DownloadStatus = DownloadStatus.NotStarted,
                Size = model.SizeInBytes,
                FileTypeGroup = fileTypeGroup
            });
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
}
