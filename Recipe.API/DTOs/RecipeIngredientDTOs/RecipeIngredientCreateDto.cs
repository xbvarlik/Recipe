namespace Recipe.API.DTOs.RecipeIngredientDTOs;

public class RecipeIngredientCreateDto
{
    public int Amount { get; set; }
    
    public int RecipeId { get; set; }
    
    public int IngredientId { get; set; }
}

