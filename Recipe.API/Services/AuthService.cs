using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.UserCredentialsDTOs;
using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Helpers;
using Recipe.API.Mappings;
using Recipe.Repository;

namespace Recipe.API.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly UserMapper _userMapper;
    private readonly UserCredentialsMapper _userCredentialsMapper;
    private readonly TokenService _tokenService;
    
    public AuthService(AppDbContext context, UserMapper userMapper, UserCredentialsMapper userCredentialsMapper, TokenService tokenService)
    {
        _context = context;
        _userMapper = userMapper;
        _userCredentialsMapper = userCredentialsMapper;
        _tokenService = tokenService;
    }
    
    public async Task<UserReadDto> RegisterAsync(UserCreateDto dto)
    {
        var user = _userMapper.ToEntity(dto);
        var userCredentials = _userCredentialsMapper.ToEntity(dto.UserCredentials);
        user.UserCredentials = userCredentials;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return _userMapper.ToDto(user);
    }
    
    public async Task<string> LoginAsync(UserCredentialsCreateDto dto)
    {
        var user = await _context.Users
            .Include(x => x.UserCredentials)
            .FirstOrDefaultAsync(x => x.UserCredentials.Email == dto.Email);
        
        if (user == null) throw new InvalidCredentialException("User not found");
        
        if (!AuthHelpers.VerifyPasswordHash(dto.Password, user.UserCredentials.PasswordHash,
                user.UserCredentials.PasswordSalt))
            throw new InvalidCredentialException("Invalid password");

        var token = await _tokenService.CreateToken(user);
        if (token == null)
            throw new SecurityTokenException("Token creation failed");
        
        return token;
    }

    public async Task<UserReadDto> ChangePasswordAsync(UserCredentialsUpdateDto dto)
    {
        var user = await _context.Users
            .Include(x => x.UserCredentials)
            .FirstOrDefaultAsync(x => x.UserCredentials.Email == dto.Email);
        
        if (user == null) throw new InvalidCredentialException("User not found");
        
        if (!AuthHelpers.VerifyPasswordHash(dto.OldPassword, user.UserCredentials.PasswordHash,
                user.UserCredentials.PasswordSalt))
            throw new InvalidCredentialException("Invalid old password");
        
        var userCredentials = _userCredentialsMapper.ToEntity(dto, user.UserCredentials);
        user.UserCredentials = userCredentials;
        await _context.SaveChangesAsync();
        return _userMapper.ToDto(user);
    }

    public async Task<UserReadDto> DeleteAccountAsync(UserCredentialsCreateDto dto, string token)
    {
        var user = await _context.Users
            .Include(x => x.UserCredentials)
            .FirstOrDefaultAsync(x => x.UserCredentials.Email == dto.Email);

        if (user == null) throw new InvalidCredentialException("User not found");

        if (!AuthHelpers.VerifyPasswordHash(dto.Password, user.UserCredentials.PasswordHash,
                user.UserCredentials.PasswordSalt))
            throw new InvalidCredentialException("Invalid password");

        await LogoutAsync(token);
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return _userMapper.ToDto(user);
    }
    
    public async Task<NoContentDto> LogoutAsync(string token)
    {
        await _tokenService.RevokeToken(token);
        return new NoContentDto();
    }
}