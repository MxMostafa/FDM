

using Client.Domain.Dtos.Request.DownloadFile;
using Client.Domain.Dtos.Response.DownloadFile;
using Client.Domain.Dtos.Response.DownloadQueueItem;

namespace Client.Domain.Interfaces.Services;

public interface IDownloadFileService
{
    Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFilesAsync(int? downloadQueueId);
    Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url);
    Task<ResultPattern<bool>> AddFileToQueueAsync(AddFileToQueueReqDto addFileToQueueReqDto);
    Task UpdateDownloadFileStatusAsync(long downloadFileId, DownloadStatus downloadStatus);
    Task UpdateDownloadFileStatusAsync(List<long> downloadFileIds, DownloadStatus downloadStatus);
    Task<ResultPattern<DownloadFileResDto?>> GetDownloadFileByIdAsync(long downloadFileId);
    Task UpdateDownloadFileAsync(UpdateDownloadFileReqDto updateDownloadFileReqDto);
    Task<ResultPattern<List<DownloadFileResDto>>> GetDownloadFileByStatusAsync(DownloadStatus downloadStatus);
    Task ResetStartedItemsToPausedItemsAsync();
    Task ResetItemsAsync();
    Task<ResultPattern<List<DownloadFileResDto>>> GetAllStartedDownloadFilesAsync();
    Task<ResultPattern<List<DownloadFileResDto>>> GetAllWaitingToStartDownloadFilesAsync();
}
