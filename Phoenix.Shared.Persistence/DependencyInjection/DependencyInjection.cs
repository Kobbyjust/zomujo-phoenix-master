using Microsoft.Extensions.DependencyInjection;
using Phoenix.Shared.Persistence.Interceptors;

namespace Phoenix.Shared.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedPersistence(this IServiceCollection services)
    {
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();
        services.AddSingleton<AuditEntitiesInterceptor>();

        return services;
    }
}