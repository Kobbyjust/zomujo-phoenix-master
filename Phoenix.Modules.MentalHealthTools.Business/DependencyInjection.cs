using Microsoft.Extensions.Configuration;
using Phoenix.Modules.MentalHealthTools.Business.Extensions;

namespace Phoenix.Modules.MentalHealthTools.Business;

public static class DependencyInjection
{
    public static IServiceCollection InstallMhTools(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorizationPolicies()
            .AddPersistence(configuration);
        return services;
    }
}