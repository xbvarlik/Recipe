using Recipe.API.DTOs.RecipeDTOs;

namespace Recipe.API.DTOs.CategoryDTOs;

public class CategoryReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public virtual ICollection<RecipeReadDto>? Recipes { get; set; } 
}