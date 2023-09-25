using Recipe.API.DTOs.UserCredentialsDTOs;

namespace Recipe.API.DTOs.UserDTOs;

public class UserCreateDto
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public UserCredentialsCreateDto UserCredentials { get; set; } = null!;
    
    public int Age { get; set; }
    
    public bool Gender { get; set; }
}