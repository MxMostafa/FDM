

using Client.Domain.Entites;
using Client.Domain.Enums;

namespace Client.Application.Services;

public class DownloadFileChunkService : IDownloadFileChunkService
{
    private readonly IDownloadFileChunkRepository _downloadFileChunkRepository;
    private readonly IDownloadFileRepository _downloadFileRepository;
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly IAppSettingRepository _appSettingRepository;
    private readonly IAppErrors _appErrors;
    private readonly IMapper _mapper;
    private const int CHUNK_SIZE = 1024 * 100;
    private const int MAX_THREAD_COUNT = 1;
    private readonly ILogger<DownloadFileChunkService> _logger;
    private readonly List<ActiveDownloadChunkItemModel> _activeChunks = new();

    private SemaphoreSlim? _semaphoreChunk;
    public DownloadFileChunkService(IDownloadFileChunkRepository downloadFileChunkRepository, IDownloadFileRepository downloadFileRepository, IAppErrors appErrors = null, IMapper mapper = null, IEventManager eventManager = null, IEventAggregator eventAggregator = null, ILogger<DownloadFileChunkService> logger = null, IAppSettingRepository appSettingRepository = null)
    {
        _downloadFileChunkRepository = downloadFileChunkRepository;
        _downloadFileRepository = downloadFileRepository;
        _appErrors = appErrors;
        _mapper = mapper;
        _eventManager = eventManager;
        _eventAggregator = eventAggregator;
        _logger = logger;
        _appSettingRepository = appSettingRepository;
    }

    private void InitialAsync()
    {
        if (_semaphoreChunk == null)
        {
            _semaphoreChunk = new SemaphoreSlim(MAX_THREAD_COUNT); // حداکثر 5 تسک همزمان
        }
    }

    public async Task<ResultPattern<List<DownloadFileChunkResDto>>> CheckAndCreateChunkFilesAsync(long downloadFileId)
    {
        var downloadFile = await _downloadFileRepository.GetByIdAsync(downloadFileId);
        if (downloadFile == null)
        {
            //log TODO:
            return new ResultPattern<List<DownloadFileChunkResDto>>(_appErrors.NotFound);
        }
        var chunks = await _downloadFileChunkRepository.GetByDownloadFileIdAsync(downloadFileId);

        if (chunks.Count == 0)
        {
            chunks = await CreateChunksAsync(downloadFile.Id, downloadFile.Size, CHUNK_SIZE);
            chunks.ForEach(c => c.DownloadFileId = downloadFileId);
            await _downloadFileChunkRepository.AddAsync(chunks);
        }

        var result = _mapper.Map<List<DownloadFileChunkResDto>>(chunks);
        result.ForEach(r => r.DownloadUrl = downloadFile.DownloadPath);
        return result;
    }


    private static readonly SemaphoreSlim _semaphoreGetComplatedChunkFiles = new(1, 1);
    public async Task<ResultPattern<List<DownloadFileChunkResDto>>> GetComplatedChunkFilesAsync(long downloadFileId)
    {
        await _semaphoreGetComplatedChunkFiles.WaitAsync();
        try
        {
            var downloadFile = await _downloadFileRepository.GetByIdAsync(downloadFileId);
            if (downloadFile == null)
            {
                //log TODO:
                return new ResultPattern<List<DownloadFileChunkResDto>>(_appErrors.NotFound);
            }
            var chunks = await _downloadFileChunkRepository.GetByDownloadFileIdAsync(downloadFileId, DownloadFileChunkStatus.Complated);

            var result = _mapper.Map<List<DownloadFileChunkResDto>>(chunks);
            return result;
        }
        finally
        {
            _semaphoreGetComplatedChunkFiles.Release();
        }


    }


    public async Task StartDownloadAsync(List<DownloadFileChunkResDto> chunkFiles)
    {
        InitialAsync();

        foreach (var i in chunkFiles)
        {
            _activeChunks.Add(new ActiveDownloadChunkItemModel()
            {
                Id = i.Id,
                DownloadFileId = i.DownloadFileId,
                DownloadUrl = i.DownloadUrl,
                Index = i.Index,
                Start = i.Start,
                End = i.End,
                TempFilePath = i.TempFilePath,
                DownloadFileChunkStatus = i.DownloadFileChunkStatus,
                CancellationTokenSource = new CancellationTokenSource(),
                TaskId = null,
                DownloadedBytes = i.Size,
            });
        }

        var readyforDownloads = _activeChunks.Where(a => a.TaskId == null && a.DownloadFileChunkStatus != DownloadFileChunkStatus.Complated).ToList();

        foreach (var chunk in readyforDownloads)
        {
            await _semaphoreChunk!.WaitAsync();


            _eventManager.Publish(async () =>
            {
                //save into database
                await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Downloading);
            });



            _ = Task.Run(async () =>
            {
                try
                {
                    if (chunk.TaskId == null)
                    {
                        chunk.TaskId = Task.CurrentId;
                    }

                    DownloadFileChunkStatus? status = null;
                    var success = await DownloadChunkAsync(chunk);

                    if (success)
                    {
                        await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Complated);
                        status = DownloadFileChunkStatus.Complated;
                    }
                    else
                    {
                        await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Error);
                        status = DownloadFileChunkStatus.Error;
                    }


                    //notify
                    _eventAggregator.Publish(new DownloadFileChunkStatusEvent(chunk.DownloadFileId, chunk.Id, status.Value, chunk.DownloadedBytes));

                }
                finally
                {
                    _semaphoreChunk.Release();
                }


            }, chunk.CancellationTokenSource.Token);
        }

    }


    // private Dictionary<long, DownloadFileChunkStatus> updateDownloadFileChunkQueue = new Dictionary<long, DownloadFileChunkStatus>();




    private static readonly SemaphoreSlim _semaphoreUpdateDownloadFileChunkStatus = new(1, 1);
    private async Task UpdateDownloadFileChunkStatusAsync(long downloadFileChunkId, DownloadFileChunkStatus downloadFileChunkStatus)
    {
        await _semaphoreUpdateDownloadFileChunkStatus.WaitAsync();
        try
        {
            var downloadFileChunk = await _downloadFileChunkRepository.GetByIdAsync(downloadFileChunkId);
            if (downloadFileChunk == null) return;
            if (downloadFileChunk.DownloadFileChunkStatus == DownloadFileChunkStatus.Complated) return;
            downloadFileChunk.DownloadFileChunkStatus = downloadFileChunkStatus;
            await _downloadFileChunkRepository.UpdateAsync(downloadFileChunk);
        }
        finally
        {
            _semaphoreUpdateDownloadFileChunkStatus.Release();
        }
    }


    private async Task<bool> DownloadChunkAsync(ActiveDownloadChunkItemModel chunk)
    {
        try
        {
            if (File.Exists(chunk.TempFilePath))
            {
                FileInfo fileInfo = new FileInfo(chunk.TempFilePath);
                long fileSize = fileInfo.Length; // Size in bytes

                if (fileSize >= chunk.DownloadedBytes)
                    return true;
                else
                {

                }
            }

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, chunk.DownloadUrl);
                request.Headers.Range = new RangeHeaderValue(chunk.Start, chunk.End);

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                string filePath = chunk.TempFilePath; // Replace with your file path
                string? folderPath = Path.GetDirectoryName(filePath!);

                if (!string.IsNullOrEmpty(folderPath))
                {
                    Directory.CreateDirectory(folderPath); // Ensures the directory exists
                }

                using var fileStream = new FileStream(chunk.TempFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
                await response.Content.CopyToAsync(fileStream);

                chunk.DownloadedBytes = response.Content.Headers.ContentLength ?? 0;
                chunk.DownloadFileChunkStatus = DownloadFileChunkStatus.Complated;
                return true;
            }


        }
        catch (Exception ex)
        {
            _logger.LogError(ex.InnerException?.Message ?? ex.Message);
            return false;
        }



    }
    private async Task<List<DownloadFileChunk>> CreateChunksAsync(long downloadFileId, long fileSize, int chunkSize)
    {
        string tempFilePath = null!;
        var tempSavePath = await _appSettingRepository.GetAppSettingByKeyAsync(AppSettingConfigs.TempSavePath);

        if (tempSavePath != null && tempSavePath.Value != null)
        {
            tempFilePath = tempSavePath.Value!;
        }
        else
        {
            tempFilePath = Path.GetTempFileName();
        }

        var chunks = new List<DownloadFileChunk>();
        long currentStart = 0;
        while (currentStart < fileSize)
        {
            long currentEnd = Math.Min(currentStart + chunkSize - 1, fileSize - 1);
            chunks.Add(new DownloadFileChunk()
            {
                Size = chunkSize,
                DownloadFileId = 0,
                Index = chunks.Count,
                Start = currentStart,
                End = currentEnd,
                TempFilePath = $"{tempFilePath}\\{downloadFileId}\\{Guid.NewGuid()}",
                DownloadFileChunkStatus = DownloadFileChunkStatus.Pending,
                Id = 0
            });
            currentStart = currentEnd + 1;
        }
        return chunks;

    }
}
