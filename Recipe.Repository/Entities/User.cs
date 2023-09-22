﻿using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public int Age { get; set; }
    
    public bool Gender { get; set; }
    
    public virtual ICollection<FavoriteRecipes>? FavoriteRecipes { get; set; } 
    
    public virtual ICollection<RecipePointsAndComments>? RecipePointsAndComments { get; set; }

    public virtual ICollection<Recipe>? Recipes { get; set; } 
    
}