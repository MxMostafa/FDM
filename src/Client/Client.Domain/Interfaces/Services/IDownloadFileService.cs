﻿

using Client.Domain.Dtos.Request.DownloadFile;
using Client.Domain.Dtos.Response.DownloadFile;
using Client.Domain.Dtos.Response.DownloadQueueItem;

namespace Client.Domain.Interfaces.Services;

public interface IDownloadFileService
{
    Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFilesAsync(int? downloadQueueId);
    Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url);
    Task<ResultPattern<List<DownloadFileResDto>>> GetAllStartedDownloadFilesAsync();
    Task<ResultPattern<bool>> AddFileToQueueAsync(AddFileToQueueReqDto addFileToQueueReqDto);
    Task UpdateDownloadFileStatusAsync(long downloadFileId, DownloadStatus downloadStatus);
    Task UpdateDownloadFileStatusAsync(List<long> downloadFileIds, DownloadStatus downloadStatus);
}
