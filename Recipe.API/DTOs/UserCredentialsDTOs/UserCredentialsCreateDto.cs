namespace Recipe.API.DTOs.UserCredentialsDTOs;

public class UserCredentialsCreateDto
{
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
}