





namespace Client.Domain.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddDomainToDC(this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "FDM.Client.Domain.Services" && t.Name.EndsWith("Service"))
            .ToList();


        foreach (var type in types)
        {
            var interfaceType = type.GetInterfaces().First();
            services.AddScoped(interfaceType, type);
        }

        return services;

    }
}
