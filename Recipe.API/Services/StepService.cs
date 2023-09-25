using Microsoft.EntityFrameworkCore;
using Recipe.API.DTOs.StepDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class StepService : GenericService<Step, StepReadDto, StepCreateDto, StepUpdateDto>
{
    private readonly AppDbContext _context;
    
    public StepService(AppDbContext context, StepMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Step>> GetAllAsync(string? filter = null)
    {
        if (filter != null)
        {
            return await _context.Steps
                .Where(x => !x.IsDeleted)
                .Include(x => x.Ingredient)
                .Where(x => x.Ingredient!.Name.Contains(filter))
                .ToListAsync();
        }
        return await _context.Steps
            .Where(x => !x.IsDeleted)
            .Include(x => x.Ingredient).ToListAsync();
    }
    
    public override async Task<Step> GetByIdAsync(int id)
    {
        var entity = await _context.Steps
            .Where(x => !x.IsDeleted)
            .Include(x => x.Ingredient)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with: id {id}");
        
        return entity;
    }
}