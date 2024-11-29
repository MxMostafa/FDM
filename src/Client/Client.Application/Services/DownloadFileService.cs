

namespace Client.Application.Services;

public class DownloadFileService : IDownloadFileService
{
    private readonly IHttpRepository _httpRepository;

    public DownloadFileService(IHttpRepository httpRepository)
    {
        _httpRepository = httpRepository;
    }

    public Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url)
    {
        return _httpRepository.GetFileInfoAsync(url);
    }
}
