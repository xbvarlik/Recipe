using Recipe.API.DTOs.StepDTOs;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeCreateDto
{
    public string Name { get; set; } = null!;
    
    public string RecipeDetails { get; set; } = null!;
    
    public string? Image { get; set; }
    
    public int UserId { get; set; } 
    
    public int CategoryId { get; set; }
    
    public ICollection<StepCreateDto>? Steps { get; set; }  
}