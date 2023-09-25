using Microsoft.EntityFrameworkCore;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class GenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> 
    where TEntity : BaseEntity 
    where TReadDto : class 
    where TCreateDto : class 
    where TUpdateDto : class
{
    private readonly AppDbContext _context;
    private readonly IBaseMapper<TEntity, TReadDto, TCreateDto, TUpdateDto> _mapper;

    public GenericService(AppDbContext context, IBaseMapper<TEntity, TReadDto, TCreateDto, TUpdateDto> mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string? filter = null)
    {
        return await _context.Set<TEntity>().Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
    }
    
    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new KeyNotFoundException($"Entity not found with: id {id}");
        return entity;
    }
    
    public virtual async Task<TReadDto> CreateAsync(TCreateDto dto)
    {
        var entity = _mapper.ToEntity(dto);
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return _mapper.ToDto(entity);
    }
    
    public virtual async Task UpdateAsync(int id, TUpdateDto dto)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with id {id}");
        
        entity = _mapper.ToEntity(dto, entity);
        
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        
    }
    
    public virtual async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new KeyNotFoundException($"Entity not found with id {id}");
        
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}