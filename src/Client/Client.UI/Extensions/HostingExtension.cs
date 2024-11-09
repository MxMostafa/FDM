

using Client.Infra.DbContexts;
using Client.UI.Forms.DialogForms;
using DevExpress.Xpo.Logger.Transport;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Client.UI.Extensions;

public static class HostingExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services)
    {


        services.AddInfrastructureToDC();
        services.AddDomainToDC();
        services.AddMemoryCache();

        // پیکربندی و ایجاد Logger با استفاده از Serilog
        Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
                             loggingBuilder.AddSerilog(dispose: true));

        return services;
    }

    public static IServiceCollection RegisterForms(this IServiceCollection services)
    {
        services.AddSingleton<Main>();
        services.AddTransient<AppSettingDialogForm>();

        services.AddTransient<AddDownloadNewAddressDialogForm>();
        services.AddTransient<AddDownloadGroupDialogForm>();
        services.AddTransient<AboutProgramDialogForm>();
        services.AddTransient<TestComponentForm>();


        return services;
    }
}
