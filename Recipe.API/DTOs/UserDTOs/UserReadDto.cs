using Recipe.API.DTOs.FavoriteRecipesDTOs;
using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.DTOs.RecipePointAndCommentDTOs;

namespace Recipe.API.DTOs.UserDTOs;

public class UserReadDto
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
    
    public int Age { get; set; }
    
    public bool Gender { get; set; }
    
    public virtual ICollection<FavoriteRecipesReadDto>? FavoriteRecipes { get; set; } 
    
    public virtual ICollection<RecipePointsAndCommentsReadDto>? RecipePointsAndComments { get; set; }

    public virtual ICollection<RecipeReadDto>? Recipes { get; set; } 
}