

using Client.Domain.Helpers;
using System.Diagnostics;

namespace Client.Application.Services;

public class DownloadFileChunkService : IDownloadFileChunkService
{
    private readonly IDownloadFileChunkWriteRepository _downloadFileChunkWriteRepository;
    private readonly IDownloadFileChunkReadRepository _downloadFileChunkReadRepository;
    private readonly IDownloadFileReadRepository _downloadFileReadRepository;
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly IAppSettingRepository _appSettingRepository;
    private readonly IAppErrors _appErrors;
    private readonly IMapper _mapper;
    private const int CHUNK_SIZE = 1024 * 1000;
    private const int MAX_THREAD_COUNT = 10;
    private readonly ILogger<DownloadFileChunkService> _logger;
    private readonly List<ActiveDownloadChunkItemModel> _activeChunks = new();

    private SemaphoreSlim? _semaphoreChunk;
    public DownloadFileChunkService(
        IDownloadFileChunkWriteRepository downloadFileChunkWriteRepository,
        IDownloadFileChunkReadRepository downloadFileChunkReadRepository,
        IDownloadFileWriteRepository downloadFileWriteRepository,
        IDownloadFileReadRepository downloadFileReadRepository,
        IAppErrors appErrors
        , IMapper mapper,
        IEventManager eventManager,
        IEventAggregator eventAggregator,
        ILogger<DownloadFileChunkService> logger,
        IAppSettingRepository appSettingRepository)
    {
        _downloadFileChunkWriteRepository = downloadFileChunkWriteRepository;
        _downloadFileChunkReadRepository = downloadFileChunkReadRepository;
        _downloadFileReadRepository = downloadFileReadRepository;
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
        var downloadFile = await _downloadFileReadRepository.GetByIdAsync(downloadFileId);
        if (downloadFile == null)
        {
            //log TODO:
            return new ResultPattern<List<DownloadFileChunkResDto>>(_appErrors.NotFound);
        }
        var chunks = await _downloadFileChunkReadRepository.GetByDownloadFileIdAsync(downloadFileId);

        if (chunks.Count == 0)
        {
            chunks = await CreateChunksAsync(downloadFile.Id, downloadFile.Size, CHUNK_SIZE);
            chunks.ForEach(c => c.DownloadFileId = downloadFileId);
            await _downloadFileChunkWriteRepository.AddAsync(chunks);
        }

        var result = _mapper.Map<List<DownloadFileChunkResDto>>(chunks);
        result.ForEach(r => r.DownloadUrl = downloadFile.DownloadPath);
        return result;
    }


    public async Task<ResultPattern<List<DownloadFileChunkResDto>>> GetComplatedChunkFilesAsync(long downloadFileId)
    {
        var downloadFile = await _downloadFileReadRepository.GetByIdAsync(downloadFileId);
        if (downloadFile == null)
        {
            //log TODO:
            return new ResultPattern<List<DownloadFileChunkResDto>>(_appErrors.NotFound);
        }
        var chunks = await _downloadFileChunkReadRepository.GetByDownloadFileIdAsync(downloadFileId, DownloadFileChunkStatus.Complated);

        var result = _mapper.Map<List<DownloadFileChunkResDto>>(chunks);
        return result;
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

        long size = 0;
        foreach (var chunk in readyforDownloads)
        {

            await _semaphoreChunk!.WaitAsync();

            await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Downloading);

            _ = Task.Run(async () =>
            {
                try
                {
                    //Debug.WriteLine(Task.CurrentId.ToString() + "::" + chunk.Id);
                    if (chunk.TaskId == null)
                    {
                        chunk.TaskId = Task.CurrentId;
                    }

                    DownloadFileChunkStatus? status = null;
                    var success = await DownloadChunkAsync(chunk);

                    if (success)
                    {
                        _eventManager.Publish(async () => await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Complated));

                        status = DownloadFileChunkStatus.Complated;
                    }
                    else
                    {
                        _eventManager.Publish(async () => await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Error));
                        status = DownloadFileChunkStatus.Error;
                    }


                    //notify
                    _eventAggregator.Publish(new DownloadFileChunkStatusEvent(chunk.DownloadFileId, chunk.Id, status.Value, chunk.ChunkSize));
                    //  size += chunk.ChunkSize;
                    // Debug.WriteLine("Size : " + size.ToString());
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    _semaphoreChunk.Release();
                }


            }, chunk.CancellationTokenSource.Token);
        }

    }

    private async Task UpdateDownloadFileChunkStatusAsync(long downloadFileChunkId, DownloadFileChunkStatus downloadFileChunkStatus)
    {
        try
        {

            var downloadFileChunk = await _downloadFileChunkReadRepository.GetByIdAsync(downloadFileChunkId);
            if (downloadFileChunk == null) return;
            if (downloadFileChunk.DownloadFileChunkStatus == DownloadFileChunkStatus.Complated) return;
            downloadFileChunk.DownloadFileChunkStatus = downloadFileChunkStatus;
            await _downloadFileChunkWriteRepository.UpdateAsync(downloadFileChunk);
        }
        catch (Exception ex)
        {


        }


    }


    private async Task<bool> DownloadChunkAsync(ActiveDownloadChunkItemModel chunk)
    {
        try
        {
            await Task.Delay(new Random().Next(100, 500));
            return true;
            if (File.Exists(chunk.TempFilePath) && IsFileAccessible(chunk.TempFilePath))
            {
                FileInfo fileInfo = new FileInfo(chunk.TempFilePath);
                long fileSize = fileInfo.Length; // Size in bytes

                if (fileSize >= chunk.DownloadedBytes)
                {
                    chunk.DownloadFileChunkStatus = DownloadFileChunkStatus.Complated;
                    return true;
                }

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

    private bool IsFileAccessible(string filePath, int maxRetries = 5, int delayMilliseconds = 500)
    {
        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true; // File is accessible
                }
            }
            catch (IOException)
            {
                Thread.Sleep(delayMilliseconds); // Wait and retry
            }
        }
        return false; // File is still locked
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
