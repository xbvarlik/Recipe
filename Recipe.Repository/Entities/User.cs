using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public int Age { get; set; }
    
    public bool Gender { get; set; }
    
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual ICollection<FavoriteRecipes?> FavoriteRecipes { get; set; } = null!;
    
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual ICollection<RecipePointsAndComments?> RecipePointsAndComments { get; set; } = null!;

    public virtual ICollection<Recipe?> Recipes { get; set; } = null!;
    
}