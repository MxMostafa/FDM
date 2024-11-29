
namespace Client.Infrastructure.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddInfrastructureToDC(this IServiceCollection services)
    {

        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Client.Infrastructure.Repositories" && t.Name.EndsWith("Repository"))
            .ToList();


        foreach (var type in types)
        {
            if (type.IsAbstract) continue;
            var interfaceType = type.GetInterfaces().First();
            services.AddScoped(interfaceType, type);
        }

        return services;
    }
}
