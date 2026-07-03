using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbaudit", Schema = "aud")]
public class Audit : BaseModel
{
    [Column("auditid")]
    public int Id { get; init; }
    
    public Audit() {}
}

public class AuditConfiguration : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.HasKey(a => a.Id);
    }
}