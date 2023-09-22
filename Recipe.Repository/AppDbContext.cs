using Microsoft.EntityFrameworkCore;
using Recipe.Repository.Entities;

namespace Recipe.Repository;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Entities.Recipe> Recipes { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Step> Steps { get; set; } = null!;
    public DbSet<FavoriteRecipes> FavoriteRecipes { get; set; } = null!;
    public RecipePointsAndComments RecipePointsAndComments { get; set; } = null!;
    
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public override int SaveChanges()
    {
        ChangeTracker.Entries().ToList().ForEach(e =>
        {
            if (e.Entity is BaseEntity b)
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        b.CreatedAt = DateTime.Now;
                        b.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        b.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        e.State = EntityState.Modified;
                        b.IsDeleted = true;
                        break;
                }
            }
        });
        return base.SaveChanges();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries().ToList().ForEach(e =>
        {
            if (e.Entity is not BaseEntity b) return;
            
            switch (e.State)
            {
                case EntityState.Added:
                    b.CreatedAt = DateTime.Now;
                    b.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    b.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    e.State = EntityState.Modified;
                    b.IsDeleted = true;
                    break;
            }
        });
        
        return base.SaveChangesAsync(cancellationToken);
    }

}