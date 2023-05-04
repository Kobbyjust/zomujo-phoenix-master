using Microsoft.Extensions.Diagnostics.HealthChecks;
using Phoenix.Modules.Auth.Data.DataContext;

namespace Phoenix.Modules.Auth.Data.Installers;

public class DbHealthCheckInstaller : IHealthCheck
{
    private readonly AuthDbContext _dbContext;

    public DbHealthCheckInstaller(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await _dbContext.Database.CanConnectAsync(cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (System.Exception ex)
        {
            return HealthCheckResult.Unhealthy($"Failed to query the DbContext. Error: {ex.Message}");
        }
    }
}