





using Client.Application.General.Errors;
using Client.Application.Services;
using Client.Domain.Interfaces.General.Errors;
using Client.Domain.Interfaces.Services;

namespace Client.Application.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddApplicationServicesToDC(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAppSettingService, AppSettingService>();
        services.AddScoped<IDownloadFileService, DownloadFileService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IDownloadQueueService, DownloadQueueService>();
        services.AddScoped<IHttpErros, HttpErros>();
        services.AddScoped<IAppErrors, AppErrors>();
        services.AddScoped<IEventManager, EventManager>();
        services.AddSingleton<IEventAggregator, EventAggregator>();
        services.AddScoped<IDownloadManagment, DownloadManagement>();
        services.AddTransient<IDownloadFileChunkService, DownloadFileChunkService>();
        return services;

    }
}
