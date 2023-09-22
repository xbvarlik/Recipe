namespace Recipe.Repository.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public virtual ICollection<Step>? Steps { get; set; }
}