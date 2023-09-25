using Microsoft.EntityFrameworkCore;
using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class UserService : GenericService<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context, UserMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    public override async Task<IEnumerable<User>> GetAllAsync(string? filter = null)
    {
        if (filter != null)
        {
            return await _context.Users
                .Where(x => !x.IsDeleted)
                .Include(x => x.FavoriteRecipes.Where(fr => !fr.IsDeleted))
                .Include(x => x.Recipes.Where(r => !r.IsDeleted))
                .Include(x => x.RecipePointsAndComments.Where(rpc => !rpc.IsDeleted))
                .Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter))
                .ToListAsync();
        }
        return await _context.Users
            .Where(x => !x.IsDeleted)
            .Include(x => x.FavoriteRecipes.Where(fr => !fr.IsDeleted))
            .Include(x => x.Recipes.Where(r => !r.IsDeleted))
            .Include(x => x.RecipePointsAndComments.Where(rpc => !rpc.IsDeleted))
            .ToListAsync();
    }

    public override async Task<User> GetByIdAsync(int id)
    {
        var entity = await _context.Users
            .Where(x => !x.IsDeleted)
            .Include(x => x.FavoriteRecipes.Where(fr => !fr.IsDeleted))
            .Include(x => x.Recipes.Where(r => !r.IsDeleted))
            .Include(x => x.RecipePointsAndComments.Where(rpc => !rpc.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with: id {id}");
        
        return entity;
    }
}