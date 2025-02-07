

using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories;
public class AppSettingRepository : BaseAppRepository, IAppSettingRepository
{
    private readonly IMemoryCache _memoryCache;
    private const string APP_SETTING_KEY = "AppSettings";

    public AppSettingRepository(FdmAppDbContext context, IMemoryCache memoryCache) : base(context)
    {
        _memoryCache = memoryCache;
    }

    public async Task<List<AppSetting>> GetAppSettingByTypeAsync(AppSettingType appSettingType)
    {
        var appSettings = await GetAppSettingsAsync();

        return appSettings.Where(ap => ap.AppSettingType == appSettingType).ToList();
    }

    public async Task<AppSetting> AddAppSettingAsync(AppSetting appSetting)
    {
        await _context.AppSettings.AddAsync(appSetting);
        await _context.SaveChangesAsync();
        await GetAppSettingsAsync(true);

        return appSetting;
    }

    public async Task<AppSetting> UpdateAppSettingAsync(AppSetting appSetting)
    {
        _context.AppSettings.Update(appSetting);
        await _context.SaveChangesAsync();
        await GetAppSettingsAsync(true);

        return appSetting;
    }

    public async Task<List<AppSetting>> UpdateAppSettingAsync(List<AppSetting> appSettings)
    {
        _context.AppSettings.UpdateRange(appSettings);
        await _context.SaveChangesAsync();
        await GetAppSettingsAsync(true);

        return appSettings;
    }


    public async Task<List<AppSetting>> AddAppSettingAsync(List<AppSetting> appSettings)
    {
        await _context.AppSettings.AddRangeAsync(appSettings);
        await _context.SaveChangesAsync();
        await GetAppSettingsAsync(true);

        return appSettings;
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

    public async Task<AppSetting?> GetAppSettingByTypeAndKeyAsync(AppSettingType appSettingType, string key)
    {
        return await _context.AppSettings.FirstOrDefaultAsync(ap => ap.AppSettingType == appSettingType && ap.Key == key);
    }

    public async Task<AppSetting?> GetAppSettingByKeyAsync(string key)
    {
        return await _context.AppSettings.FirstOrDefaultAsync(ap =>ap.Key == key);
    }
}
