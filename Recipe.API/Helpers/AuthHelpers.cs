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
    
    public static bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using HMACSHA512 hmac = new(salt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(hash);
    }
}