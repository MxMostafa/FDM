



namespace Client.Infra.Repositories;

public class AppSettingRepository : BaseRepository, IAppSettingRepository
{
    public AppSettingRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<List<AppSetting>> GetAppSettingByTypeAsync(AppSettingType appSettingType)
    {
        return await _context.AppSettings.Where(aps => aps.AppSettingType == appSettingType).ToListAsync();
    }
}
