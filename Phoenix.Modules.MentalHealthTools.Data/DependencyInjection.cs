﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Modules.MentalHealthTools.Data.Installers;
using Phoenix.Shared.Persistence.Interceptors;

namespace Phoenix.Modules.MentalHealthTools.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MhToolsDbContext>((sp, options) =>
        {
            var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
            var saveChangesInterceptor = sp.GetService<AuditEntitiesInterceptor>();
            options.UseNpgsql(configuration.GetConnectionString("Default"), opt =>
            {
                opt.EnableRetryOnFailure();
                opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            }).AddInterceptors(interceptor!, saveChangesInterceptor!);
            //options.EnableSensitiveDataLogging();
        }).AddDbHealthChecks();
        return services;
    }

    private static IServiceCollection AddDbHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<DbHealthCheckInstaller>("MhToolsDbContext");
        return services;
    }
}