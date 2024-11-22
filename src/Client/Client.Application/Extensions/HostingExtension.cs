





namespace Client.Application.Extensions;

public static class HostingExtension
{
    public static IServiceCollection AddApplicationServicesToDC(this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Client.Application.Services" && t.Name.EndsWith("Service"))
            .ToList();


        foreach (var type in types)
        {
            var interfaceType = type.GetInterfaces().First();
            services.AddScoped(interfaceType, type);
        }

        return services;

    }
}
