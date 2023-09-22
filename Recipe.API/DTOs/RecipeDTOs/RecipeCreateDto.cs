using Recipe.API.DTOs.RecipeIngredientDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeCreateDto
{
    public string Name { get; set; } = null!;
    
    public string RecipeDetails { get; set; } = null!;
    
    public string? Image { get; set; }
    
    public int CategoryId { get; set; }
    
    public ICollection<RecipeIngredientReadDto>? RecipeIngredients { get; set; } 
}