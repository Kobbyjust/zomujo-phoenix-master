namespace Phoenix.Modules.MentalHealthTools.Business.Extensions;

public static class AuthorizationExtensions
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