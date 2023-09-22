using Recipe.API.DTOs.IngredientDTOs;

namespace Recipe.API.DTOs.StepDTOs;

public class StepReadDto
{
    public int Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public int RecipeId { get; set; }
    
    public int IngredientId { get; set; }
    
    public IngredientReadDto? Ingredient { get; set; }
}