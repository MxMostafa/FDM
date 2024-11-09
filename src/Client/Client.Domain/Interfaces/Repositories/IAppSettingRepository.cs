

namespace Client.Domain.Interfaces.Repositories;

public interface IAppSettingRepository
{
    Task<List<AppSetting>> GetAppSettingByTypeAsync(AppSettingType appSettingType);
    Task<AppSetting> AddAppSettingAsync(AppSetting appSetting);
    Task<List<AppSetting>> AddAppSettingAsync(List<AppSetting> appSettings);
    Task<AppSetting?> GetAppSettingByTypeAndKeyAsync(AppSettingType appSettingType,string key);

    Task<AppSetting> UpdateAppSettingAsync(AppSetting appSetting);
}
