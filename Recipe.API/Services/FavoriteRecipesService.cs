using Recipe.API.DTOs.FavoriteRecipesDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class FavoriteRecipesService : GenericService<FavoriteRecipes, FavoriteRecipesReadDto, FavoriteRecipesCreateDto, FavoriteRecipesUpdateDto>
{
    public FavoriteRecipesService(AppDbContext context, FavoriteRecipesMapper mapper) : base(context, mapper)
    {
    }
}