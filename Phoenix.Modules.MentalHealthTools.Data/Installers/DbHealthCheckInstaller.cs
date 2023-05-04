using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Phoenix.Modules.MentalHealthTools.Data.Installers;

public class DbHealthCheckInstaller : IHealthCheck
{
    private readonly MhToolsDbContext _dbContext;

    public DbHealthCheckInstaller(MhToolsDbContext dbContext)
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