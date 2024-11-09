

namespace Client.Infra.Repositories;
public class AppSettingRepository : BaseRepository, IAppSettingRepository
{
    private readonly IMemoryCache _memoryCache;
    private const string APP_SETTING_KEY = "AppSettings";

    public AppSettingRepository(FdmDbContext context, IMemoryCache memoryCache) : base(context)
    {
        _memoryCache = memoryCache;
    }

    public async Task<List<AppSetting>> GetAppSettingByTypeAsync(AppSettingType appSettingType)
    {
        var appSettings = await GetAppSettingsAsync();

        return appSettings.Where(ap => ap.AppSettingType == appSettingType).ToList();
    }


    private async Task<List<AppSetting>> GetAppSettingsAsync(bool resetCache = false)
    {
        if (resetCache || !_memoryCache.TryGetValue(APP_SETTING_KEY, out List<AppSetting>? appSettings))
        {
            appSettings = await _context.AppSettings.ToListAsync();

            // add to memoryCache
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1),
                SlidingExpiration = TimeSpan.FromHours(1)
            };

            _memoryCache.Set(APP_SETTING_KEY, appSettings, cacheOptions);
        }


        return appSettings!;
    }

}
