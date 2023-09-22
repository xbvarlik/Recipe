namespace Recipe.API.DTOs.StepDTOs;

public class StepUpdateDto
{
    public int? Quantity { get; set; }
    
    public string? Unit { get; set; } 
    
    public string? Description { get; set; } 
    
    public int? RecipeId { get; set; }
    
    public int? IngredientId { get; set; }
}