using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbderivationitem", Schema = "pro")]
public class DerivationItem : BaseModel
{
    [Column("derivitemid")]
    public int Id { get; init; }
    
    public DerivationItem() {}
}

public class DerivationItemConfiguration : IEntityTypeConfiguration<DerivationItem>
{
    public void Configure(EntityTypeBuilder<DerivationItem> builder)
    {
        builder.ToTable("tbderivationitem", "pro");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("derivitemid");
    }
}