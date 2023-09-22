using Recipe.API.DTOs.IngredientDTOs;
using Recipe.API.DTOs.RecipeIngredientDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class RecipeIngredientMapper : IBaseMapper<RecipeIngredient, RecipeIngredientReadDto, RecipeIngredientCreateDto, RecipeIngredientUpdateDto>
{
    public RecipeIngredient ToEntity(RecipeIngredientCreateDto dto)
    {
        return new RecipeIngredient
        {
            Amount = dto.Amount,
            IngredientId = dto.IngredientId
        };
    }

    public RecipeIngredient ToEntity(RecipeIngredientUpdateDto dto, RecipeIngredient entity)
    {
        entity.Amount = dto.Amount ?? entity.Amount;
        entity.IngredientId = dto.IngredientId ?? entity.IngredientId;

        return entity;
    }

    public RecipeIngredientReadDto ToDto(RecipeIngredient entity)
    {
        return new RecipeIngredientReadDto
        {
            Id = entity.Id,
            Amount = entity.Amount,
            Ingredient = new IngredientMapper().ToDto(entity.Ingredient)
        };
    }
}