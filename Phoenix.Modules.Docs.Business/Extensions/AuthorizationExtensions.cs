using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Phoenix.Modules.Docs.Business.Extensions;

internal static class AuthorizationExtensions
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", opts =>
            {
                opts.RequireAuthenticatedUser();
                opts.RequireAssertion(context => context.User.FindAll(ClaimTypes.Role)
                    .Any(x => x.Value == "admin"));
            });
        });
        return services;
    }
}