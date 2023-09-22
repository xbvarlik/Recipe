namespace Recipe.API.DTOs.AuthenticationDTOs;

public class ChangePasswordDto
{
    public string Email { get; set; } = null!;
    
    public string OldPassword { get; set; } = null!;
    
    public string NewPassword { get; set; } = null!;
}