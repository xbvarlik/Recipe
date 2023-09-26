using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Recipe.API.Helpers;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class TokenService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    
    public TokenService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<string> CreateToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.FirstName)
        };
        
        var secret = _configuration["SecretKey"];
        
        if(secret == null) throw new SecurityTokenException("Secret key is null");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var expirationDate = DateTime.Now.AddDays(1);
        var token = new JwtSecurityToken(claims: claims, expires: expirationDate, signingCredentials: signingCredentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        var tokenEntity = new Tokens
        {
            Token = jwt,
            Status = true
        };
        
        _context.Tokens.Add(tokenEntity);
        await _context.SaveChangesAsync();

        return jwt;
    }
    
    public async Task RevokeToken(string token)
    {
        var tokenEntity = _context.Tokens.FirstOrDefault(x => x.Token == token);

        if (tokenEntity == null) return;
        
        tokenEntity.Status = false;
        _context.Tokens.Remove(tokenEntity);
        await _context.SaveChangesAsync();
    }
}