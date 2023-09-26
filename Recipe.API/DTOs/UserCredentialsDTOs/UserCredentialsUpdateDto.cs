namespace Recipe.API.DTOs.UserCredentialsDTOs;

public class UserCredentialsUpdateDto
{
    public string Email { get; set; } = null!;
    
    public string OldPassword { get; set; } = null!;
    
    public string NewPassword { get; set; } = null!;
}