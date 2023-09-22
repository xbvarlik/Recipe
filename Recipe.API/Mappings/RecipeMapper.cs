using Recipe.API.DTOs.RecipeDTOs;
using RecipeEntity = Recipe.Repository.Entities.Recipe;

namespace Recipe.API.Mappings;

public class RecipeMapper : IBaseMapper<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto>
{
    public RecipeEntity ToEntity(RecipeCreateDto dto)
    {
        return new RecipeEntity
        {
            Name = dto.Name,
            Image = dto.Image,
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
        };
    }

    public RecipeEntity ToEntity(RecipeUpdateDto dto, RecipeEntity entity)
    {
        
        entity.Name = dto.Name ?? entity.Name;
        entity.Image = dto.Image ?? entity.Image;
        entity.CategoryId = dto.CategoryId ?? entity.CategoryId;
        entity.Steps = dto.Steps?.Select(s => new StepMapper().ToEntity(s)).ToList();
        return entity;
    }

    public RecipeReadDto ToDto(RecipeEntity entity)
    {
        return new RecipeReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Image = entity.Image,
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            Steps = entity.Steps?.Select(s => new StepMapper().ToDto(s)).ToList(),
            RecipePointsAndComments = entity.RecipePointsAndComments?.Select(p => 
                new RecipePointsAndCommentsMapper().ToDto(p)).ToList()
        };
    }
}