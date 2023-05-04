using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.Auth.Data.DataContext;
using Phoenix.Shared.Persistence.Interceptors;

namespace Phoenix.Modules.Auth.Data.Installers;

public static class PersistenceInstaller
{
    public static IServiceCollection InstallPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AuthDbContext>((sp, options) =>
            {
                var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
                var saveChangesInterceptor = sp.GetService<AuditEntitiesInterceptor>();
                options.UseNpgsql(configuration.GetConnectionString("Default"))
                    .AddInterceptors(interceptor!, saveChangesInterceptor!);
                options.EnableSensitiveDataLogging();
            })
            .AddDbHealthChecks();
        return services;
    }
    
    private static IServiceCollection AddDbHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<DbHealthCheckInstaller>("AuthDbContext");
        return services;
    }
}