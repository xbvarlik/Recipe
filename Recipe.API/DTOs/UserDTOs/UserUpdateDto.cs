using Recipe.API.DTOs.UserCredentialsDTOs;

namespace Recipe.API.DTOs.UserDTOs;

public class UserUpdateDto
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; } 
    
    public UserCredentialsUpdateDto? UserCredentials { get; set; }
    
    public int? Age { get; set; }
    
    public bool? Gender { get; set; }
}