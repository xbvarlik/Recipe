using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.DTOs.UserDTOs;

namespace Recipe.API.DTOs.RecipePointAndCommentDTOs;

public class RecipePointsAndCommentsReadDto
{
    public int Id { get; set; }
    
    public int Points { get; set; }
    
    public string Comment { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
    
    public UserReadDto? User { get; set; } 
    
    public RecipeReadDto? Recipe { get; set; }
}