using Recipe.API.DTOs.RecipeDTOs;

namespace Recipe.API.DTOs.CategoryDTOs;

public class CategoryReadDto
{
    public string Name { get; set; } = null!;
    
    public virtual ICollection<RecipeReadDto>? Recipes { get; set; } 
}