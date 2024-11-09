



namespace Client.Domain.Interfaces.Services;

public interface IAppSettingService
{
    Task<ResultPattern<List<AppSettingResDto>>> GetGeneralAppSettingAsync();
    Task<ResultPattern<AppSettingResDto?>> GetAppSettingByKeyAsync(string key);
    Task<ResultPattern<bool>> AddGeneralAppSettingAsync(string key, string value);
    Task<ResultPattern<bool>> AddGeneralAppSettingsAsync(Dictionary<string, string> keyValuePairs);
}
