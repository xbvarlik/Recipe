using Recipe.API.DTOs.CategoryDTOs;
using Recipe.Repository.Entities;

namespace Recipe.API.Mappings;

public class CategoryMapper : IBaseMapper<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    public Category ToEntity(CategoryCreateDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }

    public Category ToEntity(CategoryUpdateDto dto, Category entity)
    {
        if(dto.Name != null)
            entity.Name = dto.Name;
        
        return entity;
    }

    public CategoryReadDto ToDto(Category entity)
    {
        return new CategoryReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Recipes = entity.Recipes?.Select(r => new RecipeMapper().ToDto(r)).ToList()
        };
    }
}