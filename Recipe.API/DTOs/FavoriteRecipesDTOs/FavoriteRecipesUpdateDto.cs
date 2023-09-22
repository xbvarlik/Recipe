namespace Recipe.API.DTOs.FavoriteRecipesDTOs;

public class FavoriteRecipesUpdateDto
{
    public int? UserId { get; set; }
    public int? RecipeId { get; set; }
}