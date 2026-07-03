using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbuser", Schema = "adm")]
public class User : BaseModel
{
    [Column("usrid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("login")]
    public string Login { get; set; }
    [Column("email")]
    public string Email { get; set; }
    // public string Role { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("token")]
    public string Token { get; set; }
    [Column("type")]
    public int Type { get; set; }
    public ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
    
    public User() {}
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("usrid");
        
    }
}