using Recipe.API.DTOs.RecipePointAndCommentDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class RecipePointsAndCommentsMapper : IBaseMapper<RecipePointsAndComments, 
    RecipePointsAndCommentsReadDto, RecipePointsAndCommentsCreateDto, RecipePointsAndCommentsUpdateDto>
{
    public RecipePointsAndComments ToEntity(RecipePointsAndCommentsCreateDto dto)
    {
        return new RecipePointsAndComments
        {
            RecipeId = dto.RecipeId,
            UserId = dto.UserId,
            Comment = dto.Comment,
            Points = dto.Points
        };
    }

    public RecipePointsAndComments ToEntity(RecipePointsAndCommentsUpdateDto dto, RecipePointsAndComments entity)
    {
        entity.Comment = dto.Comment ?? entity.Comment;
        entity.Points = dto.Points ?? entity.Points;

        return entity;
    }

    public RecipePointsAndCommentsReadDto ToDto(RecipePointsAndComments entity)
    {
        return new RecipePointsAndCommentsReadDto
        {
            Id = entity.Id,
            RecipeId = entity.RecipeId,
            UserId = entity.UserId,
            Comment = entity.Comment,
            Points = entity.Points
        };
    }
}