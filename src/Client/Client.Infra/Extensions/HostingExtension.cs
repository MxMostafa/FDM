


namespace Client.Infra.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddInfrastructureToDC(this IServiceCollection services)
    {

        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "FDM.Client.Infra.Repositories" && t.Name.EndsWith("Repository"))
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

        services.AddDbContext<FdmDbContext>(options =>
            options.UseSqlite($"{dbPath}\\FDMdb.db"));

        return services;
    }
}
