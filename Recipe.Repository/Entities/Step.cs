namespace Recipe.Repository.Entities;

public class Step : BaseEntity
{
    public int Quantity { get; set; }
    
    public string Unit { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public int RecipeId { get; set; }
    
    public virtual Recipe? Recipe { get; set; }
    
    public int IngredientId { get; set; }
    
    public virtual Ingredient? Ingredient { get; set; }
    
}