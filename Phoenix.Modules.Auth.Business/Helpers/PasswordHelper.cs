using System.Security.Cryptography;
using System.Text;

namespace Phoenix.Auth.Business.Helpers;

internal static class PasswordHelper
{
    internal static (byte[], byte[]) GetPasswordInfo(string password)
    {
        byte[] passwordHash, passwordKey;

        using (var hmac = new HMACSHA512())
        {
            passwordKey = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        return (passwordHash, passwordKey);
    }

    internal static bool MatchPasswordHash(string passwordText, IReadOnlyList<byte> password, byte[] passwordKey)
    {
        using var hmac = new HMACSHA512(passwordKey);
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));
        return !passwordHash.Where((t, i) => t != password[i]).Any();
    }
}