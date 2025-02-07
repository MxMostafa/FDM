
namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadFileChunkReadRepository
{
    Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId);
    Task<DownloadFileChunk?> GetByIdAsync(long downloadFileChunkId);
    Task<List<DownloadFileChunk>> GetByIdsAsync(List<long> downloadFileChunkIds);
    Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId, DownloadFileChunkStatus downloadFileChunkStatus);
}
