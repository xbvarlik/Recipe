using Recipe.API.DTOs.IngredientDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class IngredientMapper : IBaseMapper<Ingredient, IngredientReadDto, IngredientCreateDto, IngredientUpdateDto>
{
    public Ingredient ToEntity(IngredientCreateDto dto)
    {
        return new Ingredient
        {
            Name = dto.Name
        };
    }

    public Ingredient ToEntity(IngredientUpdateDto dto, Ingredient entity)
    {
        entity.Name = dto.Name ?? entity.Name;

        return entity;
    }

    public IngredientReadDto ToDto(Ingredient entity)
    {
        return new IngredientReadDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}