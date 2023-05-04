using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Phoenix.Auth.Business.Authentication;

internal static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

        authenticationBuilder.AddJwtBearer(opts =>
            {
                opts.MapInboundClaims = true;
                opts.SaveToken = false;
                opts.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Schemes:Bearer:ValidIssuer"],
                    ValidAudience = configuration["Authentication:Schemes:Bearer:ValidAudiences:0"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration["Authentication:Schemes:Bearer:SigningKeys:0:Value"] ?? "")),
                    RoleClaimType = ClaimTypes.Role,
                    NameClaimType = JwtRegisteredClaimNames.Sub
                };
                
                // Let the client choose the scheme via a header. This will 
                // redirect to another. If none was specified we'll use our default scheme.
                opts.ForwardDefaultSelector = context => context.Request.Headers["X-Auth-Scheme"];
            });

        authenticationBuilder.AddGoogle("Apple-Google", options =>
        {
            options.ClientId = configuration["APPLE_GC_ID"] ?? "";
            options.ClientSecret = "get from google page";
        });
        
        authenticationBuilder.AddGoogle("Android-Google", options =>
        {
            options.ClientId = configuration["ANDROID_GC_ID"] ?? "";
            options.ClientSecret = "get from google page";
        });

        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}