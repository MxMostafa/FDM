
namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadFileChunkRepository
{
    Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId);
    Task<List<DownloadFileChunk>> AddAsync(List<DownloadFileChunk> downloadFileChunks);
    Task<DownloadFileChunk?> GetByIdAsync(long downloadFileChunkId);
    Task<DownloadFileChunk> UpdateAsync(DownloadFileChunk downloadFileChunk);
    Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId, DownloadFileChunkStatus downloadFileChunkStatus);
}
