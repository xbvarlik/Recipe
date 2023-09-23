using Microsoft.EntityFrameworkCore;
using Recipe.API.DTOs.UserDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using Recipe.Repository.Entities;

namespace Recipe.API.Services;

public class UserService : GenericService<User, UserReadDto, UserCreateDto, UserUpdateDto>
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context, IBaseMapper<User, UserReadDto, UserCreateDto, UserUpdateDto> mapper) : base(context, mapper)
    {
        _context = context;
    }

    public override async Task<IEnumerable<User>> GetAllAsync(string? filter = null)
    {
        if (filter != null)
        {
            return await _context.Users
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.Recipes)
                .Include(x => x.RecipePointsAndComments)
                .Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter))
                .ToListAsync();
        }
        return await _context.Users
            .Include(x => x.FavoriteRecipes)
            .Include(x => x.Recipes)
            .Include(x => x.RecipePointsAndComments)
            .ToListAsync();
    }

    public override async Task<User> GetByIdAsync(int id)
    {
        var entity = await _context.Users
            .Include(x => x.FavoriteRecipes)
            .Include(x => x.Recipes)
            .Include(x => x.RecipePointsAndComments)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with: id {id}");
        
        return entity;
    }
}