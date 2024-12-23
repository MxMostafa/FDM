﻿

namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadFileRepository
{
    Task<DownloadFile?> GetAsync(string fileName,string downloadUrl);
    Task<DownloadFile> AddAsync(DownloadFile downloadFile);
    Task<List<DownloadFile>> AddAsync(List<DownloadFile> downloadFiles);
    Task<DownloadFile> UpdateAsync(DownloadFile downloadFile);
    Task<List<DownloadFile>> UpdateAsync(List<DownloadFile> downloadFiles);
    Task<List<DownloadFile>> GetAsync(int? queueId);
    Task<DownloadFile> SoftDeleteAsync(DownloadFile downloadFile);
    Task<List<DownloadFile>> SoftDeleteAsync(List<DownloadFile> downloadFiles);
    Task<List<DownloadFile>> GetsStartedAsync(DownloadStatus downloadStatus);
    Task<DownloadFile?> GetByIdAsync(long id);
    Task<List<DownloadFile>> GetByIdsAsync(List<long> ids);
    Task<List<DownloadFile>> GetByStatusAsync(DownloadStatus downloadStatus);
}
