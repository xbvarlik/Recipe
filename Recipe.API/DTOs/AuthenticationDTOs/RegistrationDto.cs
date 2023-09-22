﻿namespace Recipe.API.DTOs.AuthenticationDTOs;

public class RegistrationDto
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public int Age { get; set; }
    
    public bool Gender { get; set; }
}