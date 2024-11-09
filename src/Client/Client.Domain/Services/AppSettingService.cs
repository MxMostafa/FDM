
namespace Client.Domain.Services;
public class AppSettingService : IAppSettingService
{
    public Task<ResultPattern<bool>> AddAppSettingAsync(string key, string value)
    {
        throw new NotImplementedException();
    }

    public Task<ResultPattern<bool>> AddAppSettingAsync(Dictionary<string, string> keyValuePairs)
    {
        throw new NotImplementedException();
    }

    public Task<ResultPattern<List<AppSettingResDto>>> GetAllAppSettingAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultPattern<AppSettingResDto?>> GetAppSettingByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }
}
