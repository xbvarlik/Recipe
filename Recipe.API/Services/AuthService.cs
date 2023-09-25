using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
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
    
    public AuthService(AppDbContext context, UserMapper userMapper, UserCredentialsMapper userCredentialsMapper)
    {
        _context = context;
        _userMapper = userMapper;
        _userCredentialsMapper = userCredentialsMapper;
    }
    
    public async Task<UserReadDto> Register(UserCreateDto dto)
    {
        var user = _userMapper.ToEntity(dto);
        var userCredentials = _userCredentialsMapper.ToEntity(dto.UserCredentials);
        user.UserCredentials = userCredentials;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return _userMapper.ToDto(user);
    }
    
    public async Task<UserReadDto> Login(UserCredentialsCreateDto dto)
    {
        var user = await _context.Users
            .Include(x => x.UserCredentials)
            .FirstOrDefaultAsync(x => x.UserCredentials.Email == dto.Email);
        
        if (user == null) throw new InvalidCredentialException("User not found");
        
        if (!AuthHelpers.VerifyPasswordHash(dto.Password, user.UserCredentials.PasswordHash,
                user.UserCredentials.PasswordSalt))
            throw new InvalidCredentialException("Invalid password");
        
        return _userMapper.ToDto(user);
    }

    public async Task<UserReadDto> ChangePassword(UserCredentialsUpdateDto dto)
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
}