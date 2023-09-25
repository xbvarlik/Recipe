namespace Recipe.Repository.Entities;

public class Tokens : BaseEntity
{
    public string Token { get; set; } = null!;
    
    public bool Status { get; set; }
}