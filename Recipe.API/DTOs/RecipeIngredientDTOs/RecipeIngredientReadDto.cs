using Recipe.API.DTOs.IngredientDTOs;
using Recipe.API.DTOs.RecipeDTOs;

namespace Recipe.API.DTOs.RecipeIngredientDTOs;

public class RecipeIngredientReadDto
{
    public int Id { get; set; }
    
    public int Amount { get; set; }
    
    public int RecipeId { get; set; }
    
    public int IngredientId { get; set; }
    
    public RecipeReadDto? Recipe { get; set; } 

    public IngredientReadDto? Ingredient { get; set; } 
}