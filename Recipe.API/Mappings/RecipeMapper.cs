using Recipe.API.DTOs.IngredientDTOs;
using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.DTOs.RecipeIngredientDTOs;
using Recipe.API.DTOs.RecipePointAndCommentDTOs;
using Recipe.Repository.Entities;
using RecipeEntity = Recipe.Repository.Entities.Recipe;

namespace Recipe.API.Mappings;

public class RecipeMapper : IBaseMapper<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto>
{
    public RecipeEntity ToEntity(RecipeCreateDto dto)
    {
        return new RecipeEntity
        {
            Name = dto.Name,
            RecipeDetails = dto.RecipeDetails,
            Image = dto.Image,
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
            RecipeIngredients = dto.RecipeIngredients?.Select(i => new RecipeIngredientMapper().ToEntity(i)).ToList()
        };
    }

    public RecipeEntity ToEntity(RecipeUpdateDto dto, RecipeEntity entity)
    {
        
        entity.Name = dto.Name ?? entity.Name;
        entity.RecipeDetails = dto.RecipeDetails ?? entity.RecipeDetails; 
        entity.Image = dto.Image ?? entity.Image;
        entity.CategoryId = dto.CategoryId ?? entity.CategoryId;
        entity.RecipeIngredients = dto.RecipeIngredients?.Select(i => new RecipeIngredient
        {
            Amount = i.Amount,
            IngredientId = i.IngredientId,
        }).ToList();
        return entity;
    }

    public RecipeReadDto ToDto(RecipeEntity entity)
    {
        return new RecipeReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            RecipeDetails = entity.RecipeDetails,
            Image = entity.Image,
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            RecipeIngredients = entity.RecipeIngredients?.Select(i => new RecipeIngredientReadDto
            {
                Id = i.Id,
                Amount = i.Amount,
                Ingredient = new IngredientReadDto
                {
                    Id = i.Ingredient.Id,
                    Name = i.Ingredient.Name
                }
            }).ToList(),
            RecipePointsAndComments = entity.RecipePointsAndComments?.Select(p => new RecipePointsAndCommentsReadDto
            {
                Id = p.Id,
                Points = p.Points,
                Comment = p.Comment,
                UserId = p.UserId,
                RecipeId = p.RecipeId
            }).ToList()
        };
    }
}