using Recipe.API.DTOs.RecipeDTOs;
using RecipeEntity = Recipe.Repository.Entities.Recipe;

namespace Recipe.API.Helpers;

public static class FilterHelpers
{
    public static IQueryable<RecipeEntity> ApplyRecipeFilter(RecipeQueryFilterDto queryFilter, IQueryable<RecipeEntity> query)
    {
        if (queryFilter.RecipeNameFilter != null)
        {
            query = query.Where(r => r.Name.Contains(queryFilter.RecipeNameFilter));
        }

        if (queryFilter.UserIdFilter != null)
        {
            query = query.Where(r => r.UserId == queryFilter.UserIdFilter);
        }

        return query;
    }
}