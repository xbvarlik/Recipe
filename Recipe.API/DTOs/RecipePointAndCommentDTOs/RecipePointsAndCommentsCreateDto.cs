namespace Recipe.API.DTOs.RecipePointAndCommentDTOs;

public class RecipePointsAndCommentsCreateDto
{
    public int Points { get; set; }
    
    public string Comment { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
}