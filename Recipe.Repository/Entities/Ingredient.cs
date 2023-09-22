using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public virtual ICollection<RecipeIngredient>? RecipeIngredients { get; set; }
}