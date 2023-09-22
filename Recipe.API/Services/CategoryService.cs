using Recipe.API.DTOs.CategoryDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class CategoryService : GenericService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    public CategoryService(AppDbContext context, IBaseMapper<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto> mapper) : base(context, mapper)
    {
    }
}