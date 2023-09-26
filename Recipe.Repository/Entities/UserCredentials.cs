using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Repository.Entities;

public class UserCredentials : BaseEntity
{
    public string Email { get; set; } = null!;
    
    public byte[] PasswordHash { get; set; } = null!;
    
    public byte[] PasswordSalt { get; set; } = null!;
    
    [ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User? User { get; set; }
}