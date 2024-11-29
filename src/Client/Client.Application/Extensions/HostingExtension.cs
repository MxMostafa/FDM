





using Client.Application.General.Errors;
using Client.Domain.Interfaces.General.Errors;

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


        services.AddScoped<IHttpErros, HttpErros>();
        services.AddScoped<IAppErrors, AppErrors>();
        return services;

    }
}
