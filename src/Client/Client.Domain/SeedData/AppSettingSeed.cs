

namespace Client.Domain.SeedData;

public static class AppSettingSeed
{
    public static IEnumerable<AppSetting> GetSeedData()
    {
        string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        return new List<AppSetting>
    {
        new AppSetting {  AppSettingType=AppSettingType.General,Key=AppSettingConfigs.TempSavePath,Value=$"{roamingPath}\\FDM",Id=1 },
    };
    }
}
