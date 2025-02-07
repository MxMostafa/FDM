
namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadFileChunkWriteRepository
{
    Task<List<DownloadFileChunk>> AddAsync(List<DownloadFileChunk> downloadFileChunks);
    Task<DownloadFileChunk> UpdateAsync(DownloadFileChunk downloadFileChunk);
    Task<List<DownloadFileChunk>> UpdateAsync(List<DownloadFileChunk> downloadFileChunks);
   
}
