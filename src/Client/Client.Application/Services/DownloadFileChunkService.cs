﻿

using Client.Application.Models;
using Client.Domain.Dtos.Response.ChunkFile;
using Client.Domain.EventModels;
using Client.Domain.Interfaces.General.Errors;
using Client.Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Threading;

namespace Client.Application.Services;

public class DownloadFileChunkService : IDownloadFileChunkService
{
    private readonly IDownloadFileChunkRepository _downloadFileChunkRepository;
    private readonly IDownloadFileRepository _downloadFileRepository;
    private readonly IEventManager _eventManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly IAppErrors _appErrors;
    private readonly IMapper _mapper;
    private const int CHUNK_SIZE = 1024 * 1024;
    private const int MAX_THREAD_COUNT = 5;
    private readonly ILogger<DownloadFileChunkService> _logger;
    private readonly List<ActiveDownloadChunkItemModel> _activeChunks = new();
    private SemaphoreSlim? _semaphore;
    public DownloadFileChunkService(IDownloadFileChunkRepository downloadFileChunkRepository, IDownloadFileRepository downloadFileRepository, IAppErrors appErrors = null, IMapper mapper = null, IEventManager eventManager = null, IEventAggregator eventAggregator = null, ILogger<DownloadFileChunkService> logger = null)
    {
        _downloadFileChunkRepository = downloadFileChunkRepository;
        _downloadFileRepository = downloadFileRepository;
        _appErrors = appErrors;
        _mapper = mapper;
        _eventManager = eventManager;
        _eventAggregator = eventAggregator;
        _logger = logger;
    }

    private void InitialAsync()
    {
        if (_semaphore == null)
        {
            _semaphore = new SemaphoreSlim(MAX_THREAD_COUNT); // حداکثر 5 تسک همزمان
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
            chunks = CreateChunks(downloadFile.Size, CHUNK_SIZE);
            chunks.ForEach(c => c.DownloadFileId = downloadFileId);
            await _downloadFileChunkRepository.AddAsync(chunks);
        }

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
                Id = 0,
                DownloadFileId = i.DownloadFileId,
                DownloadUrl = i.DownloadUrl,
                Index = i.Index,
                Start = i.Start,
                End = i.End,
                TempFilePath = i.TempFilePath,
                DownloadFileChunkStatus = i.DownloadFileChunkStatus,
                CancellationTokenSource = new CancellationTokenSource(),
                TaskId = null,
                DownloadedBytes = 0
            });
        }

        var readyforDownloads = _activeChunks.Where(a => a.TaskId == null || a.DownloadFileChunkStatus != DownloadFileChunkStatus.Complated).ToList();

        foreach (var chunk in readyforDownloads)
        {
            await _semaphore!.WaitAsync();

            _ = Task.Run(async () =>
            {
                try
                {
                    if (chunk.TaskId == null)
                    {
                        chunk.TaskId = Task.CurrentId;
                    }

                    _eventManager.Publish(async () =>
                    {
                        await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Downloading);
                    });


                    var success = await DownloadChunkAsync(chunk);

                    if (success)
                    {
                        _eventManager.Publish(async () =>
                        {
                            await UpdateDownloadFileChunkStatusAsync(chunk.Id, DownloadFileChunkStatus.Complated);
                        });
                    }
                }
                finally
                {
                    _semaphore.Release();
                }


            }, chunk.CancellationTokenSource.Token);
        }

    }

    public async Task UpdateDownloadFileChunkStatusAsync(long downloadFileChunkId, DownloadFileChunkStatus downloadFileChunkStatus)
    {
        var downloadFileChunk = await _downloadFileChunkRepository.GetByIdAsync(downloadFileChunkId);
        if (downloadFileChunk == null) return;
        if (downloadFileChunk.DownloadFileChunkStatus == DownloadFileChunkStatus.Complated) return;
        downloadFileChunk.DownloadFileChunkStatus = downloadFileChunkStatus;
        await _downloadFileChunkRepository.UpdateAsync(downloadFileChunk);
        _eventAggregator.Publish(new DownloadFileChunkStatusEvent(downloadFileChunkId, downloadFileChunkStatus));
    }


    private async Task<bool> DownloadChunkAsync(ActiveDownloadChunkItemModel chunk)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, chunk.DownloadUrl);
                request.Headers.Range = new RangeHeaderValue(chunk.Start + chunk.DownloadedBytes, chunk.End);

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using var fileStream = new FileStream(chunk.TempFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
                await response.Content.CopyToAsync(fileStream);

                chunk.DownloadedBytes += response.Content.Headers.ContentLength ?? 0;
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
    private List<DownloadFileChunk> CreateChunks(long fileSize, int chunkSize)
    {
        var chunks = new List<DownloadFileChunk>();
        long currentStart = 0;
        while (currentStart < fileSize)
        {
            long currentEnd = Math.Min(currentStart + chunkSize - 1, fileSize - 1);
            chunks.Add(new DownloadFileChunk()
            {
                Index = chunks.Count,
                Start = currentStart,
                End = currentEnd,
                TempFilePath = Path.GetTempFileName(),
                DownloadFileChunkStatus = DownloadFileChunkStatus.Pending,
                Id = 0
            });
            currentStart = currentEnd + 1;
        }

        return chunks;

    }
}
