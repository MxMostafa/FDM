


using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;
using Client.Infrastructure.Repositories;
using Client.Persistence.Repositories;

namespace Client.Persistence.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddPersistenceToDC(this IServiceCollection services)
    {

        services.AddScoped<IAppSettingRepository, AppSettingRepository>();
        services.AddScoped<ICategoryGroupRepository, CategoryGroupRepository>();
        services.AddTransient<IDownloadFileChunkReadRepository, DownloadFileChunkReadRepository>();
        services.AddSingleton<IDownloadFileChunkWriteRepository, DownloadFileChunkWriteRepository>();
        services.AddScoped<IDownloadFileReadRepository, DownloadFileReadRepository>();
        services.AddSingleton<IDownloadFileWriteRepository, DownloadFileWriteRepository>();
        services.AddScoped<IDownloadQueueRepository, DownloadQueueRepository>();
        services.AddScoped<IFileTypeGroupRepository, FileTypeGroupRepository>();
        services.AddScoped<IHttpRepository, HttpRepository>();


        var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FDM";

        if (!Directory.Exists(dbPath))
            Directory.CreateDirectory(dbPath);

        AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

        services.AddDbContext<FdmAppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}\\FDMdb.db"),ServiceLifetime.Singleton);

        services.AddDbContext<FdmChunkDbContext>(options =>
         options.UseSqlite($"Data Source={dbPath}\\FDMChunkdb.db"), ServiceLifetime.Transient);

        services.AddDbContext<FdmFileDbContext>(options =>
         options.UseSqlite($"Data Source={dbPath}\\FDMFiledb.db"), ServiceLifetime.Transient);



        var serviceProvider = services.BuildServiceProvider();

        // Ensure the database is created and migrations are applied
        using (var scope = serviceProvider.CreateScope())
        {

            scope.ServiceProvider.GetRequiredService<FdmAppDbContext>().Database.Migrate();
            scope.ServiceProvider.GetRequiredService<FdmFileDbContext>().Database.Migrate();
            scope.ServiceProvider.GetRequiredService<FdmChunkDbContext>().Database.Migrate();
        }

        return services;
    }
}
