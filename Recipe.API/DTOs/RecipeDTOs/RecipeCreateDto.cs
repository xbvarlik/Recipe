using Recipe.API.DTOs.StepDTOs;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeCreateDto
{
    public string Name { get; set; } = null!;
    
    public IFormFile? Image { get; set; }
    
    public int UserId { get; set; } 
    
    public int CategoryId { get; set; }
    
}