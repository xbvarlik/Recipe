using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using RecipeEntity = Recipe.Repository.Entities.Recipe;

namespace Recipe.API.Services;

public class RecipeService : GenericService<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto>
{
    public RecipeService(AppDbContext context, IBaseMapper<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto> mapper) : base(context, mapper)
    {
    }
    
    
}