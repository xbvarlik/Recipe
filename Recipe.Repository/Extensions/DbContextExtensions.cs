using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Recipe.Repository.Entities;
using DbContext = Recipe.Repository.AppDbContext;

namespace Recipe.Repository.Extensions;

public static class DbContextExtension
{
    public static IQueryable<TEntity> GetActive<TEntity>(this DbSet<TEntity> entities) where TEntity : BaseEntity
    {
        return entities.Where(e => !e.IsDeleted);
    }

    public static IQueryable<TEntity> IncludeActive<TEntity, TProperty>(
        this IQueryable<TEntity> entities,
        Expression<Func<TEntity, TProperty>> navigationProperty)
        where TEntity : BaseEntity
    {
        return entities
            .Include(navigationProperty)
            .Where(relatedEntity => !relatedEntity.IsDeleted)
            .Distinct()
            .AsQueryable();
    }
}
