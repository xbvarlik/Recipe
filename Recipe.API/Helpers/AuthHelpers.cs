using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Recipe.Repository.Entities;

namespace Recipe.API.Helpers;

public static class AuthHelpers
{
    public static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using HMACSHA512 hmac = new();
        salt = hmac.Key;
        hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public static string CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.FirstName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var expirationDate = DateTime.Now.AddDays(1);
        var token = new JwtSecurityToken(claims: claims, expires: expirationDate, signingCredentials: signingCredentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        if (Constants.InvalidatedTokens != null && Constants.InvalidatedTokens.Contains(jwt))
            return null;

        return jwt;
    }
    
    public static void Revoke(string token)
    {
        if (Constants.InvalidatedTokens == null)
            Constants.InvalidatedTokens = new HashSet<string>();

        Constants.InvalidatedTokens.Add(token);
    }
    
    public static bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using HMACSHA512 hmac = new(salt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(hash);
    }
}