

using Client.Domain.Dtos.Response.ChunkFile;

namespace Client.Domain.Interfaces.Services;

public interface IDownloadFileChunkService
{
    public Task<ResultPattern<List<DownloadFileChunkResDto>>> CheckAndCreateChunkFilesAsync(long downloadFileId);
    Task UpdateDownloadFileChunkStatusAsync(long downloadFileChunkId, DownloadFileChunkStatus downloadFileChunkStatus);
    Task StartDownloadAsync(List<DownloadFileChunkResDto> chunkFiles);
}
