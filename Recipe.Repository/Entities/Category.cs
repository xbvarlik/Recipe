using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public virtual ICollection<Recipe?> Recipes { get; set; } = null!;
}