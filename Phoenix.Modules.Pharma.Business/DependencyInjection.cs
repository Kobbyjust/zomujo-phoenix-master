using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.Pharma.Data;

namespace Phoenix.Modules.Pharma.Business;

public static class DependencyInjection
{
    public static IServiceCollection InstallPharma(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }
}