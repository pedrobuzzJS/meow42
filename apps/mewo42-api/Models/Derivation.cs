using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbderivation", Schema = "pro")]
public class Derivation : BaseModel
{
    [Column("derivid")]
    public int Id { get; init; }
    
    public Derivation() {}
}

public class DetivationConfiguration : IEntityTypeConfiguration<Derivation>
{
    public void Configure(EntityTypeBuilder<Derivation> builder)
    {
        builder.ToTable("tbderivation", "pro");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("derivid");
    }
}