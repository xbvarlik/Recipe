using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class RecipeIngredient : BaseEntity
{
    public int Amount { get; set; }
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Ingredient Ingredient { get; set; } = null!;
}