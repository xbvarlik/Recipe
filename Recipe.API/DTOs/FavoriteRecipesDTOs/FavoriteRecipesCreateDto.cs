namespace Recipe.API.DTOs.FavoriteRecipesDTOs;

public class FavoriteRecipesCreateDto
{
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
}