using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Recipe.API.DTOs.CommunicationDTOs;
using Recipe.API.DTOs.UserCredentialsDTOs;
using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Services;

namespace Recipe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserCreateDto dto)
    {
        var user = await _authService.RegisterAsync(dto);
        return CreateActionResult(ResponseDto<UserReadDto>.Success(201, user));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(UserCredentialsCreateDto dto)
    {
        var token = await _authService.LoginAsync(dto);
        return CreateActionResult(ResponseDto<string>.Success(200, token));
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        string? token = Request.Headers["Authorization"].ToString()?.Replace("Bearer ", string.Empty);

        if (token == null) throw new SecurityTokenException("Token not found");
        
        await _authService.LogoutAsync(token);
        return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
    }
    
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(UserCredentialsUpdateDto dto)
    {
        var user = await _authService.ChangePasswordAsync(dto);
        return CreateActionResult(ResponseDto<UserReadDto>.Success(200, user));
    }
    
    [HttpDelete("delete-account")]
    public async Task<IActionResult> DeleteAccountAsync(UserCredentialsCreateDto dto)
    {
        string? token = Request.Headers["Authorization"].ToString()?.Replace("Bearer ", string.Empty);

        if (token == null) throw new SecurityTokenException("Token not found");
        
        await _authService.DeleteAccountAsync(dto, token);
        return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
    }
}