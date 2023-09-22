using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class FavoriteRecipes : BaseEntity
{
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
    
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual User? User { get; set; } 
    
    public virtual Recipe? Recipe { get; set; } 
}