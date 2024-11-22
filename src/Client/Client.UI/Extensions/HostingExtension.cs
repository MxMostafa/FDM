



using Client.Application.Extensions;
using Client.Persistence.Extensions;

namespace Client.UI.Extensions;

public static class HostingExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services)
    {
        

        services.AddApplicationServicesToDC();
        services.AddPersistenceToDC();
        services.AddMemoryCache();
        services.AddHttpClient();
        // پیکربندی و ایجاد Logger با استفاده از Serilog
        Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
                             loggingBuilder.AddSerilog(dispose: true));

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, Mapper>();
        return services;
    }

    public static IServiceCollection RegisterForms(this IServiceCollection services)
    {
        services.AddSingleton<Main>();
        services.AddTransient<AppSettingDialogForm>();

        services.AddTransient<AddDownloadNewAddressDialogForm>();
        services.AddTransient<AddDownloadGroupDialogForm>();
        services.AddTransient<AboutProgramDialogForm>();
        services.AddTransient<AddNewDownloadQueueDialogForm>();
        services.AddTransient<DownloadFileInfoDialogForm>();
        services.AddTransient<TestComponentForm>();
        services.AddTransient<AddFileTypeGroupDialogForm>();
        services.AddTransient<LoginFormDialogForm>();
        services.AddTransient<ErrorDialogForm>();
        

        return services;
    }
}
