using Recipe.API.DTOs.RecipeIngredientDTOs;
using Recipe.API.DTOs.RecipePointAndCommentDTOs;

namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeReadDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string RecipeDetails { get; set; } = null!;
    
    public string? Image { get; set; }
    
    public int UserId { get; set; }
    
    public int CategoryId { get; set; }
    
    public ICollection<RecipeIngredientReadDto>? RecipeIngredients { get; set; } 
    
    public ICollection<RecipePointsAndCommentsReadDto>? RecipePointsAndComments { get; set; } 
}