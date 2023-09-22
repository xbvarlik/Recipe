namespace Recipe.API.DTOs.FavoriteRecipesDTOs;

public class FavoriteRecipesReadDto
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
}