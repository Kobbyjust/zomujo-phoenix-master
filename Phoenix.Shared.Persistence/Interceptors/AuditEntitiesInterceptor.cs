using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Phoenix.Shared.Persistence.Interceptors;

public sealed class AuditEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly HttpContext? _httpContext;
    public AuditEntitiesInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }
    
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var dbContext = eventData.Context;
        if (dbContext is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        var username = _httpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (string.IsNullOrEmpty(username)) username = "admin";
        
        foreach (var entry in dbContext.ChangeTracker.Entries()
                     .Where(x => x.State is EntityState.Added or EntityState.Modified))
        {
            if (entry.Entity is Entity entity)
            {
                entity.Audit ??= Audit.Create();
                entity.Audit.WasUpdatedBy(username);
            }
        }
        
        foreach (var entry in dbContext.ChangeTracker.Entries()
                     .Where(x => x.State is EntityState.Deleted))
        {
            if (entry.Entity is not Entity entity) continue;
            entity.Audit?.WasUpdatedBy(username);
            entity.Audit?.Delete();
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}