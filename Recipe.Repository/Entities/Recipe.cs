using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class Recipe : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public string RecipeDetails { get; set; } = null!;
    
    public byte[]? Image { get; set; }
    
    public int UserId { get; set; }
    
    public virtual User User { get; set; } = null!;
    
    public int CategoryId { get; set; }
    
    public virtual Category Category { get; set; } = null!;
    
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual ICollection<FavoriteRecipes?> FavoriteRecipes { get; set; } = null!;
    
    public virtual ICollection<RecipeIngredient?> RecipeIngredients { get; set; } = null!;
    
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual ICollection<RecipePointsAndComments?> RecipePointsAndComments { get; set; } = null!;
    
}