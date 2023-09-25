using Microsoft.EntityFrameworkCore;
using Recipe.API.DTOs.CategoryDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class CategoryService : GenericService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
{
    private readonly AppDbContext _context;
    public CategoryService(AppDbContext context, CategoryMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Category>> GetAllAsync(string? filter = null)
    {
        
        if (filter != null)
        {
            return await _context.Categories
                .Where(x => !x.IsDeleted)
                .Include(x => x.Recipes.Where(y => !y.IsDeleted))
                .Where(x => x.Name.Contains(filter))
                .AsNoTracking().ToListAsync();
        }
        
        return await _context.Categories
            .Where(x => !x.IsDeleted)
            .Include(x => x.Recipes.Where(y => !y.IsDeleted))
            .AsNoTracking().ToListAsync();
    }

    public override async Task<Category> GetByIdAsync(int id)
    {
        var entity = await _context.Categories
            .Where(x => !x.IsDeleted)
            .Include(x => x.Recipes.Where(y => !y.IsDeleted))           
            .FirstOrDefaultAsync(x=>x.Id == id);

        
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with id: {id}");
        
        return entity;
    }
}