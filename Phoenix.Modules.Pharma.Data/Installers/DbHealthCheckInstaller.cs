using Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Phoenix.Modules.Pharma.Data.Installers;

public class DbHealthCheckInstaller : IHealthCheck
{
    private readonly PharmaDbContext _dbContext;

    public DbHealthCheckInstaller(PharmaDbContext dbContext)
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