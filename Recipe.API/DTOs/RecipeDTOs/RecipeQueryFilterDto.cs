namespace Recipe.API.DTOs.RecipeDTOs;

public class RecipeQueryFilterDto
{
    public string? RecipeNameFilter { get; set; }

    public int? UserIdFilter { get; set; }
}