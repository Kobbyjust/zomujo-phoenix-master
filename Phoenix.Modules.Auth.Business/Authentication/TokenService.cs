using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Modules.Auth.Data.Users;

namespace Phoenix.Auth.Business.Authentication;

internal class TokenService : ITokenService
{
    private readonly string _issuer;
    private readonly SigningCredentials _jwtSigningCredentials;
    private readonly Claim[] _audiences;

    public TokenService(IAuthenticationConfigurationProvider authenticationConfigurationProvider)
    {
        var bearerSection = authenticationConfigurationProvider
            .GetSchemeConfiguration(JwtBearerDefaults.AuthenticationScheme);
        var section = bearerSection.GetSection("SigningKeys:0");
        
        _issuer = bearerSection["ValidIssuer"] ?? throw new InvalidOperationException("Issuer is not specified");
        var signingKey = section["Value"] ?? throw new InvalidOperationException("Signing key is not specified");

        var signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);

        _jwtSigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKeyBytes),
            SecurityAlgorithms.HmacSha256Signature);

        _audiences = bearerSection.GetSection("ValidAudiences").GetChildren()
            .Where(s => !string.IsNullOrEmpty(s.Value))
            .Select(s => new Claim(JwtRegisteredClaimNames.Aud, s.Value!))
            .ToArray();
    }


    public AuthToken GenerateToken(OneOf<User, Doctor, Counsellor, Pharmacy> user)
    {
        var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);

        if (user.IsT0)
        {
            var person = user.AsT0;
            identity.AddClaims(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, person.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.NameId, person.Id),
                new Claim(JwtRegisteredClaimNames.FamilyName, person.LastName),
                new Claim(JwtRegisteredClaimNames.GivenName, person.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, person.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, person.PhoneNumber ?? ""),
            });   
        }

        if (user.IsT1)
        {
            var doctor = user.AsT1;
            identity.AddClaims(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, doctor.FullName ?? ""),
                new Claim(JwtRegisteredClaimNames.NameId, doctor.Id ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, doctor.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, doctor.Phone ?? ""),
                new Claim(ClaimTypes.Role, "doctor")
            });
        }

        if (user.IsT2)
        {
            var counsellor = user.AsT2;
            identity.AddClaims(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, counsellor.FullName ?? ""),
                new Claim(JwtRegisteredClaimNames.NameId, counsellor.Id ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, counsellor.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, counsellor.Phone ?? ""),
                new Claim(ClaimTypes.Role, "counsellor")
            });
        }

        if (user.IsT3)
        {
            var pharmacy = user.AsT3;
            identity.AddClaims(new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, pharmacy.Name ?? ""),
                new Claim(JwtRegisteredClaimNames.NameId, pharmacy.Id ?? ""),
                new Claim(JwtRegisteredClaimNames.Email, pharmacy.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, pharmacy.Phone ?? ""),
                new Claim(ClaimTypes.Role, "pharmacy")
            });
        }

        // TODO:: implement Roles store
        //var roles = await _userManager.GetRolesAsync(user);
        
        // foreach (var role in roles)
        // {
        //     identity.AddClaim(new Claim(ClaimTypes.Role, role));
        // }
        
        var id = Guid.NewGuid().ToString().GetHashCode().ToString("x", CultureInfo.InvariantCulture);
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, id));

        identity.AddClaims(_audiences);
        
        var handler = new JwtSecurityTokenHandler();

        var jwtToken = handler.CreateJwtSecurityToken(
            _issuer,
            audience: null,
            identity,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(30),
            issuedAt: DateTime.UtcNow,
            _jwtSigningCredentials);

        return new AuthToken(handler.WriteToken(jwtToken));
    }
}

public interface ITokenService
{
    AuthToken GenerateToken(OneOf<User, Doctor, Counsellor, Pharmacy> user);
}

public record AuthToken(string Token);