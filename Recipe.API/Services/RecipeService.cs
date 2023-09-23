﻿using Microsoft.EntityFrameworkCore;
using Recipe.API.DTOs.RecipeDTOs;
using Recipe.API.Mappings;
using Recipe.Repository;
using RecipeEntity = Recipe.Repository.Entities.Recipe;
using Recipe.API.Helpers;

namespace Recipe.API.Services;

public class RecipeService : GenericService<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto>
{
    private readonly AppDbContext _context;
    public RecipeService(AppDbContext context, IBaseMapper<RecipeEntity, RecipeReadDto, RecipeCreateDto, RecipeUpdateDto> mapper) : base(context, mapper)
    {
        _context = context;
    }

    public override async Task<IEnumerable<RecipeEntity>> GetAllAsync(string? filter = null)
    {
        if (filter != null)
        {
            return await _context.Recipes
                .Include(x => x.Steps)!
                .ThenInclude(y => y.Ingredient)
                .Include(x => x.RecipePointsAndComments)
                .Where(x => x.Name.Contains(filter))
                .ToListAsync();
        }
        
        return await _context.Recipes
            .Include(x => x.Steps)!
            .ThenInclude(y => y.Ingredient)
            .Include(x => x.RecipePointsAndComments)
            .ToListAsync();
    }

    public override async Task<RecipeEntity> GetByIdAsync(int id)
    {
        var entity = await _context.Recipes
            .Include(x => x.Steps)!
            .ThenInclude(y => y.Ingredient)
            .Include(x => x.RecipePointsAndComments)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (entity == null) throw new KeyNotFoundException($"Entity not found with: id {id}");
        
        return entity;
    }


}