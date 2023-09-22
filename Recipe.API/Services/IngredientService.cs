using Recipe.API.DTOs.IngredientDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class IngredientService : GenericService<Ingredient, IngredientReadDto, IngredientCreateDto, IngredientUpdateDto>
{
    public IngredientService(AppDbContext context, IBaseMapper<Ingredient, IngredientReadDto, IngredientCreateDto, IngredientUpdateDto> mapper) : base(context, mapper)
    {
    }
}