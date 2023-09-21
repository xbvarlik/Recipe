using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class FavoriteRecipes : BaseEntity
{
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual User User { get; set; } = null!;
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual Recipe Recipe { get; set; } = null!;
}