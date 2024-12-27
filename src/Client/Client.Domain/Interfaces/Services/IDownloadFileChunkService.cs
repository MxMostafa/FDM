

using Client.Domain.Dtos.Response.ChunkFile;

namespace Client.Domain.Interfaces.Services;

public interface IDownloadFileChunkService
{
    public Task<ResultPattern<List<DownloadFileChunkResDto>>> CheckAndCreateChunkFilesAsync(long downloadFileId);
    Task StartDownloadAsync(List<DownloadFileChunkResDto> chunkFiles);
    Task<ResultPattern<List<DownloadFileChunkResDto>>> GetComplatedChunkFilesAsync(long downloadFileId);
}
