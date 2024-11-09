


namespace Client.Infra.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddInfrastructureToDC(this IServiceCollection services)
    {

       

        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Client.Infra.Repositories" && t.Name.EndsWith("Repository"))
            .ToList();


        foreach (var type in types)
        {
            if (type.IsAbstract) continue;
            var interfaceType = type.GetInterfaces().First();
            services.AddScoped(interfaceType, type);
        }

        var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\PDM";

        if (!Directory.Exists(dbPath))
            Directory.CreateDirectory(dbPath);

        AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

        var cstr = $"Data Source={dbPath}\\FDMdb.db";
        services.AddDbContext<FdmDbContext>(options =>
            options.UseSqlite(cstr),ServiceLifetime.Transient);

        var serviceProvider = services.BuildServiceProvider();

        // Ensure the database is created and migrations are applied
        using (var scope = serviceProvider.CreateScope())
        {

            var context = scope.ServiceProvider.GetRequiredService<FdmDbContext>();
            context.Database.Migrate(); // Applies any pending migrations
        }

        return services;
    }
}
