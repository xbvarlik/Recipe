using Recipe.API.DTOs.StepDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class StepMapper : IBaseMapper<Step, StepReadDto, StepCreateDto, StepUpdateDto>
{
    public Step ToEntity(StepCreateDto dto)
    {
        return new Step
        {
            Quantity = dto.Quantity,
            Unit = dto.Unit,
            Description = dto.Description,
            RecipeId = dto.RecipeId,
            IngredientId = dto.IngredientId
        };
    }

    public Step ToEntity(StepUpdateDto dto, Step entity)
    {
        entity.Quantity = dto.Quantity ?? entity.Quantity;
        entity.Unit = dto.Unit ?? entity.Unit;
        entity.Description = dto.Description ?? entity.Description;
        entity.RecipeId = dto.RecipeId ?? entity.RecipeId;
        entity.IngredientId = dto.IngredientId ?? entity.IngredientId;

        return entity;
    }

    public StepReadDto ToDto(Step entity)
    {
        return new StepReadDto
        {
            Quantity = entity.Quantity,
            Unit = entity.Unit,
            Description = entity.Description,
            RecipeId = entity.RecipeId,
            IngredientId = entity.IngredientId,
            Ingredient = new IngredientMapper().ToDto(entity.Ingredient)
        };
    }
}