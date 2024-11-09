

namespace Client.Domain.Interfaces.Repositories;

public interface IAppSettingRepository
{
    Task<List<AppSetting>> GetAppSettingByTypeAsync(AppSettingType appSettingType);
}
