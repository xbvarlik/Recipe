namespace Recipe.API.DTOs.UserDTOs;

public class UserUpdateDto
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; } 
    
    public string? Email { get; set; } 
    
    public string? Password { get; set; }
    
    public int? Age { get; set; }
    
    public bool? Gender { get; set; }
}