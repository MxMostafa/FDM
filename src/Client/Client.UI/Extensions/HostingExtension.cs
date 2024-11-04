

using Client.Domain.Extensions;

namespace Client.UI.Extensions;

public static class HostingExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services )
    {
        services.AddInfrastructureToDC();
        services.AddDomainToDC();
        services.AddMemoryCache();
        return services;
    }
}
