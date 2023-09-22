using Microsoft.EntityFrameworkCore;

namespace Recipe.Repository.Entities;

public class RecipePointsAndComments : BaseEntity
{
    public int Points { get; set; }
    
    public string Comment { get; set; } = null!;
    
    public int UserId { get; set; }
    
    public int RecipeId { get; set; }
    
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual User? User { get; set; } 
    
    public virtual Recipe? Recipe { get; set; }
}