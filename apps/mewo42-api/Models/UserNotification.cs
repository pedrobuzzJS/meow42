using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbusernotification", Schema = "adm")]
public class UserNotification : BaseModel
{
    [Column("usernid")]
    public int Id { get; init; }
    [Column("usrid")]
    public int UserId { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("body")]
    public string Body { get; set; }
    [Column("message")]
    public string Message { get; set; }
    [Column("isread")]
    public bool IsRead { get; set; }
    public User User { get; set; }
}

public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.HasKey(n => n.Id);
    }
}