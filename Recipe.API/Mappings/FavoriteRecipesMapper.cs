using Recipe.API.DTOs.FavoriteRecipesDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class FavoriteRecipesMapper : IBaseMapper<FavoriteRecipes, FavoriteRecipesReadDto, FavoriteRecipesCreateDto, FavoriteRecipesUpdateDto>
{
    public FavoriteRecipes ToEntity(FavoriteRecipesCreateDto dto)
    {
        return new FavoriteRecipes
        {
            RecipeId = dto.RecipeId,
            UserId = dto.UserId
        };
    }

    public FavoriteRecipes ToEntity(FavoriteRecipesUpdateDto dto, FavoriteRecipes entity)
    {
        throw new NotImplementedException();
    }

    public FavoriteRecipesReadDto ToDto(FavoriteRecipes entity)
    {
        return new FavoriteRecipesReadDto
        {
            Id = entity.Id,
            RecipeId = entity.RecipeId,
            UserId = entity.UserId
        };
    }
}