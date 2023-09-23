using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.Helpers;
using RecipeEntity = Recipe.Repository.Entities.Recipe;

namespace Recipe.API.Mappings;

public class RecipeMapper : IBaseMapper<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto>
{
    public RecipeEntity ToEntity(RecipeCreateDto dto)
    {
        return new RecipeEntity
        {
            Name = dto.Name,
            Image = ImageHandler.SaveImageToLocalStorage(dto.Image, Constants.RecipeImageFolder),
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
        };
    }

    public RecipeEntity ToEntity(RecipeUpdateDto dto, RecipeEntity entity)
    {
        
        entity.Name = dto.Name ?? entity.Name;
        entity.Image = dto.Image == null ? 
            entity.Image : ImageHandler.SaveImageToLocalStorage(dto.Image, Constants.RecipeImageFolder);
        entity.CategoryId = dto.CategoryId ?? entity.CategoryId;
        return entity;
    }

    public RecipeReadDto ToDto(RecipeEntity entity)
    {
        return new RecipeReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Image = ImageHandler.ReadImageFromLocalStorage(entity.Image, Constants.RecipeImageFolder),
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            Steps = entity.Steps?.Select(s => new StepMapper().ToDto(s)).ToList(),
            RecipePointsAndComments = entity.RecipePointsAndComments?.Select(p => 
                new RecipePointsAndCommentsMapper().ToDto(p)).ToList()
        };
    }
}