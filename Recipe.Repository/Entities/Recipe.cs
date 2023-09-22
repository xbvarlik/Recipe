using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class Recipe : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public string? Image { get; set; }
    
    public int UserId { get; set; }
    
    public virtual User? User { get; set; } 
    
    public int CategoryId { get; set; }
    
    public virtual Category? Category { get; set; } 
    
    public virtual ICollection<FavoriteRecipes>? FavoriteRecipes { get; set; }
    
    public virtual ICollection<Step>? Steps { get; set; }
    
    public virtual ICollection<RecipePointsAndComments>? RecipePointsAndComments { get; set; } 
    
}