



namespace Client.Domain.Interfaces.Services;

public interface IAppSettingService
{
    Task<ResultPattern<List<AppSettingResDto>>> GetAllAppSettingAsync();
    Task<ResultPattern<AppSettingResDto?>> GetAppSettingByKeyAsync(string key);
    Task<ResultPattern<bool>> AddAppSettingAsync(string key, string value);
    Task<ResultPattern<bool>> AddAppSettingAsync(Dictionary<string, string> keyValuePairs);
}
