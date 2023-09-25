using Recipe.API.DTOs.StepDTOs;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeUpdateDto
{
    public string? Name { get; set; } 
    
    public byte[]? Image { get; set; }
    
    public int? CategoryId { get; set; }
    
}