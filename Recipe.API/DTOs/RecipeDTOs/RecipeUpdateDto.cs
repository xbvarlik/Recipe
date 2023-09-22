using Recipe.API.DTOs.StepDTOs;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeUpdateDto
{
    public string? Name { get; set; } 

    public string? RecipeDetails { get; set; }

    public string? Image { get; set; }
    
    public int? CategoryId { get; set; }
    
    public ICollection<StepCreateDto>? Steps { get; set; } 
}