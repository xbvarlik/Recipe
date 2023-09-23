using Recipe.API.DTOs.RecipePointAndCommentDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class RecipePointsAndCommentsService : GenericService<RecipePointsAndComments, RecipePointsAndCommentsReadDto, RecipePointsAndCommentsCreateDto, RecipePointsAndCommentsUpdateDto>
{
    public RecipePointsAndCommentsService(AppDbContext context, RecipePointsAndCommentsMapper mapper) : base(context, mapper)
    {
    }
}